namespace Waifu2x.Forms
{
    partial class WaifuForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.components?.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaifuForm));
            folderBrowserInput   = new System.Windows.Forms.FolderBrowserDialog();
            labelInput           = new System.Windows.Forms.Label();
            textBoxInput         = new System.Windows.Forms.TextBox();
            buttonBrowseInput    = new System.Windows.Forms.Button();
            labelOutputSuffix    = new System.Windows.Forms.Label();
            textBoxOutputSuffix  = new System.Windows.Forms.TextBox();
            groupBoxInput        = new System.Windows.Forms.GroupBox();
            radioButtonFile      = new System.Windows.Forms.RadioButton();
            radioButtonFolder    = new System.Windows.Forms.RadioButton();
            labelInputType       = new System.Windows.Forms.Label();
            openFileInput        = new System.Windows.Forms.OpenFileDialog();
            groupBoxSettings     = new System.Windows.Forms.GroupBox();
            numericUpDownSave    = new System.Windows.Forms.NumericUpDown();
            numericUpDownUpscale = new System.Windows.Forms.NumericUpDown();
            numericUpDownLoad    = new System.Windows.Forms.NumericUpDown();
            labelSaveThreads     = new System.Windows.Forms.Label();
            labelUpscaleThreads  = new System.Windows.Forms.Label();
            labelLoadThreads     = new System.Windows.Forms.Label();
            checkBoxTTA          = new System.Windows.Forms.CheckBox();
            checkBoxGrayscale    = new System.Windows.Forms.CheckBox();
            labelFormat          = new System.Windows.Forms.Label();
            comboBoxFormat       = new System.Windows.Forms.ComboBox();
            labelDenoising       = new System.Windows.Forms.Label();
            comboBoxDenoising    = new System.Windows.Forms.ComboBox();
            labelScale           = new System.Windows.Forms.Label();
            comboBoxScale        = new System.Windows.Forms.ComboBox();
            buttonRun            = new System.Windows.Forms.Button();
            progressBar          = new System.Windows.Forms.ProgressBar();
            logListBox           = new System.Windows.Forms.ListBox();
            toolTip              = new System.Windows.Forms.ToolTip(components);
            groupBoxInput.SuspendLayout();
            groupBoxSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSave).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownUpscale).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLoad).BeginInit();
            SuspendLayout();
            // 
            // labelInput
            // 
            labelInput.AutoSize = true;
            labelInput.Location = new System.Drawing.Point(6, 101);
            labelInput.Name     = "labelInput";
            labelInput.Size     = new System.Drawing.Size(62, 30);
            labelInput.TabIndex = 0;
            labelInput.Text     = "Input";
            // 
            // textBoxInput
            // 
            textBoxInput.Anchor   = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            textBoxInput.Location = new System.Drawing.Point(143, 137);
            textBoxInput.Name     = "textBoxInput";
            textBoxInput.Size     = new System.Drawing.Size(603, 35);
            textBoxInput.TabIndex = 3;
            // 
            // buttonBrowseInput
            // 
            buttonBrowseInput.Location                =  new System.Drawing.Point(6, 134);
            buttonBrowseInput.Name                    =  "buttonBrowseInput";
            buttonBrowseInput.Size                    =  new System.Drawing.Size(131, 42);
            buttonBrowseInput.TabIndex                =  2;
            buttonBrowseInput.Text                    =  "Browse";
            buttonBrowseInput.UseVisualStyleBackColor =  true;
            buttonBrowseInput.Click                   += buttonBrowseInput_Click;
            // 
            // labelOutputSuffix
            // 
            labelOutputSuffix.AutoSize = true;
            labelOutputSuffix.Location = new System.Drawing.Point(6, 179);
            labelOutputSuffix.Name     = "labelOutputSuffix";
            labelOutputSuffix.Size     = new System.Drawing.Size(137, 30);
            labelOutputSuffix.TabIndex = 3;
            labelOutputSuffix.Text     = "Output Suffix";
            // 
            // textBoxOutputSuffix
            // 
            textBoxOutputSuffix.Anchor   = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            textBoxOutputSuffix.Location = new System.Drawing.Point(9, 215);
            textBoxOutputSuffix.Name     = "textBoxOutputSuffix";
            textBoxOutputSuffix.Size     = new System.Drawing.Size(737, 35);
            textBoxOutputSuffix.TabIndex = 4;
            toolTip.SetToolTip(textBoxOutputSuffix, "File/Folder output suffix");
            // 
            // groupBoxInput
            // 
            groupBoxInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            groupBoxInput.Controls.Add(radioButtonFile);
            groupBoxInput.Controls.Add(radioButtonFolder);
            groupBoxInput.Controls.Add(labelInputType);
            groupBoxInput.Controls.Add(buttonBrowseInput);
            groupBoxInput.Controls.Add(textBoxOutputSuffix);
            groupBoxInput.Controls.Add(labelInput);
            groupBoxInput.Controls.Add(textBoxInput);
            groupBoxInput.Controls.Add(labelOutputSuffix);
            groupBoxInput.Location = new System.Drawing.Point(12, 12);
            groupBoxInput.Name     = "groupBoxInput";
            groupBoxInput.Size     = new System.Drawing.Size(752, 266);
            groupBoxInput.TabIndex = 6;
            groupBoxInput.TabStop  = false;
            groupBoxInput.Text     = "Files";
            // 
            // radioButtonFile
            // 
            radioButtonFile.AutoSize                = true;
            radioButtonFile.Location                = new System.Drawing.Point(110, 64);
            radioButtonFile.Name                    = "radioButtonFile";
            radioButtonFile.Size                    = new System.Drawing.Size(69, 34);
            radioButtonFile.TabIndex                = 1;
            radioButtonFile.Text                    = "File";
            radioButtonFile.UseVisualStyleBackColor = true;
            // 
            // radioButtonFolder
            // 
            radioButtonFolder.AutoSize                = true;
            radioButtonFolder.Checked                 = true;
            radioButtonFolder.Location                = new System.Drawing.Point(9, 64);
            radioButtonFolder.Name                    = "radioButtonFolder";
            radioButtonFolder.Size                    = new System.Drawing.Size(95, 34);
            radioButtonFolder.TabIndex                = 0;
            radioButtonFolder.TabStop                 = true;
            radioButtonFolder.Text                    = "Folder";
            radioButtonFolder.UseVisualStyleBackColor = true;
            // 
            // labelInputType
            // 
            labelInputType.AutoSize = true;
            labelInputType.Location = new System.Drawing.Point(9, 31);
            labelInputType.Name     = "labelInputType";
            labelInputType.Size     = new System.Drawing.Size(111, 30);
            labelInputType.TabIndex = 6;
            labelInputType.Text     = "Input Type";
            // 
            // groupBoxSettings
            // 
            groupBoxSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            groupBoxSettings.Controls.Add(numericUpDownSave);
            groupBoxSettings.Controls.Add(numericUpDownUpscale);
            groupBoxSettings.Controls.Add(numericUpDownLoad);
            groupBoxSettings.Controls.Add(labelSaveThreads);
            groupBoxSettings.Controls.Add(labelUpscaleThreads);
            groupBoxSettings.Controls.Add(labelLoadThreads);
            groupBoxSettings.Controls.Add(checkBoxTTA);
            groupBoxSettings.Controls.Add(checkBoxGrayscale);
            groupBoxSettings.Controls.Add(labelFormat);
            groupBoxSettings.Controls.Add(comboBoxFormat);
            groupBoxSettings.Controls.Add(labelDenoising);
            groupBoxSettings.Controls.Add(comboBoxDenoising);
            groupBoxSettings.Controls.Add(labelScale);
            groupBoxSettings.Controls.Add(comboBoxScale);
            groupBoxSettings.Location = new System.Drawing.Point(12, 284);
            groupBoxSettings.Name     = "groupBoxSettings";
            groupBoxSettings.Size     = new System.Drawing.Size(752, 221);
            groupBoxSettings.TabIndex = 7;
            groupBoxSettings.TabStop  = false;
            groupBoxSettings.Text     = "Settings";
            // 
            // numericUpDownSave
            // 
            numericUpDownSave.Location = new System.Drawing.Point(495, 138);
            numericUpDownSave.Minimum  = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownSave.Name     = "numericUpDownSave";
            numericUpDownSave.Size     = new System.Drawing.Size(212, 35);
            numericUpDownSave.TabIndex = 15;
            toolTip.SetToolTip(numericUpDownSave, "Output GPU encode threads");
            numericUpDownSave.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // numericUpDownUpscale
            // 
            numericUpDownUpscale.Location = new System.Drawing.Point(252, 138);
            numericUpDownUpscale.Minimum  = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownUpscale.Name     = "numericUpDownUpscale";
            numericUpDownUpscale.Size     = new System.Drawing.Size(212, 35);
            numericUpDownUpscale.TabIndex = 14;
            toolTip.SetToolTip(numericUpDownUpscale, "Waifu2x GPU threads");
            numericUpDownUpscale.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // numericUpDownLoad
            // 
            numericUpDownLoad.Location = new System.Drawing.Point(9, 138);
            numericUpDownLoad.Minimum  = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownLoad.Name     = "numericUpDownLoad";
            numericUpDownLoad.Size     = new System.Drawing.Size(212, 35);
            numericUpDownLoad.TabIndex = 13;
            toolTip.SetToolTip(numericUpDownLoad, "Input GPU decode threads");
            numericUpDownLoad.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // labelSaveThreads
            // 
            labelSaveThreads.AutoSize = true;
            labelSaveThreads.Location = new System.Drawing.Point(495, 105);
            labelSaveThreads.Name     = "labelSaveThreads";
            labelSaveThreads.Size     = new System.Drawing.Size(160, 30);
            labelSaveThreads.TabIndex = 12;
            labelSaveThreads.Text     = "Encode Threads";
            // 
            // labelUpscaleThreads
            // 
            labelUpscaleThreads.AutoSize = true;
            labelUpscaleThreads.Location = new System.Drawing.Point(252, 105);
            labelUpscaleThreads.Name     = "labelUpscaleThreads";
            labelUpscaleThreads.Size     = new System.Drawing.Size(164, 30);
            labelUpscaleThreads.TabIndex = 11;
            labelUpscaleThreads.Text     = "Upscale Threads";
            // 
            // labelLoadThreads
            // 
            labelLoadThreads.AutoSize = true;
            labelLoadThreads.Location = new System.Drawing.Point(9, 105);
            labelLoadThreads.Name     = "labelLoadThreads";
            labelLoadThreads.Size     = new System.Drawing.Size(163, 30);
            labelLoadThreads.TabIndex = 10;
            labelLoadThreads.Text     = "Decode Threads";
            // 
            // checkBoxTTA
            // 
            checkBoxTTA.Location = new System.Drawing.Point(252, 182);
            checkBoxTTA.Name     = "checkBoxTTA";
            checkBoxTTA.Size     = new System.Drawing.Size(219, 29);
            checkBoxTTA.TabIndex = 9;
            checkBoxTTA.Text     = "TTA Mode";
            toolTip.SetToolTip(checkBoxTTA, "Might provide better results at the cost of extra processing time");
            checkBoxTTA.UseVisualStyleBackColor = true;
            // 
            // checkBoxGrayscale
            // 
            checkBoxGrayscale.AutoSize = true;
            checkBoxGrayscale.Location = new System.Drawing.Point(9, 179);
            checkBoxGrayscale.Name     = "checkBoxGrayscale";
            checkBoxGrayscale.Size     = new System.Drawing.Size(230, 34);
            checkBoxGrayscale.TabIndex = 8;
            checkBoxGrayscale.Text     = "Convert to Grayscale";
            toolTip.SetToolTip(checkBoxGrayscale, "Converts the output files to 8bpp grayscale images");
            checkBoxGrayscale.UseVisualStyleBackColor = true;
            // 
            // labelFormat
            // 
            labelFormat.AutoSize = true;
            labelFormat.Location = new System.Drawing.Point(495, 31);
            labelFormat.Name     = "labelFormat";
            labelFormat.Size     = new System.Drawing.Size(78, 30);
            labelFormat.TabIndex = 5;
            labelFormat.Text     = "Format";
            // 
            // comboBoxFormat
            // 
            comboBoxFormat.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxFormat.FormattingEnabled = true;
            comboBoxFormat.Items.AddRange(new object[] { "PNG", "JPG", "WEBP" });
            comboBoxFormat.Location = new System.Drawing.Point(495, 64);
            comboBoxFormat.Name     = "comboBoxFormat";
            comboBoxFormat.Size     = new System.Drawing.Size(212, 38);
            comboBoxFormat.TabIndex = 7;
            toolTip.SetToolTip(comboBoxFormat, "Output file format");
            // 
            // labelDenoising
            // 
            labelDenoising.AutoSize = true;
            labelDenoising.Location = new System.Drawing.Point(252, 31);
            labelDenoising.Name     = "labelDenoising";
            labelDenoising.Size     = new System.Drawing.Size(106, 30);
            labelDenoising.TabIndex = 3;
            labelDenoising.Text     = "Denoising";
            // 
            // comboBoxDenoising
            // 
            comboBoxDenoising.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxDenoising.FormattingEnabled = true;
            comboBoxDenoising.Items.AddRange(new object[] { "0", "1", "2", "3" });
            comboBoxDenoising.Location = new System.Drawing.Point(252, 64);
            comboBoxDenoising.Name     = "comboBoxDenoising";
            comboBoxDenoising.Size     = new System.Drawing.Size(212, 38);
            comboBoxDenoising.TabIndex = 6;
            toolTip.SetToolTip(comboBoxDenoising, "Denoising level, higher is better");
            // 
            // labelScale
            // 
            labelScale.AutoSize = true;
            labelScale.Location = new System.Drawing.Point(6, 31);
            labelScale.Name     = "labelScale";
            labelScale.Size     = new System.Drawing.Size(61, 30);
            labelScale.TabIndex = 1;
            labelScale.Text     = "Scale";
            // 
            // comboBoxScale
            // 
            comboBoxScale.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxScale.FormattingEnabled = true;
            comboBoxScale.Items.AddRange(new object[] { "1", "2", "4", "8", "16", "32" });
            comboBoxScale.Location = new System.Drawing.Point(9, 64);
            comboBoxScale.Name     = "comboBoxScale";
            comboBoxScale.Size     = new System.Drawing.Size(212, 38);
            comboBoxScale.TabIndex = 5;
            toolTip.SetToolTip(comboBoxScale, "Image upscale factor");
            // 
            // buttonRun
            // 
            buttonRun.Anchor                  =  ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            buttonRun.Location                =  new System.Drawing.Point(12, 708);
            buttonRun.Name                    =  "buttonRun";
            buttonRun.Size                    =  new System.Drawing.Size(752, 80);
            buttonRun.TabIndex                =  9;
            buttonRun.Text                    =  "Run";
            buttonRun.UseVisualStyleBackColor =  true;
            buttonRun.Click                   += buttonRun_Click;
            // 
            // progressBar
            // 
            progressBar.Anchor                = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            progressBar.Location              = new System.Drawing.Point(12, 794);
            progressBar.MarqueeAnimationSpeed = 30;
            progressBar.Name                  = "progressBar";
            progressBar.Size                  = new System.Drawing.Size(752, 30);
            progressBar.Step                  = 1;
            progressBar.Style                 = System.Windows.Forms.ProgressBarStyle.Continuous;
            progressBar.TabIndex              = 11;
            // 
            // logListBox
            // 
            logListBox.Anchor              = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            logListBox.FormattingEnabled   = true;
            logListBox.HorizontalScrollbar = true;
            logListBox.IntegralHeight      = false;
            logListBox.ItemHeight          = 30;
            logListBox.Location            = new System.Drawing.Point(21, 511);
            logListBox.Name                = "logListBox";
            logListBox.SelectionMode       = System.Windows.Forms.SelectionMode.None;
            logListBox.Size                = new System.Drawing.Size(737, 191);
            logListBox.TabIndex            = 12;
            // 
            // toolTip
            // 
            toolTip.AutomaticDelay = 1000;
            // 
            // WaifuForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize          = new System.Drawing.Size(776, 836);
            Controls.Add(logListBox);
            Controls.Add(progressBar);
            Controls.Add(buttonRun);
            Controls.Add(groupBoxSettings);
            Controls.Add(groupBoxInput);
            Icon        =  ((System.Drawing.Icon)resources.GetObject("$this.Icon"));
            MinimumSize =  new System.Drawing.Size(800, 900);
            Text        =  "Waifu2x";
            FormClosed  += WaifuForm_FormClosed;
            groupBoxInput.ResumeLayout(false);
            groupBoxInput.PerformLayout();
            groupBoxSettings.ResumeLayout(false);
            groupBoxSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSave).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownUpscale).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLoad).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.ToolTip toolTip;

        private System.Windows.Forms.NumericUpDown numericUpDownLoad;
        private System.Windows.Forms.NumericUpDown numericUpDownSave;

        private System.Windows.Forms.NumericUpDown numericUpDownUpscale;

        private System.Windows.Forms.Label labelSaveThreads;

        private System.Windows.Forms.Label labelUpscaleThreads;

        private System.Windows.Forms.Label labelLoadThreads;

        private System.Windows.Forms.CheckBox checkBoxTTA;

        private System.Windows.Forms.ListBox logListBox;
        #endregion
        private FolderBrowserDialog folderBrowserInput;
        private Label labelInput;
        private System.Windows.Forms.TextBox textBoxInput;
        private Button buttonBrowseInput;
        private Label labelOutputSuffix;
        private System.Windows.Forms.TextBox textBoxOutputSuffix;
        private System.Windows.Forms.GroupBox groupBoxInput;
        private RadioButton radioButtonFile;
        private RadioButton radioButtonFolder;
        private Label labelInputType;
        private OpenFileDialog openFileInput;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.ComboBox comboBoxScale;
        private Label labelFormat;
        private System.Windows.Forms.ComboBox comboBoxFormat;
        private Label labelDenoising;
        private System.Windows.Forms.ComboBox comboBoxDenoising;
        private Label labelScale;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.CheckBox checkBoxGrayscale;
    }
}