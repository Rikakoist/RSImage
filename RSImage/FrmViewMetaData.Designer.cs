namespace RSImage
{
    partial class FrmViewMetaData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmViewMetaData));
            this.MetaDataTreeView = new System.Windows.Forms.TreeView();
            this.FileInfoTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // MetaDataTreeView
            // 
            this.MetaDataTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MetaDataTreeView.Location = new System.Drawing.Point(12, 174);
            this.MetaDataTreeView.Name = "MetaDataTreeView";
            this.MetaDataTreeView.Size = new System.Drawing.Size(533, 241);
            this.MetaDataTreeView.TabIndex = 0;
            // 
            // FileInfoTextBox
            // 
            this.FileInfoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileInfoTextBox.Location = new System.Drawing.Point(12, 12);
            this.FileInfoTextBox.Multiline = true;
            this.FileInfoTextBox.Name = "FileInfoTextBox";
            this.FileInfoTextBox.ReadOnly = true;
            this.FileInfoTextBox.Size = new System.Drawing.Size(533, 156);
            this.FileInfoTextBox.TabIndex = 1;
            // 
            // FrmViewMetaData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 427);
            this.Controls.Add(this.FileInfoTextBox);
            this.Controls.Add(this.MetaDataTreeView);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "FrmViewMetaData";
            this.Load += new System.EventHandler(this.FrmViewMetaData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView MetaDataTreeView;
        private System.Windows.Forms.TextBox FileInfoTextBox;
    }
}