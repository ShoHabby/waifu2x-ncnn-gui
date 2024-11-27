using System.Diagnostics;
using ImageMagick;

namespace Waifu2x.Forms;

public partial class WaifuForm : Form
{
    #region Fields
    private Process? waifu;
    private Task? grayscale;
    #endregion

    #region Properties
    /// <summary>
    /// If current input is a folder (otherwise it's a file)
    /// </summary>
    public bool IsFolder
    {
        get => this.radioButtonFolder.Checked;
        set
        {
            if (this.radioButtonFolder.Checked == value) return;

            this.radioButtonFolder.Checked = value;
            this.radioButtonFile.Checked   = !value;
        }
    }

    /// <summary>
    /// Current input path
    /// </summary>
    public string Input
    {
        get => this.textBoxInput.Text;
        set => this.textBoxInput.Text = value;
    }

    /// <summary>
    /// Output suffix
    /// </summary>
    public string OutputSuffix
    {
        get => this.textBoxOutputSuffix.Text;
        set => this.textBoxOutputSuffix.Text = value;
    }

    /// <summary>
    /// Current output path
    /// </summary>
    public string Output => this.IsFolder ? this.Input + this.OutputSuffix
                                          : $"{Path.GetFileNameWithoutExtension(this.Input)}{this.OutputSuffix}.{this.Format}";

    /// <summary>
    /// Selected scale index
    /// </summary>
    public int ScaleIndex
    {
        get => this.comboBoxScale.SelectedIndex;
        set => this.comboBoxScale.SelectedIndex = value;
    }

    /// <summary>
    /// Selected scale factor
    /// </summary>
    public string ScaleFactor => this.comboBoxScale.SelectedItem?.ToString()!;

    /// <summary>
    /// Selected denoise index
    /// </summary>
    public int DenoiseIndex
    {
        get => this.comboBoxDenoising.SelectedIndex;
        set => this.comboBoxDenoising.SelectedIndex = value;
    }

    /// <summary>
    /// Selected denoise level
    /// </summary>
    public string DenoiseLevel => this.comboBoxDenoising.SelectedItem?.ToString()!;

    /// <summary>
    /// Selected format index
    /// </summary>
    public int FormatIndex
    {
        get => this.comboBoxFormat.SelectedIndex;
        set => this.comboBoxFormat.SelectedIndex = value;
    }

    /// <summary>
    /// Selected output format
    /// </summary>
    public string Format => this.comboBoxFormat.SelectedItem?.ToString()!.ToLower()!;

    /// <summary>
    /// If files should be converted to grayscale after waifu2x runs
    /// </summary>
    public bool Grayscale
    {
        get => this.checkBoxGrayscale.Checked;
        set => this.checkBoxGrayscale.Checked = value;
    }
    #endregion

    #region Constructors
    public WaifuForm()
    {
        InitializeComponent();
        Setup();
    }
    #endregion

    #region Methods
    /// <summary>
    /// Form settings setup
    /// </summary>
    private void Setup()
    {
        this.IsFolder     = Settings.Default.IsFolder;
        this.Input        = Settings.Default.Input;
        this.OutputSuffix = Settings.Default.OutputSuffix;
        this.ScaleIndex   = Settings.Default.ScaleIndex;
        this.DenoiseIndex = Settings.Default.DenoiseIndex;
        this.FormatIndex  = Settings.Default.FormatIndex;
        this.Grayscale    = Settings.Default.Grayscale;
        this.Width        = Settings.Default.Width;
        this.Height       = Settings.Default.Height;
    }

    /// <summary>
    /// Runs the waifu2x subprogram
    /// </summary>
    /// ReSharper disable once InconsistentNaming
    private void RunWaifu2x()
    {
        AddLogMessage("Running Waifu process...");
        this.waifu = new Process
        {
            EnableRaisingEvents = true,
            StartInfo = new ProcessStartInfo
            {
                FileName = Path.GetFullPath(@"dist\waifu2x-ncnn-vulkan.exe"),
                Arguments = $"""-i "{this.Input}" -o "{this.Output}" -s {this.ScaleFactor} -n {this.DenoiseLevel} -f {this.Format} -v""",
                UseShellExecute = false,
                CreateNoWindow  = true,
                RedirectStandardOutput = true,
                RedirectStandardError  = true,
            }
        };

        this.waifu.Exited += WaifuExited;
        this.waifu.OutputDataReceived += WaifuOnOutputDataReceived;
        this.waifu.ErrorDataReceived += WaifuOnOutputDataReceived;
        SetFormEnabled(false);
        this.waifu.Start();
        this.waifu.BeginOutputReadLine();
        this.waifu.BeginErrorReadLine();
    }

    /// <summary>
    /// Runs the grayscale subprogram
    /// </summary>
    private void RunGrayscale()
    {
        AddLogMessage("Converting images to grayscale...");
        if (!this.IsFolder)
        {
            SetFormEnabled(false);
            ConvertToGray(new FileInfo(this.Output));
            return;
        }

        SetFormEnabled(false, false);
        DirectoryInfo outputDir = new(this.Output);
        FileInfo[] files = outputDir.GetFiles($"*.{this.Format}");
        this.progressBar.Maximum = files.Length;
        this.grayscale = Parallel.ForEachAsync(files, ConvertToGrayAsync).ContinueWith(GrayscaleCompleted);
    }

    /// <summary>
    /// Sets the form's working status
    /// </summary>
    /// <param name="enabled">If the form should be enabled or not</param>
    /// <param name="useMarquee">If a marquee bar should be used while the form is disabled</param>
    private void SetFormEnabled(bool enabled, bool useMarquee = true)
    {
        this.groupBoxInput.Enabled    = enabled;
        this.groupBoxSettings.Enabled = enabled;
        this.buttonRun.Enabled        = enabled;
        this.progressBar.Style        = !enabled && useMarquee ? ProgressBarStyle.Marquee : ProgressBarStyle.Continuous;
    }

    /// <summary>
    /// Async gray conversion handler
    /// </summary>
    /// <param name="file">File to convert</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The conversion task</returns>
    private ValueTask ConvertToGrayAsync(FileInfo file, CancellationToken cancellationToken)
    {
        ConvertToGray(file);
        Invoke(() => this.progressBar.PerformStep());
        return ValueTask.CompletedTask;
    }

    /// <summary>
    /// Convert an image file to grayscale
    /// </summary>
    /// <param name="file">File to convert</param>
    private void ConvertToGray(FileInfo file)
    {
        using MagickImage image = new(file);
        image.Grayscale(PixelIntensityMethod.Average);
        image.Write(file);
        AddLogMessage($"{file.FullName} converted to grayscale");
    }

    /// <summary>
    /// Validates the input/output paths
    /// </summary>
    /// <typeparam name="T">Type of IO (folder/file)</typeparam>
    /// <param name="input">Input path</param>
    /// <param name="output">Output path</param>
    /// <returns><see langword="true"/> if the paths are valid, otherwise <see langword="false"/></returns>
    private static bool ValidateIO<T>(T input, T output) where T : FileSystemInfo
    {
        string type = input switch
        {
            FileInfo      => "file",
            DirectoryInfo => "folder",
            _             => "object"
        };

        if (!input.Exists)
        {
            MessageBox.Show($"The selected input {type} does not exist.", "Error");
            return false;
        }

        if (output.Exists)
        {
            // Make sure users know they could be overwriting files
            DialogResult result = MessageBox.Show($"The output {type} already exists, overwrite file(s)?",
                                                  "Warning", MessageBoxButtons.OKCancel);
            if (result is DialogResult.Cancel) return false;
        }
        else if (output is DirectoryInfo outputDir)
        {
            outputDir.Create();
        }

        return true;
    }

    /// <summary>
    /// Logs an message to the form log box
    /// </summary>
    /// <param name="message">Message to log</param>
    private void AddLogMessage(string message)
    {
        if (this.InvokeRequired)
        {
            Invoke(() => AddLogMessage(message));
        }
        else
        {
            this.logListBox.Items.Add(message);
            this.logListBox.TopIndex = this.logListBox.Items.Count - 1;
        }
    }
    #endregion

    #region Event handlers
    private void WaifuForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        // Copy all settings over
        Settings.Default.IsFolder     = this.IsFolder;
        Settings.Default.Input        = this.Input;
        Settings.Default.OutputSuffix = this.OutputSuffix;
        Settings.Default.ScaleIndex   = this.ScaleIndex;
        Settings.Default.DenoiseIndex = this.DenoiseIndex;
        Settings.Default.FormatIndex  = this.FormatIndex;
        Settings.Default.Grayscale    = this.Grayscale;
        Settings.Default.Width        = this.Width;
        Settings.Default.Height       = this.Height;

        // Save before closing
        Settings.Default.Save();
    }

    private void buttonBrowseInput_Click(object sender, EventArgs e)
    {
        // Open the appropriate dialogue depending on the type
        if (this.IsFolder)
        {
            this.folderBrowserInput.ShowDialog(this);
            this.Input = this.folderBrowserInput.SelectedPath;
        }
        else
        {
            this.openFileInput.ShowDialog(this);
            this.Input = this.openFileInput.FileName;
        }
    }

    private void buttonRun_Click(object sender, EventArgs e)
    {
        // Validate all paths and settings are correct before proceeding
        if (string.IsNullOrWhiteSpace(this.Input))
        {
            MessageBox.Show($"Please select an input {(this.IsFolder ? "Folder" : "File")}.", "Error");
            return;
        }

        if (string.IsNullOrWhiteSpace(this.OutputSuffix))
        {
            MessageBox.Show($"Please enter a valid {(this.IsFolder ? "Folder" : "File")}.", "Error");
            return;
        }

        FileAttributes attributes = File.GetAttributes(this.Input);
        bool isDir = (attributes & FileAttributes.Directory) is not 0;
        if (this.IsFolder != isDir)
        {
            MessageBox.Show($"The selected input is not a {(this.IsFolder ? "Folder" : "File")}.", "Error");
            return;
        }

        try
        {
            bool valid = this.IsFolder ? ValidateIO(new DirectoryInfo(this.Input), new DirectoryInfo(this.Output))
                                       : ValidateIO(new FileInfo(this.Input), new FileInfo(this.Output));
            if (!valid) return;
        }
        catch (ArgumentException exception)
        {
            MessageBox.Show($"The selected path has invalid characters.\nError: {exception.Message}", "Error");
            return;
        }

        RunWaifu2x();
    }

    private void WaifuExited(object? sender, EventArgs e)
    {
        if (this.waifu is not null)
        {
            this.waifu.WaitForExit();
            this.waifu.CancelOutputRead();
            this.waifu.CancelErrorRead();
            this.waifu.OutputDataReceived -= WaifuOnOutputDataReceived;
            this.waifu.ErrorDataReceived  -= WaifuOnOutputDataReceived;
            this.waifu.Close();
            this.waifu.Dispose();
            this.waifu = null;
        }

        AddLogMessage("Waifu process completed");
        if (this.Grayscale)
        {
            Invoke(RunGrayscale);
        }
        else
        {
            Invoke(() => SetFormEnabled(true));
        }
    }

    private void WaifuOnOutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.Data))
        {
            AddLogMessage(e.Data);
        }
    }

    private async void GrayscaleCompleted(Task task)
    {
        try
        {
            // Restore status from UI thread
            if (this.grayscale is not null)
            {
                await this.grayscale;
            }

            this.grayscale?.Dispose();
            this.grayscale = null;
            Invoke(() =>
            {
                SetFormEnabled(true);
                this.progressBar.Value = 0;
                AddLogMessage("All images converted to grayscale");
            });
        }
        catch (Exception e)
        {
            AddLogMessage(e.Message);
        }
    }
    #endregion
}
