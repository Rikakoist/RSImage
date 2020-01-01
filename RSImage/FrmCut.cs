using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSImage
{
    public partial class FrmCut : Form
    {
        public int ImgWidth = 1;
        public int ImgHeight = 1;
        public string OutPath = string.Empty;

        public FrmCut(int Width, int Height, string Title = "影像裁剪设置")
        {
            InitializeComponent();
            this.Text = Title;
            this.WidthLabel.Text = "输入影像宽：" + Width.ToString();
            this.HeightLabel.Text = "输入影像高：" + Height.ToString();
        }

        private void CConfirmAbortButtons1_ConfirmBtnClick(object sender, EventArgs e)
        {
            ImgWidth = WidthNumericSelector.Value;
            ImgHeight = HeightNumericSelector.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CConfirmAbortButtons1_AbortBtnClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void PathButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if(FBD.ShowDialog()==DialogResult.OK)
            {
                PathTextBox.Text = FBD.SelectedPath;
            }
        }

        private void PathTextBox_TextChanged(object sender, EventArgs e)
        {
            OutPath = PathTextBox.Text;
        }
    }
}
