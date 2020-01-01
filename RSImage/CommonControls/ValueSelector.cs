using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSImage.CommonControls
{
    public partial class ValueSelector : UserControl
    {
        [Description("值编辑器的标题"), Category("自定义")]
        public string Title { get; set; } = "值";
        [Description("文本框可输入的最小值"), Category("自定义")]
        public double Min { get; set; } = 0.0;
        [Description("文本框可输入的最大值"), Category("自定义")]
        public double Max { get; set; } = 10.0;
        [Description("文本框的值"), Category("自定义")]
        public double Value { get; set; } = 5.0;
        [Description("滚动条的值与文本框的值的比值"), Category("自定义")]
        public double Ratio { get; set; } = 1;

        public ValueSelector()
        {
            InitializeComponent();
        }

        private void ValueSelector_Load(object sender, EventArgs e)
        {
            ValueLabel.Text = Title;
            if(Min>Max)
            {
                double tmp = Max;
                Max = Min;
                Min = tmp;
            }
            ValueTrackBar.Minimum = (int)(Min*Ratio);
            ValueTrackBar.Maximum = (int)(Max*Ratio);
            ValueTextBox.Text = Value.ToString("0.0000");
            Check();
        }

        private void ValueTrackBar_Scroll(object sender, EventArgs e)
        {
            ValueTextBox.Text = (ValueTrackBar.Value / Ratio).ToString("0.0000");
        }

        private void ValueTextBox_TextChanged(object sender, EventArgs e)
        {
            Double.TryParse(ValueTextBox.Text, out double Result);
            if(Result!=0)
            {
                Value = Result;
                Check();
            }
        }

        //验证值是否合法
        private void Check()
        {
            if (Value < Min)
                Value = Min;
            if (Value > Max)
                Value = Max;
            ValueTrackBar.Value = (int)(Value * Ratio);
        }
    }
}
