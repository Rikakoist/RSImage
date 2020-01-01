namespace RSImage
{
    partial class FrmApplyGainOffset
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmApplyGainOffset));
            this.OffsetValueEditor = new RSImage.ValueEditor();
            this.GainValueEditor = new RSImage.ValueEditor();
            this.AGOFilePathSelector = new RSImage.FilePathSelector();
            this.AGOConfirmAbortButtons = new RSImage.CommonControls.ConfirmAbortButtons();
            this.SuspendLayout();
            // 
            // OffsetValueEditor
            // 
            this.OffsetValueEditor.BandCount = 0;
            this.OffsetValueEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OffsetValueEditor.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OffsetValueEditor.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.OffsetValueEditor.Location = new System.Drawing.Point(246, 13);
            this.OffsetValueEditor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OffsetValueEditor.Name = "OffsetValueEditor";
            this.OffsetValueEditor.ResetNum = 0D;
            this.OffsetValueEditor.Size = new System.Drawing.Size(228, 210);
            this.OffsetValueEditor.TabIndex = 1;
            this.OffsetValueEditor.Title = "Offset";
            // 
            // GainValueEditor
            // 
            this.GainValueEditor.BandCount = 0;
            this.GainValueEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GainValueEditor.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GainValueEditor.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.GainValueEditor.Location = new System.Drawing.Point(12, 13);
            this.GainValueEditor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GainValueEditor.Name = "GainValueEditor";
            this.GainValueEditor.ResetNum = 1D;
            this.GainValueEditor.Size = new System.Drawing.Size(228, 210);
            this.GainValueEditor.TabIndex = 0;
            this.GainValueEditor.Title = "Gain";
            // 
            // AGOFilePathSelector
            // 
            this.AGOFilePathSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AGOFilePathSelector.Filter = "All files|*.*";
            this.AGOFilePathSelector.FilterIndex = 1;
            this.AGOFilePathSelector.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AGOFilePathSelector.Location = new System.Drawing.Point(12, 232);
            this.AGOFilePathSelector.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AGOFilePathSelector.MinimumSize = new System.Drawing.Size(290, 110);
            this.AGOFilePathSelector.Name = "AGOFilePathSelector";
            this.AGOFilePathSelector.OutDataType = OSGeo.GDAL.DataType.GDT_Float32;
            this.AGOFilePathSelector.Path = null;
            this.AGOFilePathSelector.Size = new System.Drawing.Size(298, 116);
            this.AGOFilePathSelector.TabIndex = 2;
            this.AGOFilePathSelector.Title = "选择保存位置";
            this.AGOFilePathSelector.WorkFolder = "MyDocuments";
            // 
            // AGOConfirmAbortButtons
            // 
            this.AGOConfirmAbortButtons.Location = new System.Drawing.Point(326, 319);
            this.AGOConfirmAbortButtons.MinimumSize = new System.Drawing.Size(120, 30);
            this.AGOConfirmAbortButtons.Name = "AGOConfirmAbortButtons";
            this.AGOConfirmAbortButtons.Size = new System.Drawing.Size(142, 30);
            this.AGOConfirmAbortButtons.TabIndex = 3;
            this.AGOConfirmAbortButtons.ConfirmBtnClick += new RSImage.CommonControls.ConfirmAbortButtons.ConfirmBtnClickEventHander(this.AGOConfirmAbortButtons_ConfirmBtnClick);
            this.AGOConfirmAbortButtons.AbortBtnClick += new RSImage.CommonControls.ConfirmAbortButtons.AbortBtnClickEventHander(this.AGOConfirmAbortButtons_AbortBtnClick);
            // 
            // frmApplyGainOffset
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.AGOConfirmAbortButtons);
            this.Controls.Add(this.OffsetValueEditor);
            this.Controls.Add(this.GainValueEditor);
            this.Controls.Add(this.AGOFilePathSelector);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 398);
            this.Name = "frmApplyGainOffset";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "辐射定标";
            this.Load += new System.EventHandler(this.FormLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private FilePathSelector AGOFilePathSelector;
        private ValueEditor GainValueEditor;
        private ValueEditor OffsetValueEditor;
        private CommonControls.ConfirmAbortButtons AGOConfirmAbortButtons;
    }
}