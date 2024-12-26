using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.FrameworkDialogs;
using Waifu2x.Core.Messages;
using Waifu2x.Core.Services;

namespace Waifu2x.Core.ViewModels;

/// <summary>
/// Main window view model
/// </summary>
public partial class MainWindowViewModel : ViewModelBase, IRecipient<LogMessage>, IRecipient<ReportProgressMessage>
{
    /// <summary>
    /// Output log
    /// </summary>
    public ObservableCollection<string> Log { get; } = [];

    [ObservableProperty]
    private bool isEnabled = true;
    [ObservableProperty]
    private int progressMax = 100;
    [ObservableProperty]
    private int progress;
    [ObservableProperty]
    private bool progressMarquee;

    private readonly IStorageService storageService;
    private readonly IDialogService dialogService;
    private readonly IUpscalerService upscalerService;

    /// <summary>
    /// MainWindow initializer
    /// </summary>
    public MainWindowViewModel() : this(null!, null!, null!) { }

    /// <summary>
    /// MainWindowViewModel initializer
    /// </summary>
    /// <param name="storageService">Storage service</param>
    /// <param name="dialogService">Dialog service</param>
    /// <param name="upscalerService">Upscaler service</param>
    public MainWindowViewModel(IStorageService storageService, IDialogService dialogService, IUpscalerService upscalerService)
    {
        this.storageService  = storageService;
        this.dialogService   = dialogService;
        this.upscalerService = upscalerService;

        StrongReferenceMessenger.Default.Register<LogMessage>(this);
        StrongReferenceMessenger.Default.Register<ReportProgressMessage>(this);
    }

    /// <summary>
    /// Finalizer
    /// </summary>
    ~MainWindowViewModel() => StrongReferenceMessenger.Default.UnregisterAll(this);

    /// <summary>
    /// Validates the input/output paths
    /// </summary>
    /// <typeparam name="T">Type of IO (folder/file)</typeparam>
    /// <param name="input">Input path</param>
    /// <param name="output">Output path</param>
    /// <returns><see langword="true"/> if the paths are valid, otherwise <see langword="false"/></returns>
    private async Task<bool> ValidateIO<T>(T input, T output) where T : FileSystemInfo
    {
        // Object type
        string type = input switch
        {
            FileInfo      => "file",
            DirectoryInfo => "folder",
            _             => "object"
        };

        // Check if the input exists
        if (!input.Exists)
        {
            await this.dialogService.ShowMessageBoxAsync(this, $"The selected input {type} does not exist.", "Error", icon: MessageBoxImage.Error);
            return false;
        }

        // Warn if the output exists
        if (output.Exists)
        {
            bool? result = await this.dialogService.ShowMessageBoxAsync(this, $"The output {type} already exists, overwrite file(s)?", "Warning",
                                                                        button: MessageBoxButton.OkCancel, icon: MessageBoxImage.Error);
            return result is not null;
        }

        // Create output dir as required
        if (output is DirectoryInfo outputDir)
        {
            outputDir.Create();
        }

        return true;
    }

    /// <summary>
    /// Add log message
    /// </summary>
    /// <param name="message">Message to log</param>
    private void AddLog(string? message)
    {
        if (!string.IsNullOrEmpty(message))
        {
            this.Log.Add(message);
        }
    }

    /// <summary>
    /// Validate that the input and output are not empty
    /// </summary>
    /// <returns><see langword="true"/> if a request to run the upscaler is valid, otherwise <see langword="false"/></returns>
    private bool CanRequestRun() => !string.IsNullOrWhiteSpace(this.InputPath)
                                 && !string.IsNullOrWhiteSpace(this.OutputSuffix);

    /// <summary>
    /// Upscaling request command
    /// </summary>
    [RelayCommand(CanExecute = nameof(CanRequestRun))]
    private async Task RunRequested()
    {
        // Make sure that target is of the valid file type
        FileAttributes attributes = File.GetAttributes(this.InputPath!);
        bool isDir = (attributes & FileAttributes.Directory) is not 0;
        if (this.IsFolder != isDir)
        {
            await this.dialogService.ShowMessageBoxAsync(this, $"The selected input is not a {(this.IsFolder ? "Folder" : "File")}.", "Error", icon: MessageBoxImage.Error);
            return;
        }

        try
        {
            // Validate IO before proceeding
            bool valid = this.IsFolder ? await ValidateIO(new DirectoryInfo(this.InputPath!), new DirectoryInfo(this.OutputPath))
                                       : await ValidateIO(new FileInfo(this.InputPath!), new FileInfo(this.OutputPath));
            if (valid)
            {
                await RunUpscale();
            }
        }
        catch (Exception exception)
        {
            // Show errors
            await this.dialogService.ShowMessageBoxAsync(this, "Invalid path detected.\nError: " + exception.Message, "Error", icon: MessageBoxImage.Error);
        }
    }

    private async Task RunUpscale()
    {
        try
        {
            // Create upscaling options
            UpscaleOptions upscaleOptions = new()
            {
                InputPath        = this.InputPath!,
                OutputPath       = this.OutputPath,
                ScaleFactor      = this.Scale,
                DenoiseLevel     = this.DenoiseLevel,
                Format           = this.Format,
                PPI              = this.Ppi,
                ConvertGrayscale = this.Grayscale,
                TTAMode          = this.TtaMode,
                RemoveAlpha      = this.RemoveAlpha,

                ThreadOptions = new ThreadOptions
                {
                    DecodeThreads  = this.DecodeThreads,
                    UpscaleThreads = this.UpscaleThreads,
                    EncodeThreads  = this.EncodeThreads
                }
            };

            // Start process, disable window, and enable marquee on progressbar
            this.IsEnabled       = false;
            this.ProgressMarquee = true;
            await this.upscalerService.RunUpscaler(upscaleOptions);
        }
        catch (Exception e)
        {
            AddLog("Unhandled error: " + e.Message);
        }
        finally
        {
            // Cleanup progressbar and reenable window
            this.Progress        = 0;
            this.ProgressMarquee = false;
            this.IsEnabled       = true;
        }
    }

    /// <summary>
    /// Log message receiver
    /// </summary>
    /// <param name="message">Message to log data</param>
    public void Receive(LogMessage message) => AddLog(message.Message);

    /// <summary>
    /// Progress report receiver
    /// </summary>
    /// <param name="message">Progress report message</param>
    public void Receive(ReportProgressMessage message)
    {
        if (message.MaxValue is null)
        {
            // Increment progress
            this.Progress++;
            return;
        }

        // Reset progress with new max value
        this.ProgressMarquee = false;
        this.Progress        = 0;
        this.ProgressMax     = message.MaxValue.Value;
    }
}
