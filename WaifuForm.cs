using System.Diagnostics;

namespace Waifu2x;

public partial class WaifuForm : Form
{
    #region Fields
    private Process? waifu;
    private Process? grayscale;
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
                                          : $"{Path.ChangeExtension(this.Input, null)}{this.OutputSuffix}.{this.Format}";

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
    public string ScaleFactor => this.comboBoxScale.SelectedItem.ToString()!;

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
    public string DenoiseLevel => this.comboBoxDenoising.SelectedItem.ToString()!;

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
    public string Format => this.comboBoxFormat.SelectedItem.ToString()!.ToLower();

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
    }

    /// <summary>
    /// Runs the waifu2x subprogram
    /// </summary>
    /// ReSharper disable once InconsistentNaming
    private void RunWaifu2x()
    {
        this.waifu = new()
        {
            EnableRaisingEvents = true,
            StartInfo = new()
            {
                FileName = Path.GetFullPath(@"dist\waifu2x-ncnn-vulkan.exe"),
                Arguments = $"-i \"{this.Input}\" -o \"{this.Output}\" -s {this.ScaleFactor} -n {this.DenoiseLevel} -f {this.Format} -v",
                UseShellExecute = false
            }
        };

        this.waifu.Exited += WaifuExited;
        SetFormEnabled(false);
        this.waifu.Start();
    }

    /// <summary>
    /// Runs the grayscale subprogram
    /// </summary>
    private void RunGrayscale()
    {
        this.grayscale = new()
        {
            EnableRaisingEvents = true,
            StartInfo = new()
            {
                FileName = Path.GetFullPath(@"dist\grayscale.exe"),
                Arguments = $"\"{this.Output}\"",
                UseShellExecute = false
            }
        };

        this.grayscale.Exited += GrayscaleExited;
        SetFormEnabled(false);
        this.grayscale.Start();
    }

    /// <summary>
    /// Sets the form's working status
    /// </summary>
    /// <param name="enabled">If the form should be enabled or not</param>
    private void SetFormEnabled(bool enabled)
    {
        this.groupBoxInput.Enabled    = enabled;
        this.groupBoxSettings.Enabled = enabled;
        this.buttonRun.Enabled        = enabled;
        this.progressBar.Style        = enabled ? ProgressBarStyle.Blocks : ProgressBarStyle.Marquee;
    }

    /// <summary>
    /// Validates the input/output paths
    /// </summary>
    /// <typeparam name="T">Type of IO (folder/file)</typeparam>
    /// <param name="input">Input path</param>
    /// <param name="output">Output path</param>
    /// <param name="type">IO type name</param>
    /// <returns><see langword="true"/> if the paths are valid, otherwise <see langword="false"/></returns>
    private static bool ValidateIO<T>(T input, T output, string type) where T : FileSystemInfo
    {
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
            bool valid = this.IsFolder ? ValidateIO<DirectoryInfo>(new(this.Input), new(this.Output), "folder")
                                       : ValidateIO<FileInfo>(new(this.Input), new(this.Output), "file");
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
        this.waifu?.Dispose();
        this.waifu = null;

        if (this.Grayscale)
        {
            Invoke(RunGrayscale);
        }
        else
        {
            Invoke(() => SetFormEnabled(true));
        }
    }

    private void GrayscaleExited(object? sender, EventArgs e)
    {
        // Restore status from UI thread
        this.grayscale?.Dispose();
        this.grayscale = null;
        Invoke(() => SetFormEnabled(true));
    }
    #endregion
}
