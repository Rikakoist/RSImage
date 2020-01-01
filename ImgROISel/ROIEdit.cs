using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImgROISel
{
    public partial class ROIEdit : Form
    {
        public Color ROIColor;
        public string ROIName;

        public ROIEdit()
        {
            InitializeComponent();
        }

        private void ROIEdit_Load(object sender, EventArgs e)
        {
            Random r = new Random(DateTime.Now.Second);
            ROIColorPictureBox.BackColor = Color.FromArgb(r.Next(0,255), r.Next(0, 255), r.Next(0, 255));
        }

        private void ROINameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ROINameTextBox.Text))
            {
                ConfirmButton.Enabled = false;
                ConfirmButton.Cursor = Cursors.No;
            }
            else
            {
                ConfirmButton.Enabled =true;
                ConfirmButton.Cursor = Cursors.Hand;
            }
        }

        private void ROIColorPictureBox_Click(object sender, EventArgs e)
        {
            ColorDialog CD = new ColorDialog()
            {
                FullOpen = true,
                Color = ROIColorPictureBox.BackColor,
            };
            if(CD.ShowDialog()==DialogResult.OK)
            {
                ROIColorPictureBox.BackColor = CD.Color;
            }
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            ROIColor = ROIColorPictureBox.BackColor;
            ROIName = ROINameTextBox.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void AbortButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
