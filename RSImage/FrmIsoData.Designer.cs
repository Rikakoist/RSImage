namespace RSImage
{
    partial class FrmIsoData
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
            this.NumberOfClassLabel = new System.Windows.Forms.Label();
            this.NumberOfClassGroupBox = new System.Windows.Forms.GroupBox();
            this.MaxKindNumericSelector = new RSImage.CommonControls.NumericSelector();
            this.MinKindNumericSelector = new RSImage.CommonControls.NumericSelector();
            this.MinPixCountNumericSelector = new RSImage.CommonControls.NumericSelector();
            this.IteraNumericSelector = new RSImage.CommonControls.NumericSelector();
            this.DifValueSelector = new RSImage.CommonControls.ValueSelector();
            this.IDConfirmAbortButtons = new RSImage.CommonControls.ConfirmAbortButtons();
            this.IDFilePathSelector = new RSImage.FilePathSelector();
            this.MaxClassStddevLabel = new System.Windows.Forms.Label();
            this.MinClassDisLabel = new System.Windows.Forms.Label();
            this.MaxClassStddevTextBox = new System.Windows.Forms.TextBox();
            this.MinClassDisTextBox = new System.Windows.Forms.TextBox();
            this.NumberOfClassGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // NumberOfClassLabel
            // 
            this.NumberOfClassLabel.AutoSize = true;
            this.NumberOfClassLabel.Location = new System.Drawing.Point(6, 16);
            this.NumberOfClassLabel.Name = "NumberOfClassLabel";
            this.NumberOfClassLabel.Size = new System.Drawing.Size(43, 13);
            this.NumberOfClassLabel.TabIndex = 0;
            this.NumberOfClassLabel.Text = "类数：";
            // 
            // NumberOfClassGroupBox
            // 
            this.NumberOfClassGroupBox.Controls.Add(this.MaxKindNumericSelector);
            this.NumberOfClassGroupBox.Controls.Add(this.MinKindNumericSelector);
            this.NumberOfClassGroupBox.Controls.Add(this.NumberOfClassLabel);
            this.NumberOfClassGroupBox.Location = new System.Drawing.Point(12, 12);
            this.NumberOfClassGroupBox.Name = "NumberOfClassGroupBox";
            this.NumberOfClassGroupBox.Size = new System.Drawing.Size(258, 43);
            this.NumberOfClassGroupBox.TabIndex = 0;
            this.NumberOfClassGroupBox.TabStop = false;
            // 
            // MaxKindNumericSelector
            // 
            this.MaxKindNumericSelector.Location = new System.Drawing.Point(136, 10);
            this.MaxKindNumericSelector.Max = 100;
            this.MaxKindNumericSelector.Min = 1;
            this.MaxKindNumericSelector.MinimumSize = new System.Drawing.Size(105, 27);
            this.MaxKindNumericSelector.Name = "MaxKindNumericSelector";
            this.MaxKindNumericSelector.Size = new System.Drawing.Size(120, 27);
            this.MaxKindNumericSelector.TabIndex = 1;
            this.MaxKindNumericSelector.Title = "最大";
            this.MaxKindNumericSelector.Value = 1;
            // 
            // MinKindNumericSelector
            // 
            this.MinKindNumericSelector.Location = new System.Drawing.Point(43, 10);
            this.MinKindNumericSelector.Max = 100;
            this.MinKindNumericSelector.Min = 1;
            this.MinKindNumericSelector.MinimumSize = new System.Drawing.Size(105, 27);
            this.MinKindNumericSelector.Name = "MinKindNumericSelector";
            this.MinKindNumericSelector.Size = new System.Drawing.Size(105, 27);
            this.MinKindNumericSelector.TabIndex = 0;
            this.MinKindNumericSelector.Title = "最小";
            this.MinKindNumericSelector.Value = 1;
            // 
            // MinPixCountNumericSelector
            // 
            this.MinPixCountNumericSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MinPixCountNumericSelector.Location = new System.Drawing.Point(12, 155);
            this.MinPixCountNumericSelector.Max = 32767;
            this.MinPixCountNumericSelector.Min = 1;
            this.MinPixCountNumericSelector.MinimumSize = new System.Drawing.Size(100, 27);
            this.MinPixCountNumericSelector.Name = "MinPixCountNumericSelector";
            this.MinPixCountNumericSelector.Size = new System.Drawing.Size(190, 27);
            this.MinPixCountNumericSelector.TabIndex = 7;
            this.MinPixCountNumericSelector.Title = "最小类内像素数量";
            this.MinPixCountNumericSelector.Value = 1;
            // 
            // IteraNumericSelector
            // 
            this.IteraNumericSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IteraNumericSelector.Location = new System.Drawing.Point(12, 61);
            this.IteraNumericSelector.Max = 32767;
            this.IteraNumericSelector.Min = 1;
            this.IteraNumericSelector.MinimumSize = new System.Drawing.Size(149, 27);
            this.IteraNumericSelector.Name = "IteraNumericSelector";
            this.IteraNumericSelector.Size = new System.Drawing.Size(175, 27);
            this.IteraNumericSelector.TabIndex = 6;
            this.IteraNumericSelector.Title = "最大迭代次数";
            this.IteraNumericSelector.Value = 1;
            // 
            // DifValueSelector
            // 
            this.DifValueSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DifValueSelector.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DifValueSelector.Location = new System.Drawing.Point(12, 95);
            this.DifValueSelector.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DifValueSelector.Max = 100D;
            this.DifValueSelector.Min = 0D;
            this.DifValueSelector.MinimumSize = new System.Drawing.Size(364, 53);
            this.DifValueSelector.Name = "DifValueSelector";
            this.DifValueSelector.Ratio = 1D;
            this.DifValueSelector.Size = new System.Drawing.Size(386, 53);
            this.DifValueSelector.TabIndex = 4;
            this.DifValueSelector.Title = "改变阈值(%)";
            this.DifValueSelector.Value = 5D;
            // 
            // IDConfirmAbortButtons
            // 
            this.IDConfirmAbortButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.IDConfirmAbortButtons.Location = new System.Drawing.Point(12, 394);
            this.IDConfirmAbortButtons.MinimumSize = new System.Drawing.Size(120, 25);
            this.IDConfirmAbortButtons.Name = "IDConfirmAbortButtons";
            this.IDConfirmAbortButtons.Size = new System.Drawing.Size(120, 25);
            this.IDConfirmAbortButtons.TabIndex = 5;
            this.IDConfirmAbortButtons.ConfirmBtnClick += new RSImage.CommonControls.ConfirmAbortButtons.ConfirmBtnClickEventHander(this.IDConfirmAbortButtons_ConfirmBtnClick);
            this.IDConfirmAbortButtons.AbortBtnClick += new RSImage.CommonControls.ConfirmAbortButtons.AbortBtnClickEventHander(this.IDConfirmAbortButtons_AbortBtnClick);
            // 
            // IDFilePathSelector
            // 
            this.IDFilePathSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IDFilePathSelector.Filter = "All files|*.*";
            this.IDFilePathSelector.FilterIndex = 1;
            this.IDFilePathSelector.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDFilePathSelector.Location = new System.Drawing.Point(12, 259);
            this.IDFilePathSelector.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.IDFilePathSelector.MinimumSize = new System.Drawing.Size(290, 110);
            this.IDFilePathSelector.Name = "IDFilePathSelector";
            this.IDFilePathSelector.OutDataType = OSGeo.GDAL.DataType.GDT_Byte;
            this.IDFilePathSelector.Path = null;
            this.IDFilePathSelector.Size = new System.Drawing.Size(296, 115);
            this.IDFilePathSelector.TabIndex = 3;
            this.IDFilePathSelector.Title = "选择保存位置";
            this.IDFilePathSelector.WorkFolder = "MyDocuments";
            // 
            // MaxClassStddevLabel
            // 
            this.MaxClassStddevLabel.AutoSize = true;
            this.MaxClassStddevLabel.Location = new System.Drawing.Point(18, 202);
            this.MaxClassStddevLabel.Name = "MaxClassStddevLabel";
            this.MaxClassStddevLabel.Size = new System.Drawing.Size(79, 13);
            this.MaxClassStddevLabel.TabIndex = 8;
            this.MaxClassStddevLabel.Text = "最大类间方差";
            // 
            // MinClassDisLabel
            // 
            this.MinClassDisLabel.AutoSize = true;
            this.MinClassDisLabel.Location = new System.Drawing.Point(18, 235);
            this.MinClassDisLabel.Name = "MinClassDisLabel";
            this.MinClassDisLabel.Size = new System.Drawing.Size(79, 13);
            this.MinClassDisLabel.TabIndex = 8;
            this.MinClassDisLabel.Text = "最小类间距离";
            // 
            // MaxClassStddevTextBox
            // 
            this.MaxClassStddevTextBox.Location = new System.Drawing.Point(117, 199);
            this.MaxClassStddevTextBox.Name = "MaxClassStddevTextBox";
            this.MaxClassStddevTextBox.Size = new System.Drawing.Size(50, 20);
            this.MaxClassStddevTextBox.TabIndex = 9;
            this.MaxClassStddevTextBox.Text = "1.000";
            // 
            // MinClassDisTextBox
            // 
            this.MinClassDisTextBox.Location = new System.Drawing.Point(117, 232);
            this.MinClassDisTextBox.Name = "MinClassDisTextBox";
            this.MinClassDisTextBox.Size = new System.Drawing.Size(50, 20);
            this.MinClassDisTextBox.TabIndex = 9;
            this.MinClassDisTextBox.Text = "5.000";
            // 
            // FrmIsoData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 431);
            this.Controls.Add(this.MinClassDisTextBox);
            this.Controls.Add(this.MaxClassStddevTextBox);
            this.Controls.Add(this.MinClassDisLabel);
            this.Controls.Add(this.MaxClassStddevLabel);
            this.Controls.Add(this.MinPixCountNumericSelector);
            this.Controls.Add(this.IteraNumericSelector);
            this.Controls.Add(this.DifValueSelector);
            this.Controls.Add(this.IDConfirmAbortButtons);
            this.Controls.Add(this.IDFilePathSelector);
            this.Controls.Add(this.NumberOfClassGroupBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmIsoData";
            this.Text = "Iso Data参数选择";
            this.NumberOfClassGroupBox.ResumeLayout(false);
            this.NumberOfClassGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NumberOfClassLabel;
        private System.Windows.Forms.GroupBox NumberOfClassGroupBox;
        private CommonControls.NumericSelector MaxKindNumericSelector;
        private CommonControls.NumericSelector MinKindNumericSelector;
        private CommonControls.NumericSelector IteraNumericSelector;
        private CommonControls.ValueSelector DifValueSelector;
        private CommonControls.ConfirmAbortButtons IDConfirmAbortButtons;
        private FilePathSelector IDFilePathSelector;
        private CommonControls.NumericSelector MinPixCountNumericSelector;
        private System.Windows.Forms.Label MaxClassStddevLabel;
        private System.Windows.Forms.Label MinClassDisLabel;
        private System.Windows.Forms.TextBox MaxClassStddevTextBox;
        private System.Windows.Forms.TextBox MinClassDisTextBox;
    }
}