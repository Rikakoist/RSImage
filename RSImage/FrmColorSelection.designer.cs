namespace RSImage
{
    partial class FrmColorSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmColorSelection));
            this.FromColorPictureBox = new System.Windows.Forms.PictureBox();
            this.ToColorPictureBox = new System.Windows.Forms.PictureBox();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.AbortButton = new System.Windows.Forms.Button();
            this.FromColorGroupBox = new System.Windows.Forms.GroupBox();
            this.PreviewGroupBox = new System.Windows.Forms.GroupBox();
            this.FromColorLabel = new System.Windows.Forms.Label();
            this.ToColorGroupBox = new System.Windows.Forms.GroupBox();
            this.ToColorLabel = new System.Windows.Forms.Label();
            this.StartLabel = new System.Windows.Forms.Label();
            this.EndLabel = new System.Windows.Forms.Label();
            this.PreviewPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FromColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToColorPictureBox)).BeginInit();
            this.FromColorGroupBox.SuspendLayout();
            this.ToColorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // FromColorPictureBox
            // 
            this.FromColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FromColorPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FromColorPictureBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.FromColorPictureBox.Location = new System.Drawing.Point(100, 21);
            this.FromColorPictureBox.Name = "FromColorPictureBox";
            this.FromColorPictureBox.Size = new System.Drawing.Size(88, 101);
            this.FromColorPictureBox.TabIndex = 0;
            this.FromColorPictureBox.TabStop = false;
            this.FromColorPictureBox.Click += new System.EventHandler(this.FromColorPictureBox_Click);
            // 
            // ToColorPictureBox
            // 
            this.ToColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ToColorPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ToColorPictureBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.ToColorPictureBox.Location = new System.Drawing.Point(102, 21);
            this.ToColorPictureBox.Name = "ToColorPictureBox";
            this.ToColorPictureBox.Size = new System.Drawing.Size(86, 101);
            this.ToColorPictureBox.TabIndex = 0;
            this.ToColorPictureBox.TabStop = false;
            this.ToColorPictureBox.Click += new System.EventHandler(this.ToColorPictureBox_Click);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConfirmButton.Location = new System.Drawing.Point(205, 193);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(89, 32);
            this.ConfirmButton.TabIndex = 1;
            this.ConfirmButton.Text = "确定";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // AbortButton
            // 
            this.AbortButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AbortButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AbortButton.Location = new System.Drawing.Point(310, 193);
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.Size = new System.Drawing.Size(89, 32);
            this.AbortButton.TabIndex = 0;
            this.AbortButton.Text = "取消";
            this.AbortButton.UseVisualStyleBackColor = true;
            this.AbortButton.Click += new System.EventHandler(this.AbortButton_Click);
            // 
            // FromColorGroupBox
            // 
            this.FromColorGroupBox.Controls.Add(this.PreviewGroupBox);
            this.FromColorGroupBox.Controls.Add(this.FromColorLabel);
            this.FromColorGroupBox.Controls.Add(this.FromColorPictureBox);
            this.FromColorGroupBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FromColorGroupBox.Location = new System.Drawing.Point(12, 12);
            this.FromColorGroupBox.Name = "FromColorGroupBox";
            this.FromColorGroupBox.Size = new System.Drawing.Size(191, 125);
            this.FromColorGroupBox.TabIndex = 2;
            this.FromColorGroupBox.TabStop = false;
            this.FromColorGroupBox.Text = "起始颜色";
            // 
            // PreviewGroupBox
            // 
            this.PreviewGroupBox.Location = new System.Drawing.Point(89, 132);
            this.PreviewGroupBox.Name = "PreviewGroupBox";
            this.PreviewGroupBox.Size = new System.Drawing.Size(233, 76);
            this.PreviewGroupBox.TabIndex = 5;
            this.PreviewGroupBox.TabStop = false;
            this.PreviewGroupBox.Text = "预览";
            // 
            // FromColorLabel
            // 
            this.FromColorLabel.AutoSize = true;
            this.FromColorLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.FromColorLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FromColorLabel.Location = new System.Drawing.Point(3, 21);
            this.FromColorLabel.Name = "FromColorLabel";
            this.FromColorLabel.Size = new System.Drawing.Size(84, 19);
            this.FromColorLabel.TabIndex = 1;
            this.FromColorLabel.Text = "FromARGB";
            // 
            // ToColorGroupBox
            // 
            this.ToColorGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToColorGroupBox.Controls.Add(this.ToColorLabel);
            this.ToColorGroupBox.Controls.Add(this.ToColorPictureBox);
            this.ToColorGroupBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToColorGroupBox.Location = new System.Drawing.Point(211, 12);
            this.ToColorGroupBox.Name = "ToColorGroupBox";
            this.ToColorGroupBox.Size = new System.Drawing.Size(191, 125);
            this.ToColorGroupBox.TabIndex = 3;
            this.ToColorGroupBox.TabStop = false;
            this.ToColorGroupBox.Text = "终止颜色";
            // 
            // ToColorLabel
            // 
            this.ToColorLabel.AutoSize = true;
            this.ToColorLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ToColorLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToColorLabel.Location = new System.Drawing.Point(3, 21);
            this.ToColorLabel.Name = "ToColorLabel";
            this.ToColorLabel.Size = new System.Drawing.Size(67, 19);
            this.ToColorLabel.TabIndex = 1;
            this.ToColorLabel.Text = "ToARGB";
            // 
            // StartLabel
            // 
            this.StartLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StartLabel.AutoSize = true;
            this.StartLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartLabel.Location = new System.Drawing.Point(16, 154);
            this.StartLabel.Name = "StartLabel";
            this.StartLabel.Size = new System.Drawing.Size(23, 20);
            this.StartLabel.TabIndex = 4;
            this.StartLabel.Text = "小";
            // 
            // EndLabel
            // 
            this.EndLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EndLabel.AutoSize = true;
            this.EndLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndLabel.Location = new System.Drawing.Point(379, 154);
            this.EndLabel.Name = "EndLabel";
            this.EndLabel.Size = new System.Drawing.Size(23, 20);
            this.EndLabel.TabIndex = 4;
            this.EndLabel.Text = "大";
            // 
            // PreviewPictureBox
            // 
            this.PreviewPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PreviewPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PreviewPictureBox.Location = new System.Drawing.Point(45, 154);
            this.PreviewPictureBox.Name = "PreviewPictureBox";
            this.PreviewPictureBox.Size = new System.Drawing.Size(328, 21);
            this.PreviewPictureBox.TabIndex = 5;
            this.PreviewPictureBox.TabStop = false;
            // 
            // FrmColorSelection
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(414, 237);
            this.Controls.Add(this.PreviewPictureBox);
            this.Controls.Add(this.EndLabel);
            this.Controls.Add(this.StartLabel);
            this.Controls.Add(this.ToColorGroupBox);
            this.Controls.Add(this.FromColorGroupBox);
            this.Controls.Add(this.AbortButton);
            this.Controls.Add(this.ConfirmButton);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FrmColorSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置色带起止颜色";
            this.Load += new System.EventHandler(this.SelectionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FromColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToColorPictureBox)).EndInit();
            this.FromColorGroupBox.ResumeLayout(false);
            this.FromColorGroupBox.PerformLayout();
            this.ToColorGroupBox.ResumeLayout(false);
            this.ToColorGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox FromColorPictureBox;
        private System.Windows.Forms.PictureBox ToColorPictureBox;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Button AbortButton;
        private System.Windows.Forms.GroupBox FromColorGroupBox;
        private System.Windows.Forms.GroupBox ToColorGroupBox;
        private System.Windows.Forms.Label FromColorLabel;
        private System.Windows.Forms.Label ToColorLabel;
        private System.Windows.Forms.GroupBox PreviewGroupBox;
        private System.Windows.Forms.Label StartLabel;
        private System.Windows.Forms.Label EndLabel;
        private System.Windows.Forms.PictureBox PreviewPictureBox;
    }
}