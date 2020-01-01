namespace RSImage
{
    partial class FrmCut
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.WidthLabel = new System.Windows.Forms.Label();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.WidthNumericSelector = new RSImage.CommonControls.NumericSelector();
            this.HeightNumericSelector = new RSImage.CommonControls.NumericSelector();
            this.CConfirmAbortButtons1 = new RSImage.CommonControls.ConfirmAbortButtons();
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.PathLabel = new System.Windows.Forms.Label();
            this.PathButton = new System.Windows.Forms.Button();
            this.InputGroupBox = new System.Windows.Forms.GroupBox();
            this.CutGroupBox = new System.Windows.Forms.GroupBox();
            this.InputGroupBox.SuspendLayout();
            this.CutGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(6, 18);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(79, 13);
            this.WidthLabel.TabIndex = 0;
            this.WidthLabel.Text = "输入影像宽：";
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(6, 48);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(79, 13);
            this.HeightLabel.TabIndex = 0;
            this.HeightLabel.Text = "输入影像高：";
            // 
            // WidthNumericSelector
            // 
            this.WidthNumericSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WidthNumericSelector.Location = new System.Drawing.Point(6, 11);
            this.WidthNumericSelector.Max = 32767;
            this.WidthNumericSelector.Min = 1;
            this.WidthNumericSelector.MinimumSize = new System.Drawing.Size(100, 27);
            this.WidthNumericSelector.Name = "WidthNumericSelector";
            this.WidthNumericSelector.Size = new System.Drawing.Size(160, 27);
            this.WidthNumericSelector.TabIndex = 0;
            this.WidthNumericSelector.Title = "裁剪影像宽度";
            this.WidthNumericSelector.Value = 1;
            // 
            // HeightNumericSelector
            // 
            this.HeightNumericSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HeightNumericSelector.Location = new System.Drawing.Point(6, 43);
            this.HeightNumericSelector.Max = 32767;
            this.HeightNumericSelector.Min = 1;
            this.HeightNumericSelector.MinimumSize = new System.Drawing.Size(100, 27);
            this.HeightNumericSelector.Name = "HeightNumericSelector";
            this.HeightNumericSelector.Size = new System.Drawing.Size(160, 27);
            this.HeightNumericSelector.TabIndex = 1;
            this.HeightNumericSelector.Title = "裁剪影像高度";
            this.HeightNumericSelector.Value = 1;
            // 
            // CConfirmAbortButtons1
            // 
            this.CConfirmAbortButtons1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CConfirmAbortButtons1.Location = new System.Drawing.Point(231, 149);
            this.CConfirmAbortButtons1.MinimumSize = new System.Drawing.Size(120, 25);
            this.CConfirmAbortButtons1.Name = "CConfirmAbortButtons1";
            this.CConfirmAbortButtons1.Size = new System.Drawing.Size(130, 28);
            this.CConfirmAbortButtons1.TabIndex = 4;
            this.CConfirmAbortButtons1.ConfirmBtnClick += new RSImage.CommonControls.ConfirmAbortButtons.ConfirmBtnClickEventHander(this.CConfirmAbortButtons1_ConfirmBtnClick);
            this.CConfirmAbortButtons1.AbortBtnClick += new RSImage.CommonControls.ConfirmAbortButtons.AbortBtnClickEventHander(this.CConfirmAbortButtons1_AbortBtnClick);
            // 
            // PathTextBox
            // 
            this.PathTextBox.Location = new System.Drawing.Point(88, 108);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.Size = new System.Drawing.Size(208, 20);
            this.PathTextBox.TabIndex = 3;
            this.PathTextBox.TextChanged += new System.EventHandler(this.PathTextBox_TextChanged);
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Location = new System.Drawing.Point(15, 111);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(67, 13);
            this.PathLabel.TabIndex = 0;
            this.PathLabel.Text = "输出目录：";
            // 
            // PathButton
            // 
            this.PathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PathButton.Location = new System.Drawing.Point(302, 106);
            this.PathButton.Name = "PathButton";
            this.PathButton.Size = new System.Drawing.Size(59, 25);
            this.PathButton.TabIndex = 2;
            this.PathButton.Text = "浏览";
            this.PathButton.UseVisualStyleBackColor = true;
            this.PathButton.Click += new System.EventHandler(this.PathButton_Click);
            // 
            // InputGroupBox
            // 
            this.InputGroupBox.Controls.Add(this.WidthLabel);
            this.InputGroupBox.Controls.Add(this.HeightLabel);
            this.InputGroupBox.Location = new System.Drawing.Point(12, 12);
            this.InputGroupBox.Name = "InputGroupBox";
            this.InputGroupBox.Size = new System.Drawing.Size(171, 76);
            this.InputGroupBox.TabIndex = 0;
            this.InputGroupBox.TabStop = false;
            // 
            // CutGroupBox
            // 
            this.CutGroupBox.Controls.Add(this.WidthNumericSelector);
            this.CutGroupBox.Controls.Add(this.HeightNumericSelector);
            this.CutGroupBox.Location = new System.Drawing.Point(189, 12);
            this.CutGroupBox.Name = "CutGroupBox";
            this.CutGroupBox.Size = new System.Drawing.Size(172, 76);
            this.CutGroupBox.TabIndex = 6;
            this.CutGroupBox.TabStop = false;
            // 
            // FrmCut
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(373, 189);
            this.Controls.Add(this.CutGroupBox);
            this.Controls.Add(this.InputGroupBox);
            this.Controls.Add(this.PathButton);
            this.Controls.Add(this.PathTextBox);
            this.Controls.Add(this.CConfirmAbortButtons1);
            this.Controls.Add(this.PathLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(389, 228);
            this.Name = "FrmCut";
            this.Text = "影像裁剪";
            this.InputGroupBox.ResumeLayout(false);
            this.InputGroupBox.PerformLayout();
            this.CutGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.Label HeightLabel;
        private CommonControls.NumericSelector WidthNumericSelector;
        private CommonControls.NumericSelector HeightNumericSelector;
        private CommonControls.ConfirmAbortButtons CConfirmAbortButtons1;
        private System.Windows.Forms.TextBox PathTextBox;
        private System.Windows.Forms.Label PathLabel;
        private System.Windows.Forms.Button PathButton;
        private System.Windows.Forms.GroupBox InputGroupBox;
        private System.Windows.Forms.GroupBox CutGroupBox;
    }
}