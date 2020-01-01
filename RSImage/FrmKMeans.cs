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
    public partial class FrmKMeans : Form
    {
        public int NumOfClass = 1;
        public double ChangeThreshold = 0.05;
        public int MaxIterate = 1;
        public string Path = null;
        public OSGeo.GDAL.DataType OutDataType = OSGeo.GDAL.DataType.GDT_Byte;

        public FrmKMeans()
        {
            InitializeComponent();
            KFilePathSelector.Filter = "All files|*.*|GeoTIFF files|*.tif";
            KFilePathSelector.FilterIndex = 2;
        }

        private void KConfirmAbortButtons_ConfirmBtnClick(object sender, EventArgs e)
        {
            NumOfClass = KNumericSelector.Value;
            ChangeThreshold = DifValueSelector.Value / 100;
            MaxIterate = IteraNumericSelector.Value;
            Path = KFilePathSelector.Path;
            OutDataType = KFilePathSelector.OutDataType;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void KConfirmAbortButtons_AbortBtnClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
