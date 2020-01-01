using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RSImage.Tools;
using RSImage.CommonControls;

namespace RSImage
{
    public partial class FrmApplyGainOffset : Form
    {
        int bandNum;
        public string OutPath;
        public OSGeo.GDAL.DataType OutDataType;
        public List<double> Gains;
        public List<double> Offsets;

        public FrmApplyGainOffset()
        {
            InitializeComponent();
        }

        public FrmApplyGainOffset(int BandNum)
        {
            InitializeComponent();
            this.bandNum = BandNum;
            GainValueEditor.BandCount = BandNum;
            OffsetValueEditor.BandCount = BandNum;
            AGOFilePathSelector.Filter = "All files|*.*|GeoTIFF files|*.tif";
            AGOFilePathSelector.FilterIndex = 2;
        }

        //Load
        private void FormLoad(object sender, EventArgs e)
        {
            if (bandNum < 1)
            {
                AGOFilePathSelector.Enabled = false;
                AGOConfirmAbortButtons.ConfirmButton.Enabled = false;
            }
        }

        private void AGOConfirmAbortButtons_ConfirmBtnClick(object sender, EventArgs e)
        {
            OutPath = AGOFilePathSelector.Path;
            OutDataType = AGOFilePathSelector.OutDataType;
            Gains = GainValueEditor.BandValues;
            Offsets = OffsetValueEditor.BandValues;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void AGOConfirmAbortButtons_AbortBtnClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
