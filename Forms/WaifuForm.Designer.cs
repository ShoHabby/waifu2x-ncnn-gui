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
            this.folderBrowserInput  = new System.Windows.Forms.FolderBrowserDialog();
            this.labelInput          = new System.Windows.Forms.Label();
            this.textBoxInput        = new System.Windows.Forms.TextBox();
            this.buttonBrowseInput   = new System.Windows.Forms.Button();
            this.labelOutputSuffix   = new System.Windows.Forms.Label();
            this.textBoxOutputSuffix = new System.Windows.Forms.TextBox();
            this.groupBoxInput       = new System.Windows.Forms.GroupBox();
            this.radioButtonFile     = new System.Windows.Forms.RadioButton();
            this.radioButtonFolder   = new System.Windows.Forms.RadioButton();
            this.labelInputType      = new System.Windows.Forms.Label();
            this.openFileInput       = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxSettings    = new System.Windows.Forms.GroupBox();
            this.checkBoxGrayscale   = new System.Windows.Forms.CheckBox();
            this.labelFormat         = new System.Windows.Forms.Label();
            this.comboBoxFormat      = new System.Windows.Forms.ComboBox();
            this.labelDenoising      = new System.Windows.Forms.Label();
            this.comboBoxDenoising   = new System.Windows.Forms.ComboBox();
            this.labelScale          = new System.Windows.Forms.Label();
            this.comboBoxScale       = new System.Windows.Forms.ComboBox();
            this.buttonRun           = new System.Windows.Forms.Button();
            this.progressBar         = new System.Windows.Forms.ProgressBar();
            this.logListBox          = new System.Windows.Forms.ListBox();
            this.groupBoxInput.SuspendLayout();
            this.groupBoxSettings.SuspendLayout();
            SuspendLayout();
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.Location = new System.Drawing.Point(6, 101);
            this.labelInput.Name     = "labelInput";
            this.labelInput.Size     = new System.Drawing.Size(62, 30);
            this.labelInput.TabIndex = 0;
            this.labelInput.Text     = "Input";
            // 
            // textBoxInput
            // 
            this.textBoxInput.Anchor   = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.textBoxInput.Location = new System.Drawing.Point(143, 137);
            this.textBoxInput.Name     = "textBoxInput";
            this.textBoxInput.Size     = new System.Drawing.Size(603, 35);
            this.textBoxInput.TabIndex = 3;
            // 
            // buttonBrowseInput
            // 
            this.buttonBrowseInput.Location                =  new System.Drawing.Point(6, 134);
            this.buttonBrowseInput.Name                    =  "buttonBrowseInput";
            this.buttonBrowseInput.Size                    =  new System.Drawing.Size(131, 42);
            this.buttonBrowseInput.TabIndex                =  2;
            this.buttonBrowseInput.Text                    =  "Browse";
            this.buttonBrowseInput.UseVisualStyleBackColor =  true;
            this.buttonBrowseInput.Click                   += buttonBrowseInput_Click;
            // 
            // labelOutputSuffix
            // 
            this.labelOutputSuffix.AutoSize = true;
            this.labelOutputSuffix.Location = new System.Drawing.Point(6, 179);
            this.labelOutputSuffix.Name     = "labelOutputSuffix";
            this.labelOutputSuffix.Size     = new System.Drawing.Size(137, 30);
            this.labelOutputSuffix.TabIndex = 3;
            this.labelOutputSuffix.Text     = "Output Suffix";
            // 
            // textBoxOutputSuffix
            // 
            this.textBoxOutputSuffix.Anchor   = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.textBoxOutputSuffix.Location = new System.Drawing.Point(9, 215);
            this.textBoxOutputSuffix.Name     = "textBoxOutputSuffix";
            this.textBoxOutputSuffix.Size     = new System.Drawing.Size(737, 35);
            this.textBoxOutputSuffix.TabIndex = 4;
            // 
            // groupBoxInput
            // 
            this.groupBoxInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.groupBoxInput.Controls.Add(this.radioButtonFile);
            this.groupBoxInput.Controls.Add(this.radioButtonFolder);
            this.groupBoxInput.Controls.Add(this.labelInputType);
            this.groupBoxInput.Controls.Add(this.buttonBrowseInput);
            this.groupBoxInput.Controls.Add(this.textBoxOutputSuffix);
            this.groupBoxInput.Controls.Add(this.labelInput);
            this.groupBoxInput.Controls.Add(this.textBoxInput);
            this.groupBoxInput.Controls.Add(this.labelOutputSuffix);
            this.groupBoxInput.Location = new System.Drawing.Point(12, 12);
            this.groupBoxInput.Name     = "groupBoxInput";
            this.groupBoxInput.Size     = new System.Drawing.Size(752, 266);
            this.groupBoxInput.TabIndex = 6;
            this.groupBoxInput.TabStop  = false;
            this.groupBoxInput.Text     = "Files";
            // 
            // radioButtonFile
            // 
            this.radioButtonFile.AutoSize                = true;
            this.radioButtonFile.Location                = new System.Drawing.Point(110, 64);
            this.radioButtonFile.Name                    = "radioButtonFile";
            this.radioButtonFile.Size                    = new System.Drawing.Size(69, 34);
            this.radioButtonFile.TabIndex                = 1;
            this.radioButtonFile.Text                    = "File";
            this.radioButtonFile.UseVisualStyleBackColor = true;
            // 
            // radioButtonFolder
            // 
            this.radioButtonFolder.AutoSize                = true;
            this.radioButtonFolder.Checked                 = true;
            this.radioButtonFolder.Location                = new System.Drawing.Point(9, 64);
            this.radioButtonFolder.Name                    = "radioButtonFolder";
            this.radioButtonFolder.Size                    = new System.Drawing.Size(95, 34);
            this.radioButtonFolder.TabIndex                = 0;
            this.radioButtonFolder.TabStop                 = true;
            this.radioButtonFolder.Text                    = "Folder";
            this.radioButtonFolder.UseVisualStyleBackColor = true;
            // 
            // labelInputType
            // 
            this.labelInputType.AutoSize = true;
            this.labelInputType.Location = new System.Drawing.Point(9, 31);
            this.labelInputType.Name     = "labelInputType";
            this.labelInputType.Size     = new System.Drawing.Size(111, 30);
            this.labelInputType.TabIndex = 6;
            this.labelInputType.Text     = "Input Type";
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.groupBoxSettings.Controls.Add(this.checkBoxGrayscale);
            this.groupBoxSettings.Controls.Add(this.labelFormat);
            this.groupBoxSettings.Controls.Add(this.comboBoxFormat);
            this.groupBoxSettings.Controls.Add(this.labelDenoising);
            this.groupBoxSettings.Controls.Add(this.comboBoxDenoising);
            this.groupBoxSettings.Controls.Add(this.labelScale);
            this.groupBoxSettings.Controls.Add(this.comboBoxScale);
            this.groupBoxSettings.Location = new System.Drawing.Point(12, 284);
            this.groupBoxSettings.Name     = "groupBoxSettings";
            this.groupBoxSettings.Size     = new System.Drawing.Size(752, 149);
            this.groupBoxSettings.TabIndex = 7;
            this.groupBoxSettings.TabStop  = false;
            this.groupBoxSettings.Text     = "Settings";
            // 
            // checkBoxGrayscale
            // 
            this.checkBoxGrayscale.AutoSize                = true;
            this.checkBoxGrayscale.Location                = new System.Drawing.Point(9, 108);
            this.checkBoxGrayscale.Name                    = "checkBoxGrayscale";
            this.checkBoxGrayscale.Size                    = new System.Drawing.Size(230, 34);
            this.checkBoxGrayscale.TabIndex                = 8;
            this.checkBoxGrayscale.Text                    = "Convert to Grayscale";
            this.checkBoxGrayscale.UseVisualStyleBackColor = true;
            // 
            // labelFormat
            // 
            this.labelFormat.AutoSize = true;
            this.labelFormat.Location = new System.Drawing.Point(495, 31);
            this.labelFormat.Name     = "labelFormat";
            this.labelFormat.Size     = new System.Drawing.Size(78, 30);
            this.labelFormat.TabIndex = 5;
            this.labelFormat.Text     = "Format";
            // 
            // comboBoxFormat
            // 
            this.comboBoxFormat.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFormat.FormattingEnabled = true;
            this.comboBoxFormat.Items.AddRange(new object[] { "PNG", "JPG", "WEBP" });
            this.comboBoxFormat.Location = new System.Drawing.Point(495, 64);
            this.comboBoxFormat.Name     = "comboBoxFormat";
            this.comboBoxFormat.Size     = new System.Drawing.Size(212, 38);
            this.comboBoxFormat.TabIndex = 7;
            // 
            // labelDenoising
            // 
            this.labelDenoising.AutoSize = true;
            this.labelDenoising.Location = new System.Drawing.Point(252, 31);
            this.labelDenoising.Name     = "labelDenoising";
            this.labelDenoising.Size     = new System.Drawing.Size(106, 30);
            this.labelDenoising.TabIndex = 3;
            this.labelDenoising.Text     = "Denoising";
            // 
            // comboBoxDenoising
            // 
            this.comboBoxDenoising.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDenoising.FormattingEnabled = true;
            this.comboBoxDenoising.Items.AddRange(new object[] { "0", "1", "2", "3" });
            this.comboBoxDenoising.Location = new System.Drawing.Point(252, 64);
            this.comboBoxDenoising.Name     = "comboBoxDenoising";
            this.comboBoxDenoising.Size     = new System.Drawing.Size(212, 38);
            this.comboBoxDenoising.TabIndex = 6;
            // 
            // labelScale
            // 
            this.labelScale.AutoSize = true;
            this.labelScale.Location = new System.Drawing.Point(6, 31);
            this.labelScale.Name     = "labelScale";
            this.labelScale.Size     = new System.Drawing.Size(61, 30);
            this.labelScale.TabIndex = 1;
            this.labelScale.Text     = "Scale";
            // 
            // comboBoxScale
            // 
            this.comboBoxScale.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxScale.FormattingEnabled = true;
            this.comboBoxScale.Items.AddRange(new object[] { "1", "2", "4", "8", "16", "32" });
            this.comboBoxScale.Location = new System.Drawing.Point(9, 64);
            this.comboBoxScale.Name     = "comboBoxScale";
            this.comboBoxScale.Size     = new System.Drawing.Size(212, 38);
            this.comboBoxScale.TabIndex = 5;
            // 
            // buttonRun
            // 
            this.buttonRun.Anchor                  =  ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.buttonRun.Location                =  new System.Drawing.Point(12, 707);
            this.buttonRun.Name                    =  "buttonRun";
            this.buttonRun.Size                    =  new System.Drawing.Size(752, 80);
            this.buttonRun.TabIndex                =  9;
            this.buttonRun.Text                    =  "Run";
            this.buttonRun.UseVisualStyleBackColor =  true;
            this.buttonRun.Click                   += buttonRun_Click;
            // 
            // progressBar
            // 
            this.progressBar.Anchor                = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.progressBar.Location              = new System.Drawing.Point(12, 793);
            this.progressBar.MarqueeAnimationSpeed = 30;
            this.progressBar.Name                  = "progressBar";
            this.progressBar.Size                  = new System.Drawing.Size(752, 30);
            this.progressBar.Step                  = 1;
            this.progressBar.Style                 = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex              = 11;
            // 
            // logListBox
            // 
            this.logListBox.Anchor            = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.logListBox.FormattingEnabled = true;
            this.logListBox.IntegralHeight    = false;
            this.logListBox.ItemHeight        = 30;
            this.logListBox.Location          = new System.Drawing.Point(21, 439);
            this.logListBox.Name              = "logListBox";
            this.logListBox.SelectionMode     = System.Windows.Forms.SelectionMode.None;
            this.logListBox.Size              = new System.Drawing.Size(737, 262);
            this.logListBox.TabIndex          = 12;
            // 
            // WaifuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(776, 835);
            this.Controls.Add(this.logListBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.groupBoxSettings);
            this.Controls.Add(this.groupBoxInput);
            this.MaximumSize =  new System.Drawing.Size(1200, 1200);
            this.MinimumSize =  new System.Drawing.Size(800, 750);
            this.Text        =  "Waifu2x";
            FormClosed       += WaifuForm_FormClosed;
            this.groupBoxInput.ResumeLayout(false);
            this.groupBoxInput.PerformLayout();
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            ResumeLayout(false);
        }

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
        private ComboBox comboBoxScale;
        private Label labelFormat;
        private ComboBox comboBoxFormat;
        private Label labelDenoising;
        private ComboBox comboBoxDenoising;
        private Label labelScale;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.ProgressBar progressBar;
        private CheckBox checkBoxGrayscale;
    }
}