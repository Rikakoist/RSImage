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
    public partial class FrmFlood : Form
    {
        public string InPath = string.Empty;
        public string OutPath = string.Empty;

        public FrmFlood()
        {
            InitializeComponent();
        }

        private void InPathButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                InPathTextBox.Text = FBD.SelectedPath;
            }
        }

        private void PathButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                OutPathTextBox.Text = FBD.SelectedPath;
            }
        }

        private void FConfirmAbortButtons_ConfirmBtnClick(object sender, EventArgs e)
        {
            InPath = InPathTextBox.Text;
            OutPath = OutPathTextBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FConfirmAbortButtons_AbortBtnClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
