namespace RSImage
{
    partial class FrmExport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExport));
            this.EFFilePathSelector = new RSImage.FilePathSelector();
            this.EFConfirmAbortButtons = new RSImage.CommonControls.ConfirmAbortButtons();
            this.SuspendLayout();
            // 
            // EFFilePathSelector
            // 
            this.EFFilePathSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EFFilePathSelector.Filter = "Geotiff|*.tif";
            this.EFFilePathSelector.FilterIndex = 1;
            this.EFFilePathSelector.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EFFilePathSelector.Location = new System.Drawing.Point(2, 3);
            this.EFFilePathSelector.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EFFilePathSelector.MinimumSize = new System.Drawing.Size(290, 110);
            this.EFFilePathSelector.Name = "EFFilePathSelector";
            this.EFFilePathSelector.OutDataType = OSGeo.GDAL.DataType.GDT_Float32;
            this.EFFilePathSelector.Path = null;
            this.EFFilePathSelector.Size = new System.Drawing.Size(298, 115);
            this.EFFilePathSelector.TabIndex = 0;
            this.EFFilePathSelector.Title = "选择保存位置";
            this.EFFilePathSelector.WorkFolder = "MyDocuments";
            // 
            // EFConfirmAbortButtons
            // 
            this.EFConfirmAbortButtons.Location = new System.Drawing.Point(161, 125);
            this.EFConfirmAbortButtons.MinimumSize = new System.Drawing.Size(120, 30);
            this.EFConfirmAbortButtons.Name = "EFConfirmAbortButtons";
            this.EFConfirmAbortButtons.Size = new System.Drawing.Size(139, 30);
            this.EFConfirmAbortButtons.TabIndex = 1;
            this.EFConfirmAbortButtons.ConfirmBtnClick += new RSImage.CommonControls.ConfirmAbortButtons.ConfirmBtnClickEventHander(this.EFConfirmAbortButtons_ConfirmBtnClick);
            this.EFConfirmAbortButtons.AbortBtnClick += new RSImage.CommonControls.ConfirmAbortButtons.AbortBtnClickEventHander(this.EFConfirmAbortButtons_AbortBtnClick);
            // 
            // FrmExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 160);
            this.Controls.Add(this.EFConfirmAbortButtons);
            this.Controls.Add(this.EFFilePathSelector);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }

        #endregion
        private CommonControls.ConfirmAbortButtons EFConfirmAbortButtons;
        public FilePathSelector EFFilePathSelector;
    }
}