namespace Roughness
{
    partial class RoughnessForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoughnessForm));
            this.FilePathButton = new System.Windows.Forms.Button();
            this.FilePathLabel = new System.Windows.Forms.Label();
            this.FilePathTextBox = new System.Windows.Forms.TextBox();
            this.FileContentRichTextBox = new System.Windows.Forms.RichTextBox();
            this.StartConvertButton = new System.Windows.Forms.Button();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.NoDataValueTextBox = new System.Windows.Forms.TextBox();
            this.RoughnessLabel = new System.Windows.Forms.Label();
            this.RoughnessTextBox = new System.Windows.Forms.TextBox();
            this.ConvertProgressBar = new System.Windows.Forms.ProgressBar();
            this.NoDataLabel = new System.Windows.Forms.Label();
            this.CancelConvertButton = new System.Windows.Forms.Button();
            this.ModeTabControl = new System.Windows.Forms.TabControl();
            this.Mode1TabPage = new System.Windows.Forms.TabPage();
            this.Mode2TabPage = new System.Windows.Forms.TabPage();
            this.ValuesDataGridView = new System.Windows.Forms.DataGridView();
            this.OriginalValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TargetValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModeTabControl.SuspendLayout();
            this.Mode1TabPage.SuspendLayout();
            this.Mode2TabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ValuesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // FilePathButton
            // 
            this.FilePathButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FilePathButton.Location = new System.Drawing.Point(443, 31);
            this.FilePathButton.Name = "FilePathButton";
            this.FilePathButton.Size = new System.Drawing.Size(75, 23);
            this.FilePathButton.TabIndex = 0;
            this.FilePathButton.Text = "浏览...";
            this.FilePathButton.UseVisualStyleBackColor = true;
            this.FilePathButton.Click += new System.EventHandler(this.GetFilePath);
            // 
            // FilePathLabel
            // 
            this.FilePathLabel.AutoSize = true;
            this.FilePathLabel.Location = new System.Drawing.Point(30, 36);
            this.FilePathLabel.Name = "FilePathLabel";
            this.FilePathLabel.Size = new System.Drawing.Size(55, 13);
            this.FilePathLabel.TabIndex = 2;
            this.FilePathLabel.Text = "文件路径";
            // 
            // FilePathTextBox
            // 
            this.FilePathTextBox.Location = new System.Drawing.Point(91, 33);
            this.FilePathTextBox.Name = "FilePathTextBox";
            this.FilePathTextBox.Size = new System.Drawing.Size(342, 20);
            this.FilePathTextBox.TabIndex = 1;
            // 
            // FileContentRichTextBox
            // 
            this.FileContentRichTextBox.Location = new System.Drawing.Point(250, 81);
            this.FileContentRichTextBox.Name = "FileContentRichTextBox";
            this.FileContentRichTextBox.ReadOnly = true;
            this.FileContentRichTextBox.Size = new System.Drawing.Size(268, 133);
            this.FileContentRichTextBox.TabIndex = 3;
            this.FileContentRichTextBox.TabStop = false;
            this.FileContentRichTextBox.Text = "";
            // 
            // StartConvertButton
            // 
            this.StartConvertButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartConvertButton.Location = new System.Drawing.Point(16, 257);
            this.StartConvertButton.Name = "StartConvertButton";
            this.StartConvertButton.Size = new System.Drawing.Size(106, 37);
            this.StartConvertButton.TabIndex = 3;
            this.StartConvertButton.Text = "开始转换！";
            this.StartConvertButton.UseVisualStyleBackColor = true;
            this.StartConvertButton.Click += new System.EventHandler(this.GetR);
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.Location = new System.Drawing.Point(322, 233);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(127, 13);
            this.ProgressLabel.TabIndex = 4;
            this.ProgressLabel.Text = "小老弟，你怎么回事？";
            this.ProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ProgressLabel.Click += new System.EventHandler(this.ShowAuthor);
            // 
            // NoDataValueTextBox
            // 
            this.NoDataValueTextBox.Location = new System.Drawing.Point(124, 42);
            this.NoDataValueTextBox.Name = "NoDataValueTextBox";
            this.NoDataValueTextBox.Size = new System.Drawing.Size(100, 20);
            this.NoDataValueTextBox.TabIndex = 0;
            // 
            // RoughnessLabel
            // 
            this.RoughnessLabel.AutoSize = true;
            this.RoughnessLabel.Location = new System.Drawing.Point(14, 87);
            this.RoughnessLabel.Name = "RoughnessLabel";
            this.RoughnessLabel.Size = new System.Drawing.Size(104, 13);
            this.RoughnessLabel.TabIndex = 4;
            this.RoughnessLabel.Text = "将非NoData值设为";
            // 
            // RoughnessTextBox
            // 
            this.RoughnessTextBox.Location = new System.Drawing.Point(124, 84);
            this.RoughnessTextBox.Name = "RoughnessTextBox";
            this.RoughnessTextBox.Size = new System.Drawing.Size(100, 20);
            this.RoughnessTextBox.TabIndex = 1;
            // 
            // ConvertProgressBar
            // 
            this.ConvertProgressBar.Location = new System.Drawing.Point(250, 266);
            this.ConvertProgressBar.Name = "ConvertProgressBar";
            this.ConvertProgressBar.Size = new System.Drawing.Size(268, 23);
            this.ConvertProgressBar.Step = 1;
            this.ConvertProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ConvertProgressBar.TabIndex = 5;
            // 
            // NoDataLabel
            // 
            this.NoDataLabel.AutoSize = true;
            this.NoDataLabel.Location = new System.Drawing.Point(38, 45);
            this.NoDataLabel.Name = "NoDataLabel";
            this.NoDataLabel.Size = new System.Drawing.Size(56, 13);
            this.NoDataLabel.TabIndex = 4;
            this.NoDataLabel.Text = "NoData值";
            // 
            // CancelConvertButton
            // 
            this.CancelConvertButton.Cursor = System.Windows.Forms.Cursors.No;
            this.CancelConvertButton.Enabled = false;
            this.CancelConvertButton.Location = new System.Drawing.Point(128, 257);
            this.CancelConvertButton.Name = "CancelConvertButton";
            this.CancelConvertButton.Size = new System.Drawing.Size(106, 37);
            this.CancelConvertButton.TabIndex = 4;
            this.CancelConvertButton.Text = "取消操作";
            this.CancelConvertButton.UseVisualStyleBackColor = true;
            this.CancelConvertButton.Click += new System.EventHandler(this.GetR);
            // 
            // ModeTabControl
            // 
            this.ModeTabControl.Controls.Add(this.Mode1TabPage);
            this.ModeTabControl.Controls.Add(this.Mode2TabPage);
            this.ModeTabControl.Location = new System.Drawing.Point(0, 71);
            this.ModeTabControl.Name = "ModeTabControl";
            this.ModeTabControl.SelectedIndex = 0;
            this.ModeTabControl.Size = new System.Drawing.Size(244, 180);
            this.ModeTabControl.TabIndex = 2;
            // 
            // Mode1TabPage
            // 
            this.Mode1TabPage.Controls.Add(this.RoughnessTextBox);
            this.Mode1TabPage.Controls.Add(this.RoughnessLabel);
            this.Mode1TabPage.Controls.Add(this.NoDataLabel);
            this.Mode1TabPage.Controls.Add(this.NoDataValueTextBox);
            this.Mode1TabPage.Location = new System.Drawing.Point(4, 22);
            this.Mode1TabPage.Name = "Mode1TabPage";
            this.Mode1TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Mode1TabPage.Size = new System.Drawing.Size(236, 154);
            this.Mode1TabPage.TabIndex = 0;
            this.Mode1TabPage.Text = "更改NoData值";
            this.Mode1TabPage.UseVisualStyleBackColor = true;
            // 
            // Mode2TabPage
            // 
            this.Mode2TabPage.Controls.Add(this.ValuesDataGridView);
            this.Mode2TabPage.Location = new System.Drawing.Point(4, 22);
            this.Mode2TabPage.Name = "Mode2TabPage";
            this.Mode2TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Mode2TabPage.Size = new System.Drawing.Size(236, 154);
            this.Mode2TabPage.TabIndex = 1;
            this.Mode2TabPage.Text = "重分类";
            this.Mode2TabPage.UseVisualStyleBackColor = true;
            // 
            // ValuesDataGridView
            // 
            this.ValuesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ValuesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OriginalValue,
            this.DelButton,
            this.TargetValue});
            this.ValuesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ValuesDataGridView.Location = new System.Drawing.Point(3, 3);
            this.ValuesDataGridView.Name = "ValuesDataGridView";
            this.ValuesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ValuesDataGridView.Size = new System.Drawing.Size(230, 148);
            this.ValuesDataGridView.TabIndex = 0;
            this.ValuesDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickToDeleteRow);
            // 
            // OriginalValue
            // 
            this.OriginalValue.HeaderText = "原有值";
            this.OriginalValue.MaxInputLength = 10;
            this.OriginalValue.Name = "OriginalValue";
            this.OriginalValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OriginalValue.Width = 60;
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
            // TargetValue
            // 
            this.TargetValue.HeaderText = "更改为";
            this.TargetValue.MaxInputLength = 10;
            this.TargetValue.Name = "TargetValue";
            this.TargetValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TargetValue.Width = 60;
            // 
            // RoughnessForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 306);
            this.Controls.Add(this.ModeTabControl);
            this.Controls.Add(this.FileContentRichTextBox);
            this.Controls.Add(this.StartConvertButton);
            this.Controls.Add(this.FilePathTextBox);
            this.Controls.Add(this.CancelConvertButton);
            this.Controls.Add(this.FilePathLabel);
            this.Controls.Add(this.ConvertProgressBar);
            this.Controls.Add(this.FilePathButton);
            this.Controls.Add(this.ProgressLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.Name = "RoughnessForm";
            this.Text = "DEM转糙率工具";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExitApp);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragToLocateFile);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.PreDragDrop);
            this.ModeTabControl.ResumeLayout(false);
            this.Mode1TabPage.ResumeLayout(false);
            this.Mode1TabPage.PerformLayout();
            this.Mode2TabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ValuesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FilePathButton;
        private System.Windows.Forms.Label FilePathLabel;
        private System.Windows.Forms.TextBox FilePathTextBox;
        private System.Windows.Forms.RichTextBox FileContentRichTextBox;
        private System.Windows.Forms.Button StartConvertButton;
        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.TextBox NoDataValueTextBox;
        private System.Windows.Forms.Label RoughnessLabel;
        private System.Windows.Forms.TextBox RoughnessTextBox;
        private System.Windows.Forms.ProgressBar ConvertProgressBar;
        private System.Windows.Forms.Label NoDataLabel;
        private System.Windows.Forms.Button CancelConvertButton;
        private System.Windows.Forms.TabControl ModeTabControl;
        private System.Windows.Forms.TabPage Mode1TabPage;
        private System.Windows.Forms.TabPage Mode2TabPage;
        private System.Windows.Forms.DataGridView ValuesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn OriginalValue;
        private System.Windows.Forms.DataGridViewButtonColumn DelButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetValue;
    }
}

