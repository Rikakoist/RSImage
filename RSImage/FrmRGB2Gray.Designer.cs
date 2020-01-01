namespace RSImage
{
    partial class FrmRGB2Gray
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
            this.RValueSelector = new RSImage.CommonControls.ValueSelector();
            this.GValueSelector = new RSImage.CommonControls.ValueSelector();
            this.BValueSelector = new RSImage.CommonControls.ValueSelector();
            this.R2GFilePathSelector = new RSImage.FilePathSelector();
            this.R2GConfirmAbortButtons = new RSImage.CommonControls.ConfirmAbortButtons();
            this.SuspendLayout();
            // 
            // RValueSelector
            // 
            this.RValueSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RValueSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RValueSelector.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RValueSelector.Location = new System.Drawing.Point(12, 13);
            this.RValueSelector.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RValueSelector.Max = 1D;
            this.RValueSelector.Min = 0D;
            this.RValueSelector.MinimumSize = new System.Drawing.Size(364, 53);
            this.RValueSelector.Name = "RValueSelector";
            this.RValueSelector.Ratio = 100D;
            this.RValueSelector.Size = new System.Drawing.Size(476, 53);
            this.RValueSelector.TabIndex = 0;
            this.RValueSelector.Title = "R分量";
            this.RValueSelector.Value = 0.299D;
            // 
            // GValueSelector
            // 
            this.GValueSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GValueSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GValueSelector.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GValueSelector.Location = new System.Drawing.Point(12, 74);
            this.GValueSelector.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GValueSelector.Max = 1D;
            this.GValueSelector.Min = 0D;
            this.GValueSelector.MinimumSize = new System.Drawing.Size(364, 53);
            this.GValueSelector.Name = "GValueSelector";
            this.GValueSelector.Ratio = 100D;
            this.GValueSelector.Size = new System.Drawing.Size(476, 53);
            this.GValueSelector.TabIndex = 1;
            this.GValueSelector.Title = "G分量";
            this.GValueSelector.Value = 0.587D;
            // 
            // BValueSelector
            // 
            this.BValueSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BValueSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BValueSelector.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BValueSelector.Location = new System.Drawing.Point(12, 135);
            this.BValueSelector.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BValueSelector.Max = 1D;
            this.BValueSelector.Min = 0D;
            this.BValueSelector.MinimumSize = new System.Drawing.Size(364, 53);
            this.BValueSelector.Name = "BValueSelector";
            this.BValueSelector.Ratio = 100D;
            this.BValueSelector.Size = new System.Drawing.Size(476, 53);
            this.BValueSelector.TabIndex = 2;
            this.BValueSelector.Title = "B分量";
            this.BValueSelector.Value = 0.114D;
            // 
            // R2GFilePathSelector
            // 
            this.R2GFilePathSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.R2GFilePathSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.R2GFilePathSelector.Filter = "All files|*.*";
            this.R2GFilePathSelector.FilterIndex = 1;
            this.R2GFilePathSelector.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.R2GFilePathSelector.Location = new System.Drawing.Point(12, 196);
            this.R2GFilePathSelector.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.R2GFilePathSelector.MinimumSize = new System.Drawing.Size(290, 110);
            this.R2GFilePathSelector.Name = "R2GFilePathSelector";
            this.R2GFilePathSelector.OutDataType = OSGeo.GDAL.DataType.GDT_Float32;
            this.R2GFilePathSelector.Path = null;
            this.R2GFilePathSelector.Size = new System.Drawing.Size(476, 115);
            this.R2GFilePathSelector.TabIndex = 3;
            this.R2GFilePathSelector.Title = "选择保存位置";
            this.R2GFilePathSelector.WorkFolder = "MyDocuments";
            // 
            // R2GConfirmAbortButtons
            // 
            this.R2GConfirmAbortButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.R2GConfirmAbortButtons.Location = new System.Drawing.Point(197, 318);
            this.R2GConfirmAbortButtons.MinimumSize = new System.Drawing.Size(120, 25);
            this.R2GConfirmAbortButtons.Name = "R2GConfirmAbortButtons";
            this.R2GConfirmAbortButtons.Size = new System.Drawing.Size(120, 32);
            this.R2GConfirmAbortButtons.TabIndex = 4;
            this.R2GConfirmAbortButtons.ConfirmBtnClick += new RSImage.CommonControls.ConfirmAbortButtons.ConfirmBtnClickEventHander(this.R2GConfirmAbortButtons_ConfirmBtnClick);
            this.R2GConfirmAbortButtons.AbortBtnClick += new RSImage.CommonControls.ConfirmAbortButtons.AbortBtnClickEventHander(this.R2GConfirmAbortButtons_AbortBtnClick);
            // 
            // FrmRGB2Gray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 359);
            this.Controls.Add(this.R2GConfirmAbortButtons);
            this.Controls.Add(this.R2GFilePathSelector);
            this.Controls.Add(this.BValueSelector);
            this.Controls.Add(this.GValueSelector);
            this.Controls.Add(this.RValueSelector);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRGB2Gray";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "彩色图像灰度化";
            this.Load += new System.EventHandler(this.FrmRGB2Gray_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonControls.ValueSelector RValueSelector;
        private CommonControls.ValueSelector GValueSelector;
        private CommonControls.ValueSelector BValueSelector;
        private CommonControls.ConfirmAbortButtons R2GConfirmAbortButtons;
        public FilePathSelector R2GFilePathSelector;
    }
}