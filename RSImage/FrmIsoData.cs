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
    public partial class FrmIsoData : Form
    {
        public int MinNumOfClass = 1;
        public int MaxNumOfClass = 1;
        public double ChangeThreshold = 0.05;
        public int MaxIterate = 1;
        public int MinPixCountInClass = 1;
        public double MaxClassStddev = 1.000;
        public double MinClassDistance = 5.000;
        public string Path = null;
        public OSGeo.GDAL.DataType OutDataType = OSGeo.GDAL.DataType.GDT_Byte;

        public FrmIsoData()
        {
            InitializeComponent();
            IDFilePathSelector.Filter = "All files|*.*|GeoTIFF files|*.tif";
            IDFilePathSelector.FilterIndex = 2;
        }

        private void IDConfirmAbortButtons_ConfirmBtnClick(object sender, EventArgs e)
        {
            try
            {
                MinNumOfClass = MinKindNumericSelector.Value;
                MaxNumOfClass = MaxKindNumericSelector.Value;
                ChangeThreshold = DifValueSelector.Value / 100;
                MaxIterate = IteraNumericSelector.Value;
                MinPixCountInClass = MinPixCountNumericSelector.Value;
                if (Double.TryParse(MaxClassStddevTextBox.Text, out MaxClassStddev))
                {
                    if (Double.TryParse(MinClassDisTextBox.Text, out MinClassDistance))
                    {
                        Path = IDFilePathSelector.Path;
                        OutDataType = IDFilePathSelector.OutDataType;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        throw new InvalidCastException("最小类间距离设置错误。");
                    }
                }
                else
                {
                    throw new InvalidCastException("最大类间方差设置错误。");
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void IDConfirmAbortButtons_AbortBtnClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
