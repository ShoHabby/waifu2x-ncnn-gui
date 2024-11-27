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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaifuForm));
            folderBrowserInput  = new System.Windows.Forms.FolderBrowserDialog();
            labelInput          = new System.Windows.Forms.Label();
            textBoxInput        = new System.Windows.Forms.TextBox();
            buttonBrowseInput   = new System.Windows.Forms.Button();
            labelOutputSuffix   = new System.Windows.Forms.Label();
            textBoxOutputSuffix = new System.Windows.Forms.TextBox();
            groupBoxInput       = new System.Windows.Forms.GroupBox();
            radioButtonFile     = new System.Windows.Forms.RadioButton();
            radioButtonFolder   = new System.Windows.Forms.RadioButton();
            labelInputType      = new System.Windows.Forms.Label();
            openFileInput       = new System.Windows.Forms.OpenFileDialog();
            groupBoxSettings    = new System.Windows.Forms.GroupBox();
            checkBoxGrayscale   = new System.Windows.Forms.CheckBox();
            labelFormat         = new System.Windows.Forms.Label();
            comboBoxFormat      = new System.Windows.Forms.ComboBox();
            labelDenoising      = new System.Windows.Forms.Label();
            comboBoxDenoising   = new System.Windows.Forms.ComboBox();
            labelScale          = new System.Windows.Forms.Label();
            comboBoxScale       = new System.Windows.Forms.ComboBox();
            buttonRun           = new System.Windows.Forms.Button();
            progressBar         = new System.Windows.Forms.ProgressBar();
            logListBox          = new System.Windows.Forms.ListBox();
            groupBoxInput.SuspendLayout();
            groupBoxSettings.SuspendLayout();
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
            groupBoxSettings.Controls.Add(checkBoxGrayscale);
            groupBoxSettings.Controls.Add(labelFormat);
            groupBoxSettings.Controls.Add(comboBoxFormat);
            groupBoxSettings.Controls.Add(labelDenoising);
            groupBoxSettings.Controls.Add(comboBoxDenoising);
            groupBoxSettings.Controls.Add(labelScale);
            groupBoxSettings.Controls.Add(comboBoxScale);
            groupBoxSettings.Location = new System.Drawing.Point(12, 284);
            groupBoxSettings.Name     = "groupBoxSettings";
            groupBoxSettings.Size     = new System.Drawing.Size(752, 149);
            groupBoxSettings.TabIndex = 7;
            groupBoxSettings.TabStop  = false;
            groupBoxSettings.Text     = "Settings";
            // 
            // checkBoxGrayscale
            // 
            checkBoxGrayscale.AutoSize                = true;
            checkBoxGrayscale.Location                = new System.Drawing.Point(9, 108);
            checkBoxGrayscale.Name                    = "checkBoxGrayscale";
            checkBoxGrayscale.Size                    = new System.Drawing.Size(230, 34);
            checkBoxGrayscale.TabIndex                = 8;
            checkBoxGrayscale.Text                    = "Convert to Grayscale";
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
            // 
            // buttonRun
            // 
            buttonRun.Anchor                  =  ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            buttonRun.Location                =  new System.Drawing.Point(12, 658);
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
            progressBar.Location              = new System.Drawing.Point(12, 744);
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
            logListBox.Location            = new System.Drawing.Point(21, 439);
            logListBox.Name                = "logListBox";
            logListBox.SelectionMode       = System.Windows.Forms.SelectionMode.None;
            logListBox.Size                = new System.Drawing.Size(737, 213);
            logListBox.TabIndex            = 12;
            // 
            // WaifuForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize          = new System.Drawing.Size(776, 786);
            Controls.Add(logListBox);
            Controls.Add(progressBar);
            Controls.Add(buttonRun);
            Controls.Add(groupBoxSettings);
            Controls.Add(groupBoxInput);
            Icon        =  ((System.Drawing.Icon)resources.GetObject("$this.Icon"));
            MaximumSize =  new System.Drawing.Size(1200, 1200);
            MinimumSize =  new System.Drawing.Size(800, 850);
            Text        =  "Waifu2x";
            FormClosed  += WaifuForm_FormClosed;
            groupBoxInput.ResumeLayout(false);
            groupBoxInput.PerformLayout();
            groupBoxSettings.ResumeLayout(false);
            groupBoxSettings.PerformLayout();
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