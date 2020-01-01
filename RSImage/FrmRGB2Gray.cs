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
    public partial class FrmRGB2Gray : Form
    {
        public double[] RGBValues;
        public FrmRGB2Gray(Img img)
        {
            InitializeComponent();
            if (img.IsGrayscale)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                throw new ArgumentException("选择的影像为单波段影像。");
            }
        }

        private void FrmRGB2Gray_Load(object sender, EventArgs e)
        {
            R2GFilePathSelector.Filter = "All files|*.*|GeoTIFF files|*.tif";
            R2GFilePathSelector.FilterIndex = 2;
        }

        private void R2GConfirmAbortButtons_ConfirmBtnClick(object sender, EventArgs e)
        {
            RGBValues = new double[3] { RValueSelector.Value, GValueSelector.Value, BValueSelector.Value };         
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void R2GConfirmAbortButtons_AbortBtnClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
