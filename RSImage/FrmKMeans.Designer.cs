namespace RSImage
{
    partial class FrmKMeans
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
            this.KFilePathSelector = new RSImage.FilePathSelector();
            this.KConfirmAbortButtons = new RSImage.CommonControls.ConfirmAbortButtons();
            this.KNumericSelector = new RSImage.CommonControls.NumericSelector();
            this.DifValueSelector = new RSImage.CommonControls.ValueSelector();
            this.IteraNumericSelector = new RSImage.CommonControls.NumericSelector();
            this.SuspendLayout();
            // 
            // KFilePathSelector
            // 
            this.KFilePathSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KFilePathSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.KFilePathSelector.Filter = "All files|*.*";
            this.KFilePathSelector.FilterIndex = 1;
            this.KFilePathSelector.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KFilePathSelector.Location = new System.Drawing.Point(12, 140);
            this.KFilePathSelector.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.KFilePathSelector.MinimumSize = new System.Drawing.Size(290, 110);
            this.KFilePathSelector.Name = "KFilePathSelector";
            this.KFilePathSelector.OutDataType = OSGeo.GDAL.DataType.GDT_Byte;
            this.KFilePathSelector.Path = null;
            this.KFilePathSelector.Size = new System.Drawing.Size(395, 115);
            this.KFilePathSelector.TabIndex = 3;
            this.KFilePathSelector.Title = "选择保存位置";
            this.KFilePathSelector.WorkFolder = "MyDocuments";
            // 
            // KConfirmAbortButtons
            // 
            this.KConfirmAbortButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.KConfirmAbortButtons.Location = new System.Drawing.Point(287, 271);
            this.KConfirmAbortButtons.MinimumSize = new System.Drawing.Size(120, 25);
            this.KConfirmAbortButtons.Name = "KConfirmAbortButtons";
            this.KConfirmAbortButtons.Size = new System.Drawing.Size(120, 25);
            this.KConfirmAbortButtons.TabIndex = 4;
            this.KConfirmAbortButtons.ConfirmBtnClick += new RSImage.CommonControls.ConfirmAbortButtons.ConfirmBtnClickEventHander(this.KConfirmAbortButtons_ConfirmBtnClick);
            this.KConfirmAbortButtons.AbortBtnClick += new RSImage.CommonControls.ConfirmAbortButtons.AbortBtnClickEventHander(this.KConfirmAbortButtons_AbortBtnClick);
            // 
            // KNumericSelector
            // 
            this.KNumericSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.KNumericSelector.Location = new System.Drawing.Point(12, 12);
            this.KNumericSelector.Max = 10;
            this.KNumericSelector.Min = 1;
            this.KNumericSelector.MinimumSize = new System.Drawing.Size(149, 27);
            this.KNumericSelector.Name = "KNumericSelector";
            this.KNumericSelector.Size = new System.Drawing.Size(175, 27);
            this.KNumericSelector.TabIndex = 0;
            this.KNumericSelector.Title = "类数";
            this.KNumericSelector.Value = 1;
            // 
            // DifValueSelector
            // 
            this.DifValueSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DifValueSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DifValueSelector.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DifValueSelector.Location = new System.Drawing.Point(12, 46);
            this.DifValueSelector.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DifValueSelector.Max = 100D;
            this.DifValueSelector.Min = 0D;
            this.DifValueSelector.MinimumSize = new System.Drawing.Size(364, 53);
            this.DifValueSelector.Name = "DifValueSelector";
            this.DifValueSelector.Ratio = 1D;
            this.DifValueSelector.Size = new System.Drawing.Size(395, 53);
            this.DifValueSelector.TabIndex = 1;
            this.DifValueSelector.Title = "改变阈值(%)";
            this.DifValueSelector.Value = 5D;
            // 
            // IteraNumericSelector
            // 
            this.IteraNumericSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IteraNumericSelector.Location = new System.Drawing.Point(12, 106);
            this.IteraNumericSelector.Max = 32767;
            this.IteraNumericSelector.Min = 1;
            this.IteraNumericSelector.MinimumSize = new System.Drawing.Size(149, 27);
            this.IteraNumericSelector.Name = "IteraNumericSelector";
            this.IteraNumericSelector.Size = new System.Drawing.Size(175, 27);
            this.IteraNumericSelector.TabIndex = 2;
            this.IteraNumericSelector.Title = "最大迭代次数";
            this.IteraNumericSelector.Value = 1;
            // 
            // FrmKMeans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 308);
            this.Controls.Add(this.IteraNumericSelector);
            this.Controls.Add(this.DifValueSelector);
            this.Controls.Add(this.KNumericSelector);
            this.Controls.Add(this.KConfirmAbortButtons);
            this.Controls.Add(this.KFilePathSelector);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmKMeans";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置K-Means参数";
            this.ResumeLayout(false);

        }

        #endregion

        private FilePathSelector KFilePathSelector;
        private CommonControls.ConfirmAbortButtons KConfirmAbortButtons;
        private CommonControls.NumericSelector KNumericSelector;
        private CommonControls.ValueSelector DifValueSelector;
        private CommonControls.NumericSelector IteraNumericSelector;
    }
}