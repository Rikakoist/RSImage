namespace RSImage
{
    partial class FrmRoughness
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRoughness));
            this.NoDataValueTextBox = new System.Windows.Forms.TextBox();
            this.RoughnessLabel = new System.Windows.Forms.Label();
            this.ReplaceValueTextBox = new System.Windows.Forms.TextBox();
            this.NoDataLabel = new System.Windows.Forms.Label();
            this.ModeTabControl = new System.Windows.Forms.TabControl();
            this.Mode1TabPage = new System.Windows.Forms.TabPage();
            this.Mode2TabPage = new System.Windows.Forms.TabPage();
            this.ValuesDataGridView = new System.Windows.Forms.DataGridView();
            this.DelButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.OriginalValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TargetValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RConfirmAbortButtons = new RSImage.CommonControls.ConfirmAbortButtons();
            this.RFFilePathSelector = new RSImage.FilePathSelector();
            this.ModeTabControl.SuspendLayout();
            this.Mode1TabPage.SuspendLayout();
            this.Mode2TabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ValuesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // NoDataValueTextBox
            // 
            this.NoDataValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NoDataValueTextBox.Location = new System.Drawing.Point(191, 60);
            this.NoDataValueTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.NoDataValueTextBox.Name = "NoDataValueTextBox";
            this.NoDataValueTextBox.Size = new System.Drawing.Size(132, 20);
            this.NoDataValueTextBox.TabIndex = 0;
            // 
            // RoughnessLabel
            // 
            this.RoughnessLabel.AutoSize = true;
            this.RoughnessLabel.Location = new System.Drawing.Point(15, 115);
            this.RoughnessLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RoughnessLabel.Name = "RoughnessLabel";
            this.RoughnessLabel.Size = new System.Drawing.Size(104, 13);
            this.RoughnessLabel.TabIndex = 4;
            this.RoughnessLabel.Text = "将非NoData值设为";
            // 
            // ReplaceValueTextBox
            // 
            this.ReplaceValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ReplaceValueTextBox.Location = new System.Drawing.Point(191, 111);
            this.ReplaceValueTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.ReplaceValueTextBox.Name = "ReplaceValueTextBox";
            this.ReplaceValueTextBox.Size = new System.Drawing.Size(132, 20);
            this.ReplaceValueTextBox.TabIndex = 1;
            // 
            // NoDataLabel
            // 
            this.NoDataLabel.AutoSize = true;
            this.NoDataLabel.Location = new System.Drawing.Point(47, 63);
            this.NoDataLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NoDataLabel.Name = "NoDataLabel";
            this.NoDataLabel.Size = new System.Drawing.Size(56, 13);
            this.NoDataLabel.TabIndex = 4;
            this.NoDataLabel.Text = "NoData值";
            // 
            // ModeTabControl
            // 
            this.ModeTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ModeTabControl.Controls.Add(this.Mode1TabPage);
            this.ModeTabControl.Controls.Add(this.Mode2TabPage);
            this.ModeTabControl.Location = new System.Drawing.Point(13, 13);
            this.ModeTabControl.Margin = new System.Windows.Forms.Padding(4);
            this.ModeTabControl.Name = "ModeTabControl";
            this.ModeTabControl.SelectedIndex = 0;
            this.ModeTabControl.Size = new System.Drawing.Size(355, 213);
            this.ModeTabControl.TabIndex = 2;
            // 
            // Mode1TabPage
            // 
            this.Mode1TabPage.Controls.Add(this.ReplaceValueTextBox);
            this.Mode1TabPage.Controls.Add(this.RoughnessLabel);
            this.Mode1TabPage.Controls.Add(this.NoDataLabel);
            this.Mode1TabPage.Controls.Add(this.NoDataValueTextBox);
            this.Mode1TabPage.Location = new System.Drawing.Point(4, 22);
            this.Mode1TabPage.Margin = new System.Windows.Forms.Padding(4);
            this.Mode1TabPage.Name = "Mode1TabPage";
            this.Mode1TabPage.Padding = new System.Windows.Forms.Padding(4);
            this.Mode1TabPage.Size = new System.Drawing.Size(347, 187);
            this.Mode1TabPage.TabIndex = 0;
            this.Mode1TabPage.Text = "更改NoData值";
            this.Mode1TabPage.UseVisualStyleBackColor = true;
            // 
            // Mode2TabPage
            // 
            this.Mode2TabPage.Controls.Add(this.ValuesDataGridView);
            this.Mode2TabPage.Location = new System.Drawing.Point(4, 22);
            this.Mode2TabPage.Margin = new System.Windows.Forms.Padding(4);
            this.Mode2TabPage.Name = "Mode2TabPage";
            this.Mode2TabPage.Padding = new System.Windows.Forms.Padding(4);
            this.Mode2TabPage.Size = new System.Drawing.Size(347, 187);
            this.Mode2TabPage.TabIndex = 1;
            this.Mode2TabPage.Text = "重分类";
            this.Mode2TabPage.UseVisualStyleBackColor = true;
            // 
            // ValuesDataGridView
            // 
            this.ValuesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ValuesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DelButton,
            this.OriginalValue,
            this.TargetValue});
            this.ValuesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ValuesDataGridView.Location = new System.Drawing.Point(4, 4);
            this.ValuesDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.ValuesDataGridView.Name = "ValuesDataGridView";
            this.ValuesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ValuesDataGridView.Size = new System.Drawing.Size(339, 179);
            this.ValuesDataGridView.TabIndex = 0;
            this.ValuesDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickToDeleteRow);
            // 
            // DelButton
            // 
            this.DelButton.HeaderText = "删除";
            this.DelButton.Name = "DelButton";
            this.DelButton.ReadOnly = true;
            this.DelButton.Text = "删除";
            this.DelButton.UseColumnTextForButtonValue = true;
            this.DelButton.Width = 50;
            // 
            // OriginalValue
            // 
            this.OriginalValue.HeaderText = "原有值";
            this.OriginalValue.MaxInputLength = 10;
            this.OriginalValue.Name = "OriginalValue";
            this.OriginalValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OriginalValue.Width = 70;
            // 
            // TargetValue
            // 
            this.TargetValue.HeaderText = "更改为";
            this.TargetValue.MaxInputLength = 10;
            this.TargetValue.Name = "TargetValue";
            this.TargetValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TargetValue.Width = 70;
            // 
            // RConfirmAbortButtons
            // 
            this.RConfirmAbortButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RConfirmAbortButtons.Location = new System.Drawing.Point(215, 351);
            this.RConfirmAbortButtons.MinimumSize = new System.Drawing.Size(120, 30);
            this.RConfirmAbortButtons.Name = "RConfirmAbortButtons";
            this.RConfirmAbortButtons.Size = new System.Drawing.Size(149, 30);
            this.RConfirmAbortButtons.TabIndex = 7;
            this.RConfirmAbortButtons.ConfirmBtnClick += new RSImage.CommonControls.ConfirmAbortButtons.ConfirmBtnClickEventHander(this.Confirm);
            this.RConfirmAbortButtons.AbortBtnClick += new RSImage.CommonControls.ConfirmAbortButtons.AbortBtnClickEventHander(this.RConfirmAbortButtons_AbortBtnClick);
            // 
            // RFFilePathSelector
            // 
            this.RFFilePathSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RFFilePathSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RFFilePathSelector.Filter = "All files|*.*";
            this.RFFilePathSelector.FilterIndex = 1;
            this.RFFilePathSelector.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RFFilePathSelector.Location = new System.Drawing.Point(13, 234);
            this.RFFilePathSelector.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RFFilePathSelector.MinimumSize = new System.Drawing.Size(290, 110);
            this.RFFilePathSelector.Name = "RFFilePathSelector";
            this.RFFilePathSelector.OutDataType = OSGeo.GDAL.DataType.GDT_Float32;
            this.RFFilePathSelector.Path = null;
            this.RFFilePathSelector.Size = new System.Drawing.Size(351, 110);
            this.RFFilePathSelector.TabIndex = 6;
            this.RFFilePathSelector.Title = "选择保存位置";
            this.RFFilePathSelector.WorkFolder = "MyDocuments";
            // 
            // FrmRoughness
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(381, 393);
            this.Controls.Add(this.RConfirmAbortButtons);
            this.Controls.Add(this.RFFilePathSelector);
            this.Controls.Add(this.ModeTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmRoughness";
            this.Text = "DEM转糙率工具";
            this.ModeTabControl.ResumeLayout(false);
            this.Mode1TabPage.ResumeLayout(false);
            this.Mode1TabPage.PerformLayout();
            this.Mode2TabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ValuesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox NoDataValueTextBox;
        private System.Windows.Forms.Label RoughnessLabel;
        private System.Windows.Forms.TextBox ReplaceValueTextBox;
        private System.Windows.Forms.Label NoDataLabel;
        private System.Windows.Forms.TabControl ModeTabControl;
        private System.Windows.Forms.TabPage Mode1TabPage;
        private System.Windows.Forms.TabPage Mode2TabPage;
        private System.Windows.Forms.DataGridView ValuesDataGridView;
        private FilePathSelector RFFilePathSelector;
        private CommonControls.ConfirmAbortButtons RConfirmAbortButtons;
        private System.Windows.Forms.DataGridViewButtonColumn DelButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn OriginalValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetValue;
    }
}

