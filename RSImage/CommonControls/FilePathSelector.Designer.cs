namespace RSImage
{
    partial class FilePathSelector
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.BrowseFileButton = new System.Windows.Forms.Button();
            this.FilePathTextBox = new System.Windows.Forms.TextBox();
            this.PathLabel = new System.Windows.Forms.Label();
            this.OutputDataTypeLabel = new System.Windows.Forms.Label();
            this.DataTypeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // BrowseFileButton
            // 
            this.BrowseFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseFileButton.Location = new System.Drawing.Point(206, 10);
            this.BrowseFileButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BrowseFileButton.Name = "BrowseFileButton";
            this.BrowseFileButton.Size = new System.Drawing.Size(75, 25);
            this.BrowseFileButton.TabIndex = 0;
            this.BrowseFileButton.Text = "浏览...";
            this.BrowseFileButton.UseVisualStyleBackColor = true;
            this.BrowseFileButton.Click += new System.EventHandler(this.BrowseFile);
            // 
            // FilePathTextBox
            // 
            this.FilePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FilePathTextBox.Location = new System.Drawing.Point(21, 45);
            this.FilePathTextBox.Name = "FilePathTextBox";
            this.FilePathTextBox.Size = new System.Drawing.Size(260, 23);
            this.FilePathTextBox.TabIndex = 1;
            this.FilePathTextBox.TextChanged += new System.EventHandler(this.ChangeFilePath);
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Location = new System.Drawing.Point(18, 15);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(68, 17);
            this.PathLabel.TabIndex = 3;
            this.PathLabel.Text = "输出路径：";
            // 
            // OutputDataTypeLabel
            // 
            this.OutputDataTypeLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.OutputDataTypeLabel.AutoSize = true;
            this.OutputDataTypeLabel.Location = new System.Drawing.Point(18, 84);
            this.OutputDataTypeLabel.Name = "OutputDataTypeLabel";
            this.OutputDataTypeLabel.Size = new System.Drawing.Size(92, 17);
            this.OutputDataTypeLabel.TabIndex = 4;
            this.OutputDataTypeLabel.Text = "输出数据类型：";
            // 
            // DataTypeComboBox
            // 
            this.DataTypeComboBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.DataTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DataTypeComboBox.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataTypeComboBox.FormattingEnabled = true;
            this.DataTypeComboBox.Location = new System.Drawing.Point(116, 81);
            this.DataTypeComboBox.Name = "DataTypeComboBox";
            this.DataTypeComboBox.Size = new System.Drawing.Size(165, 23);
            this.DataTypeComboBox.TabIndex = 2;
            this.DataTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.ChangeDataType);
            // 
            // FilePathSelector
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.DataTypeComboBox);
            this.Controls.Add(this.OutputDataTypeLabel);
            this.Controls.Add(this.PathLabel);
            this.Controls.Add(this.FilePathTextBox);
            this.Controls.Add(this.BrowseFileButton);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(290, 110);
            this.Name = "FilePathSelector";
            this.Size = new System.Drawing.Size(298, 115);
            this.Load += new System.EventHandler(this.ControlInit);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BrowseFileButton;
        private System.Windows.Forms.Label PathLabel;
        private System.Windows.Forms.TextBox FilePathTextBox;
        private System.Windows.Forms.Label OutputDataTypeLabel;
        private System.Windows.Forms.ComboBox DataTypeComboBox;
    }
}
