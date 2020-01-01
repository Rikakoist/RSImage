namespace RSImage
{
    partial class FrmImgSelect
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
            this.InputFileListView = new System.Windows.Forms.ListView();
            this.InputFileGroupBox = new System.Windows.Forms.GroupBox();
            this.InputFileLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FileInfoLabel = new System.Windows.Forms.Label();
            this.FileInfoRichTextBox = new System.Windows.Forms.RichTextBox();
            this.ISConfirmAbortButtons = new RSImage.CommonControls.ConfirmAbortButtons();
            this.InputFileGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputFileListView
            // 
            this.InputFileListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputFileListView.HideSelection = false;
            this.InputFileListView.Location = new System.Drawing.Point(3, 31);
            this.InputFileListView.MultiSelect = false;
            this.InputFileListView.Name = "InputFileListView";
            this.InputFileListView.Size = new System.Drawing.Size(244, 241);
            this.InputFileListView.TabIndex = 0;
            this.InputFileListView.UseCompatibleStateImageBehavior = false;
            this.InputFileListView.View = System.Windows.Forms.View.List;
            this.InputFileListView.SelectedIndexChanged += new System.EventHandler(this.InputFileListView_SelectedIndexChanged);
            // 
            // InputFileGroupBox
            // 
            this.InputFileGroupBox.Controls.Add(this.InputFileLabel);
            this.InputFileGroupBox.Controls.Add(this.InputFileListView);
            this.InputFileGroupBox.Location = new System.Drawing.Point(12, 9);
            this.InputFileGroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.InputFileGroupBox.Name = "InputFileGroupBox";
            this.InputFileGroupBox.Padding = new System.Windows.Forms.Padding(0);
            this.InputFileGroupBox.Size = new System.Drawing.Size(250, 275);
            this.InputFileGroupBox.TabIndex = 0;
            this.InputFileGroupBox.TabStop = false;
            // 
            // InputFileLabel
            // 
            this.InputFileLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputFileLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputFileLabel.Location = new System.Drawing.Point(44, 13);
            this.InputFileLabel.Name = "InputFileLabel";
            this.InputFileLabel.Size = new System.Drawing.Size(167, 15);
            this.InputFileLabel.TabIndex = 2;
            this.InputFileLabel.Text = "选择输入的文件：";
            this.InputFileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.FileInfoRichTextBox);
            this.groupBox1.Controls.Add(this.FileInfoLabel);
            this.groupBox1.Location = new System.Drawing.Point(266, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(250, 275);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // FileInfoLabel
            // 
            this.FileInfoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileInfoLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileInfoLabel.Location = new System.Drawing.Point(44, 13);
            this.FileInfoLabel.Name = "FileInfoLabel";
            this.FileInfoLabel.Size = new System.Drawing.Size(167, 15);
            this.FileInfoLabel.TabIndex = 2;
            this.FileInfoLabel.Text = "文件信息：";
            this.FileInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FileInfoRichTextBox
            // 
            this.FileInfoRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileInfoRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileInfoRichTextBox.Location = new System.Drawing.Point(3, 31);
            this.FileInfoRichTextBox.Name = "FileInfoRichTextBox";
            this.FileInfoRichTextBox.ReadOnly = true;
            this.FileInfoRichTextBox.Size = new System.Drawing.Size(244, 241);
            this.FileInfoRichTextBox.TabIndex = 3;
            this.FileInfoRichTextBox.TabStop = false;
            this.FileInfoRichTextBox.Text = "";
            // 
            // ISConfirmAbortButtons
            // 
            this.ISConfirmAbortButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ISConfirmAbortButtons.Location = new System.Drawing.Point(12, 309);
            this.ISConfirmAbortButtons.MinimumSize = new System.Drawing.Size(120, 25);
            this.ISConfirmAbortButtons.Name = "ISConfirmAbortButtons";
            this.ISConfirmAbortButtons.Size = new System.Drawing.Size(128, 28);
            this.ISConfirmAbortButtons.TabIndex = 1;
            this.ISConfirmAbortButtons.ConfirmBtnClick += new RSImage.CommonControls.ConfirmAbortButtons.ConfirmBtnClickEventHander(this.ISConfirmAbortButtons_ConfirmBtnClick);
            this.ISConfirmAbortButtons.AbortBtnClick += new RSImage.CommonControls.ConfirmAbortButtons.AbortBtnClickEventHander(this.ISConfirmAbortButtons_AbortBtnClick);
            // 
            // frmImgSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 349);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.InputFileGroupBox);
            this.Controls.Add(this.ISConfirmAbortButtons);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmImgSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmImgSelect_Load);
            this.InputFileGroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonControls.ConfirmAbortButtons ISConfirmAbortButtons;
        private System.Windows.Forms.ListView InputFileListView;
        private System.Windows.Forms.GroupBox InputFileGroupBox;
        private System.Windows.Forms.Label InputFileLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox FileInfoRichTextBox;
        private System.Windows.Forms.Label FileInfoLabel;
    }
}