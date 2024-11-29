using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.FrameworkDialogs;
using Waifu2x.Core.Messages;
using Waifu2x.Core.Services;

namespace Waifu2x.Core.ViewModels;

public partial class MainWindowViewModel : ViewModelBase, IRecipient<LogMessage>, IRecipient<ReportProgressMessage>
{
    public ObservableCollection<string> Log { get; } = [];

    public MainWindowViewModel() : this(null!, null!, null!) { }

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

    /// <inheritdoc/>
    public MainWindowViewModel(IStorageService storageService, IDialogService dialogService, IUpscalerService upscalerService)
    {
        this.storageService  = storageService;
        this.dialogService   = dialogService;
        this.upscalerService = upscalerService;

        StrongReferenceMessenger.Default.Register<LogMessage>(this);
        StrongReferenceMessenger.Default.Register<ReportProgressMessage>(this);
    }

    /// <summary>
    /// Validates the input/output paths
    /// </summary>
    /// <typeparam name="T">Type of IO (folder/file)</typeparam>
    /// <param name="input">Input path</param>
    /// <param name="output">Output path</param>
    /// <returns><see langword="true"/> if the paths are valid, otherwise <see langword="false"/></returns>
    private async Task<bool> ValidateIO<T>(T input, T output) where T : FileSystemInfo
    {
        string type = input switch
        {
            FileInfo      => "file",
            DirectoryInfo => "folder",
            _             => "object"
        };

        if (!input.Exists)
        {
            await this.dialogService.ShowMessageBoxAsync(this, $"The selected input {type} does not exist.", "Error", icon: MessageBoxImage.Error);
            return false;
        }

        if (output.Exists)
        {
            bool? result = await this.dialogService.ShowMessageBoxAsync(this, $"The output {type} already exists, overwrite file(s)?", "Warning",
                                                                         button: MessageBoxButton.OkCancel, MessageBoxImage.Error);
            return result is not null;
        }

        if (output is DirectoryInfo outputDir)
        {
            outputDir.Create();
        }

        return true;
    }

    private void AddLog(string? message)
    {
        if (!string.IsNullOrEmpty(message))
        {
            this.Log.Add(message);
        }
    }

    private bool CanRequestRun() => !string.IsNullOrWhiteSpace(this.InputPath)
                               && !string.IsNullOrWhiteSpace(this.OutputSuffix);

    [RelayCommand(CanExecute = nameof(CanRequestRun))]
    private async Task RunRequested()
    {
        FileAttributes attributes = File.GetAttributes(this.InputPath!);
        bool isDir = (attributes & FileAttributes.Directory) is not 0;
        if (this.IsFolder != isDir)
        {
            await this.dialogService.ShowMessageBoxAsync(this, $"The selected input is not a {(this.IsFolder ? "Folder" : "File")}.", "Error", icon: MessageBoxImage.Error);
            return;
        }

        try
        {
            bool valid = this.IsFolder ? await ValidateIO(new DirectoryInfo(this.InputPath!), new DirectoryInfo(this.OutputPath))
                                       : await ValidateIO(new FileInfo(this.InputPath!), new FileInfo(this.OutputPath));
            if (valid)
            {
                await RunUpscale();
            }
        }
        catch (Exception exception)
        {
            await this.dialogService.ShowMessageBoxAsync(this, "Invalid path detected.\nError: " + exception.Message, "Error", icon: MessageBoxImage.Error);
        }
    }

    private async Task RunUpscale()
    {
        UpscaleOptions upscaleOptions = new()
        {
            InputPath        = this.InputPath!,
            OutputPath       = this.OutputPath,
            ScaleFactor      = this.Scale,
            DenoiseLevel     = this.DenoiseLevel,
            Format           = this.Format,
            ConvertGrayscale = this.Grayscale,
            TTAMode          = this.TtaMode,

            ThreadOptions = new ThreadOptions
            {
                DecodeThreads  = this.DecodeThreads,
                UpscaleThreads = this.UpscaleThreads,
                EncodeThreads  = this.EncodeThreads
            }
        };

        this.IsEnabled       = false;
        this.ProgressMarquee = true;
        await this.upscalerService.RunUpscaler(upscaleOptions);
        this.Progress        = 0;
        this.ProgressMarquee = false;
        this.IsEnabled       = true;
    }

    public void Receive(LogMessage message) => AddLog(message.Message);

    public void Receive(ReportProgressMessage message)
    {
        if (message.MaxValue is null)
        {
            this.Progress++;
            return;
        }

        this.ProgressMarquee = false;
        this.Progress        = 0;
        this.ProgressMax     = message.MaxValue.Value;
    }
}
