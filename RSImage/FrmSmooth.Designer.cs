namespace RSImage
{
    partial class FrmSmooth
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
            this.SmoothMethodLabel = new System.Windows.Forms.Label();
            this.SmoothMethodsComboBox = new System.Windows.Forms.ComboBox();
            this.SConfirmAbortButtons = new RSImage.CommonControls.ConfirmAbortButtons();
            this.SFilePathSelector = new RSImage.FilePathSelector();
            this.SuspendLayout();
            // 
            // SmoothMethodLabel
            // 
            this.SmoothMethodLabel.AutoSize = true;
            this.SmoothMethodLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SmoothMethodLabel.Location = new System.Drawing.Point(12, 28);
            this.SmoothMethodLabel.Name = "SmoothMethodLabel";
            this.SmoothMethodLabel.Size = new System.Drawing.Size(113, 20);
            this.SmoothMethodLabel.TabIndex = 2;
            this.SmoothMethodLabel.Text = "平滑/锐化方法：";
            // 
            // SmoothMethodsComboBox
            // 
            this.SmoothMethodsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SmoothMethodsComboBox.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SmoothMethodsComboBox.FormattingEnabled = true;
            this.SmoothMethodsComboBox.Location = new System.Drawing.Point(130, 29);
            this.SmoothMethodsComboBox.Name = "SmoothMethodsComboBox";
            this.SmoothMethodsComboBox.Size = new System.Drawing.Size(194, 20);
            this.SmoothMethodsComboBox.TabIndex = 0;
            // 
            // SConfirmAbortButtons
            // 
            this.SConfirmAbortButtons.Location = new System.Drawing.Point(90, 204);
            this.SConfirmAbortButtons.MinimumSize = new System.Drawing.Size(120, 30);
            this.SConfirmAbortButtons.Name = "SConfirmAbortButtons";
            this.SConfirmAbortButtons.Size = new System.Drawing.Size(154, 30);
            this.SConfirmAbortButtons.TabIndex = 2;
            this.SConfirmAbortButtons.ConfirmBtnClick += new RSImage.CommonControls.ConfirmAbortButtons.ConfirmBtnClickEventHander(this.SConfirmAbortButtons_ConfirmBtnClick);
            this.SConfirmAbortButtons.AbortBtnClick += new RSImage.CommonControls.ConfirmAbortButtons.AbortBtnClickEventHander(this.SConfirmAbortButtons_AbortBtnClick);
            // 
            // SFilePathSelector
            // 
            this.SFilePathSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SFilePathSelector.Filter = "All files|*.*";
            this.SFilePathSelector.FilterIndex = 1;
            this.SFilePathSelector.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SFilePathSelector.Location = new System.Drawing.Point(12, 72);
            this.SFilePathSelector.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SFilePathSelector.MinimumSize = new System.Drawing.Size(290, 110);
            this.SFilePathSelector.Name = "SFilePathSelector";
            this.SFilePathSelector.OutDataType = OSGeo.GDAL.DataType.GDT_Float32;
            this.SFilePathSelector.Path = null;
            this.SFilePathSelector.Size = new System.Drawing.Size(312, 115);
            this.SFilePathSelector.TabIndex = 1;
            this.SFilePathSelector.Title = "选择保存位置";
            this.SFilePathSelector.WorkFolder = "MyDocuments";
            // 
            // FrmSmooth
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(336, 249);
            this.Controls.Add(this.SConfirmAbortButtons);
            this.Controls.Add(this.SmoothMethodsComboBox);
            this.Controls.Add(this.SmoothMethodLabel);
            this.Controls.Add(this.SFilePathSelector);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSmooth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "影像平滑锐化";
            this.Load += new System.EventHandler(this.FrmSmooth_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FilePathSelector SFilePathSelector;
        private System.Windows.Forms.Label SmoothMethodLabel;
        private System.Windows.Forms.ComboBox SmoothMethodsComboBox;
        private CommonControls.ConfirmAbortButtons SConfirmAbortButtons;
    }
}