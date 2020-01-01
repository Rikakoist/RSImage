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
    public partial class NumericSelector : UserControl
    {
        [Description("数字编辑器的标题"), Category("自定义")]
        public string Title { get; set; } = "值";
        [Description("数值选择框的最小值"), Category("自定义")]
        public int Min { get; set; } = 0;
        [Description("数值选择框的最大值"), Category("自定义")]
        public int Max { get; set; } = 10;
        [Description("数值选择框的值"), Category("自定义")]
        public int Value { get; set; } = 1;

        public NumericSelector()
        {
            InitializeComponent();
        }

        private void NumericSelector_Load(object sender, EventArgs e)
        {
            NLabel.Text = Title;
            if (Min > Max)
            {
                int tmp = Max;
                Max = Min;
                Min = tmp;
            }
            NNumericUpDown.Maximum = Max;
            NNumericUpDown.Minimum = Min;
            NNumericUpDown.Value = Value > Max ? Max : (Value < Min ? Min : Value);
        }

        private void NNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Value = (int)NNumericUpDown.Value;
        }
    }
}
