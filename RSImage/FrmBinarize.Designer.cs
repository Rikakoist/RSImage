namespace RSImage
{
    partial class FrmBinarize
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
            this.SplitMethodsComboBox = new System.Windows.Forms.ComboBox();
            this.SplitMethodsLabel = new System.Windows.Forms.Label();
            this.ZeroValueSelector = new RSImage.CommonControls.ValueSelector();
            this.OneValueSelector = new RSImage.CommonControls.ValueSelector();
            this.BConfirmAbortButtons = new RSImage.CommonControls.ConfirmAbortButtons();
            this.BFilePathSelector = new RSImage.FilePathSelector();
            this.BValueSelector = new RSImage.CommonControls.ValueSelector();
            this.SuspendLayout();
            // 
            // SplitMethodsComboBox
            // 
            this.SplitMethodsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SplitMethodsComboBox.FormattingEnabled = true;
            this.SplitMethodsComboBox.Location = new System.Drawing.Point(265, 23);
            this.SplitMethodsComboBox.Name = "SplitMethodsComboBox";
            this.SplitMethodsComboBox.Size = new System.Drawing.Size(149, 25);
            this.SplitMethodsComboBox.TabIndex = 0;
            this.SplitMethodsComboBox.SelectedIndexChanged += new System.EventHandler(this.SplitMethodsComboBox_SelectedIndexChanged);
            // 
            // SplitMethodsLabel
            // 
            this.SplitMethodsLabel.AutoSize = true;
            this.SplitMethodsLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SplitMethodsLabel.Location = new System.Drawing.Point(173, 25);
            this.SplitMethodsLabel.Name = "SplitMethodsLabel";
            this.SplitMethodsLabel.Size = new System.Drawing.Size(79, 20);
            this.SplitMethodsLabel.TabIndex = 4;
            this.SplitMethodsLabel.Text = "分割方法：";
            // 
            // ZeroValueSelector
            // 
            this.ZeroValueSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ZeroValueSelector.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZeroValueSelector.Location = new System.Drawing.Point(12, 130);
            this.ZeroValueSelector.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ZeroValueSelector.Max = 255D;
            this.ZeroValueSelector.Min = 0D;
            this.ZeroValueSelector.MinimumSize = new System.Drawing.Size(364, 53);
            this.ZeroValueSelector.Name = "ZeroValueSelector";
            this.ZeroValueSelector.Ratio = 1D;
            this.ZeroValueSelector.Size = new System.Drawing.Size(539, 53);
            this.ZeroValueSelector.TabIndex = 2;
            this.ZeroValueSelector.Title = "<T设为";
            this.ZeroValueSelector.Value = 0D;
            // 
            // OneValueSelector
            // 
            this.OneValueSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OneValueSelector.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OneValueSelector.Location = new System.Drawing.Point(12, 191);
            this.OneValueSelector.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OneValueSelector.Max = 255D;
            this.OneValueSelector.Min = 0D;
            this.OneValueSelector.MinimumSize = new System.Drawing.Size(364, 53);
            this.OneValueSelector.Name = "OneValueSelector";
            this.OneValueSelector.Ratio = 1D;
            this.OneValueSelector.Size = new System.Drawing.Size(539, 53);
            this.OneValueSelector.TabIndex = 3;
            this.OneValueSelector.Title = ">T设为";
            this.OneValueSelector.Value = 255D;
            // 
            // BConfirmAbortButtons
            // 
            this.BConfirmAbortButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BConfirmAbortButtons.Location = new System.Drawing.Point(228, 375);
            this.BConfirmAbortButtons.MinimumSize = new System.Drawing.Size(120, 25);
            this.BConfirmAbortButtons.Name = "BConfirmAbortButtons";
            this.BConfirmAbortButtons.Size = new System.Drawing.Size(124, 25);
            this.BConfirmAbortButtons.TabIndex = 5;
            this.BConfirmAbortButtons.ConfirmBtnClick += new RSImage.CommonControls.ConfirmAbortButtons.ConfirmBtnClickEventHander(this.BConfirmAbortButtons_ConfirmBtnClick);
            this.BConfirmAbortButtons.AbortBtnClick += new RSImage.CommonControls.ConfirmAbortButtons.AbortBtnClickEventHander(this.BConfirmAbortButtons_AbortBtnClick);
            // 
            // BFilePathSelector
            // 
            this.BFilePathSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BFilePathSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BFilePathSelector.Filter = "All files|*.*";
            this.BFilePathSelector.FilterIndex = 1;
            this.BFilePathSelector.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BFilePathSelector.Location = new System.Drawing.Point(12, 252);
            this.BFilePathSelector.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BFilePathSelector.MinimumSize = new System.Drawing.Size(290, 110);
            this.BFilePathSelector.Name = "BFilePathSelector";
            this.BFilePathSelector.OutDataType = OSGeo.GDAL.DataType.GDT_Byte;
            this.BFilePathSelector.Path = null;
            this.BFilePathSelector.Size = new System.Drawing.Size(539, 116);
            this.BFilePathSelector.TabIndex = 4;
            this.BFilePathSelector.Title = "选择保存位置";
            this.BFilePathSelector.WorkFolder = "MyDocuments";
            // 
            // BValueSelector
            // 
            this.BValueSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BValueSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BValueSelector.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BValueSelector.Location = new System.Drawing.Point(12, 69);
            this.BValueSelector.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BValueSelector.Max = 10D;
            this.BValueSelector.Min = 0D;
            this.BValueSelector.MinimumSize = new System.Drawing.Size(364, 53);
            this.BValueSelector.Name = "BValueSelector";
            this.BValueSelector.Ratio = 1D;
            this.BValueSelector.Size = new System.Drawing.Size(539, 53);
            this.BValueSelector.TabIndex = 1;
            this.BValueSelector.Title = "阈值T";
            this.BValueSelector.Value = 5D;
            // 
            // FrmBinarize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 412);
            this.Controls.Add(this.ZeroValueSelector);
            this.Controls.Add(this.OneValueSelector);
            this.Controls.Add(this.SplitMethodsLabel);
            this.Controls.Add(this.SplitMethodsComboBox);
            this.Controls.Add(this.BConfirmAbortButtons);
            this.Controls.Add(this.BFilePathSelector);
            this.Controls.Add(this.BValueSelector);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 275);
            this.Name = "FrmBinarize";
            this.Text = "阈值分割（二值化）";
            this.Load += new System.EventHandler(this.FrmBinarize_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CommonControls.ValueSelector BValueSelector;
        private CommonControls.ConfirmAbortButtons BConfirmAbortButtons;
        public FilePathSelector BFilePathSelector;
        private System.Windows.Forms.ComboBox SplitMethodsComboBox;
        private System.Windows.Forms.Label SplitMethodsLabel;
        internal CommonControls.ValueSelector OneValueSelector;
        internal CommonControls.ValueSelector ZeroValueSelector;
    }
}