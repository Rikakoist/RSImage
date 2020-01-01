using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSImage
{
    public partial class ValueEditor : UserControl
    {
        [Description("数值编辑器的标题"), Category("自定义")]
        public string Title { get; set; } = "Not set";
        [Description("影像的波段数"), Category("自定义")]
        public int BandCount { get; set; } = 0;
        [Description("按下\"重置\"按钮的时候恢复到的值"), Category("自定义")]
        public double ResetNum { get; set; } = 0;

        private int CurrentBand;
        public List<double> BandValues = new List<double>();

        public ValueEditor()
        {
            InitializeComponent();
        }

        //Load事件
        private void ControlLoad(object sender, EventArgs e)
        {
            if (BandCount < 1)
                this.Enabled = false;
            Reset();
            TitleLabel.Text = Title;
        }

        //重置和刷新ListView操作
        public void Reset()
        {
            if (BandCount > 0)
            {
                BandValues.Clear();
                ValuesListView.Clear();
                BandTextBox.Clear();
                ValueTextBox.Clear();
                for (int i = 0; i < BandCount; i++)
                {
                    BandValues.Add(ResetNum);
                }
                for (int i = 0; i < BandCount; i++)
                {
                    ValuesListView.Items.Add("Band" + (i + 1).ToString() + " " + BandValues[i].ToString("0.000000"));
                }
            }
        }
        private void Reset(object sender, EventArgs e)
        {
            Reset();
        }
        private void RefreshListView()
        {
            for (int i = 0; i < BandCount; i++)
            {
                ValuesListView.Items[i].Text = "Band" + (i + 1).ToString() + " " + BandValues[i].ToString("0.000000");
            }
        }

        //ValuesListView的SelectedIndexChanged事件
        private void StartEdit(object sender, EventArgs e)
        {
            try
            {
                if (ValuesListView.SelectedItems.Count > 0)
                {
                    BandTextBox.Text = "Band " + (ValuesListView.SelectedIndices[0] + 1).ToString();
                    ValueTextBox.Text = BandValues[ValuesListView.SelectedIndices[0]].ToString("0.000000");
                    CurrentBand = ValuesListView.SelectedIndices[0];
                    ValueTextBox.Focus();
                    ValueTextBox.SelectAll();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        //ValuesListView的MouseClick事件
        private void StartEdit2(object sender, MouseEventArgs e)
        {
            StartEdit(null, null);
        }

        //ValueTextBox的KeyDown事件
        private void EndEdit(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                ValuesListView.Focus();
                if (CurrentBand + 1 == BandCount)
                {
                    ValuesListView.Items[0].Selected = true;
                }
                else
                {
                    ValuesListView.Items[CurrentBand + 1].Selected = true;
                }
            }
            //if (e.KeyCode == Keys.Up)
            //{
            //    ValuesListView.Focus();
            //    if (CurrentBand == 0)
            //    {
            //        ValuesListView.Items[BandCount-1].Selected = true;
            //    }
            //    else
            //    {
            //        ValuesListView.Items[CurrentBand -1].Selected = true;
            //    }
            //}
        }

        //ValueTextBox的Leave事件
        private void ChangeBandValue(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(ValueTextBox.Text) && (!String.IsNullOrWhiteSpace(BandTextBox.Text)))
                {
                    if (double.TryParse(ValueTextBox.Text, out double Value))
                    {
                        BandValues[CurrentBand] = Value;
                    }
                }
                RefreshListView();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
