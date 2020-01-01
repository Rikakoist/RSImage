namespace ImgROISel
{
    partial class ROIEdit
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
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.AbortButton = new System.Windows.Forms.Button();
            this.ROINameLabel = new System.Windows.Forms.Label();
            this.ROINameTextBox = new System.Windows.Forms.TextBox();
            this.ROIColorPictureBox = new System.Windows.Forms.PictureBox();
            this.ROIColorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ROIColorPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ConfirmButton.Cursor = System.Windows.Forms.Cursors.No;
            this.ConfirmButton.Enabled = false;
            this.ConfirmButton.Location = new System.Drawing.Point(49, 119);
            this.ConfirmButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(68, 26);
            this.ConfirmButton.TabIndex = 1;
            this.ConfirmButton.Text = "确认";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // AbortButton
            // 
            this.AbortButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AbortButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AbortButton.Location = new System.Drawing.Point(142, 119);
            this.AbortButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.Size = new System.Drawing.Size(68, 26);
            this.AbortButton.TabIndex = 2;
            this.AbortButton.Text = "取消";
            this.AbortButton.UseVisualStyleBackColor = true;
            this.AbortButton.Click += new System.EventHandler(this.AbortButton_Click);
            // 
            // ROINameLabel
            // 
            this.ROINameLabel.AutoSize = true;
            this.ROINameLabel.Location = new System.Drawing.Point(31, 32);
            this.ROINameLabel.Name = "ROINameLabel";
            this.ROINameLabel.Size = new System.Drawing.Size(44, 17);
            this.ROINameLabel.TabIndex = 1;
            this.ROINameLabel.Text = "名称：";
            // 
            // ROINameTextBox
            // 
            this.ROINameTextBox.Location = new System.Drawing.Point(81, 29);
            this.ROINameTextBox.Name = "ROINameTextBox";
            this.ROINameTextBox.Size = new System.Drawing.Size(127, 23);
            this.ROINameTextBox.TabIndex = 0;
            this.ROINameTextBox.TextChanged += new System.EventHandler(this.ROINameTextBox_TextChanged);
            // 
            // ROIColorPictureBox
            // 
            this.ROIColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ROIColorPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ROIColorPictureBox.Location = new System.Drawing.Point(81, 73);
            this.ROIColorPictureBox.Name = "ROIColorPictureBox";
            this.ROIColorPictureBox.Size = new System.Drawing.Size(127, 31);
            this.ROIColorPictureBox.TabIndex = 3;
            this.ROIColorPictureBox.TabStop = false;
            this.ROIColorPictureBox.Click += new System.EventHandler(this.ROIColorPictureBox_Click);
            // 
            // ROIColorLabel
            // 
            this.ROIColorLabel.AutoSize = true;
            this.ROIColorLabel.Location = new System.Drawing.Point(31, 80);
            this.ROIColorLabel.Name = "ROIColorLabel";
            this.ROIColorLabel.Size = new System.Drawing.Size(44, 17);
            this.ROIColorLabel.TabIndex = 1;
            this.ROIColorLabel.Text = "颜色：";
            // 
            // ROIEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 160);
            this.Controls.Add(this.ROIColorPictureBox);
            this.Controls.Add(this.ROINameTextBox);
            this.Controls.Add(this.ROIColorLabel);
            this.Controls.Add(this.ROINameLabel);
            this.Controls.Add(this.AbortButton);
            this.Controls.Add(this.ConfirmButton);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ROIEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "编辑ROI";
            this.Load += new System.EventHandler(this.ROIEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ROIColorPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Button AbortButton;
        private System.Windows.Forms.Label ROINameLabel;
        private System.Windows.Forms.TextBox ROINameTextBox;
        private System.Windows.Forms.PictureBox ROIColorPictureBox;
        private System.Windows.Forms.Label ROIColorLabel;
    }
}