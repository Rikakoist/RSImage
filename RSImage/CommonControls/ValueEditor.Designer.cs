namespace RSImage
{
    partial class ValueEditor
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
            this.ValuesListView = new System.Windows.Forms.ListView();
            this.ResetButton = new System.Windows.Forms.Button();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.EditGroupBox = new System.Windows.Forms.GroupBox();
            this.ValueTextBox = new System.Windows.Forms.TextBox();
            this.BandTextBox = new System.Windows.Forms.TextBox();
            this.EditGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ValuesListView
            // 
            this.ValuesListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ValuesListView.AutoArrange = false;
            this.ValuesListView.GridLines = true;
            this.ValuesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ValuesListView.HideSelection = false;
            this.ValuesListView.Location = new System.Drawing.Point(3, 31);
            this.ValuesListView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ValuesListView.MultiSelect = false;
            this.ValuesListView.Name = "ValuesListView";
            this.ValuesListView.Size = new System.Drawing.Size(222, 104);
            this.ValuesListView.TabIndex = 0;
            this.ValuesListView.UseCompatibleStateImageBehavior = false;
            this.ValuesListView.View = System.Windows.Forms.View.List;
            this.ValuesListView.SelectedIndexChanged += new System.EventHandler(this.StartEdit);
            this.ValuesListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.StartEdit2);
            // 
            // ResetButton
            // 
            this.ResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetButton.Location = new System.Drawing.Point(152, 4);
            this.ResetButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(73, 24);
            this.ResetButton.TabIndex = 1;
            this.ResetButton.Text = "重置";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.Reset);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(11, 8);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(0, 17);
            this.TitleLabel.TabIndex = 2;
            // 
            // EditGroupBox
            // 
            this.EditGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditGroupBox.Controls.Add(this.ValueTextBox);
            this.EditGroupBox.Controls.Add(this.BandTextBox);
            this.EditGroupBox.Location = new System.Drawing.Point(3, 143);
            this.EditGroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EditGroupBox.Name = "EditGroupBox";
            this.EditGroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EditGroupBox.Size = new System.Drawing.Size(222, 63);
            this.EditGroupBox.TabIndex = 3;
            this.EditGroupBox.TabStop = false;
            this.EditGroupBox.Text = "编辑选定项";
            // 
            // ValueTextBox
            // 
            this.ValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ValueTextBox.Location = new System.Drawing.Point(97, 26);
            this.ValueTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ValueTextBox.MaxLength = 20;
            this.ValueTextBox.MinimumSize = new System.Drawing.Size(100, 20);
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.Size = new System.Drawing.Size(119, 23);
            this.ValueTextBox.TabIndex = 0;
            this.ValueTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EndEdit);
            this.ValueTextBox.Leave += new System.EventHandler(this.ChangeBandValue);
            // 
            // BandTextBox
            // 
            this.BandTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BandTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.BandTextBox.Location = new System.Drawing.Point(11, 26);
            this.BandTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BandTextBox.MaxLength = 10;
            this.BandTextBox.MinimumSize = new System.Drawing.Size(70, 20);
            this.BandTextBox.Name = "BandTextBox";
            this.BandTextBox.ReadOnly = true;
            this.BandTextBox.ShortcutsEnabled = false;
            this.BandTextBox.Size = new System.Drawing.Size(80, 23);
            this.BandTextBox.TabIndex = 1;
            this.BandTextBox.TabStop = false;
            // 
            // ValueEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.EditGroupBox);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.ValuesListView);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ValueEditor";
            this.Size = new System.Drawing.Size(228, 210);
            this.Load += new System.EventHandler(this.ControlLoad);
            this.EditGroupBox.ResumeLayout(false);
            this.EditGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ValuesListView;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.GroupBox EditGroupBox;
        private System.Windows.Forms.TextBox ValueTextBox;
        private System.Windows.Forms.TextBox BandTextBox;
    }
}
