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
using System.IO;

namespace RSImage
{
    public partial class FrmViewHistogram : Form
    {
        public string Path;
        public Img Image;
        public Color[] SeriesColor;
        private Color[] RGB = new Color[3] { Color.Red, Color.Green, Color.Blue };
        double xMin, xMax, yMax;


        public FrmViewHistogram(Img Image)
        {
            InitializeComponent();
            this.Image = Image;
        }

        //Load
        private void FormLoad(object sender, EventArgs e)
        {
            try
            {
                SeriesColor = new Color[Image.BandNum];
                BandSelectComboBox.Items.Add("总览");

                //添加Item
                for (int i = 0; i < Image.BandNum; i++)
                {
                    BandSelectComboBox.Items.Add("Band " + (i + 1).ToString());
                    SeriesColor[i] = Color.Gray;
                }
                if (!Image.IsGrayscale)
                {
                    //根据当前显示波段组合设置系列的颜色
                    for (int i = 0; i < 3; i++)
                    {
                        SeriesColor[Image.BandList[i] - 1] = RGB[i];
                    }
                }

                xMin = Image.Min[0];
                xMax = Image.Max[0];
                yMax = Image.Histogram[0].Max();
                BandHistogram.Series.Clear();
                //计算全局轴最大最小值、向表格添加系列
                for (int i = 0; i < Image.BandNum; i++)
                {
                    if (i > 0)
                    {
                        xMin = Math.Min(xMin, Image.Min[i]);
                        xMax = Math.Max(xMax, Image.Max[i]);
                        yMax = Math.Max(yMax, Image.Histogram[i].Max());
                    }
                    System.Windows.Forms.DataVisualization.Charting.Series S = new System.Windows.Forms.DataVisualization.Charting.Series()
                    {
                        Name = "Band" + (i + 1).ToString(),
                        Color = SeriesColor[i],
                        ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line,
                    };
                    BandHistogram.Series.Add(S);
                    for (int j = 0; j < Image.Histogram[i].Length; j++)
                        BandHistogram.Series[i].Points.AddXY(j + (int)Image.Min[i], Image.Histogram[i][j]);
                }
                BandSelectComboBox.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                this.Close();
                this.Dispose();
            }
        }

        //波段选择组框的SelectedIndexChanged事件，显示所选波段的直方图
        private void ChangeBand(object sender, EventArgs e)
        {
            //总览模式
            if (BandSelectComboBox.SelectedIndex == 0)
            {
                //恢复所有波段可见
                for (int i = 0; i < Image.BandNum; i++)
                    BandHistogram.Series[i].Enabled = true;

                //设置标签
                MinLabel.Text = "最小值：" + xMin.ToString("0.0000");
                MaxLabel.Text = "最大值：" + xMax.ToString("0.0000");
                MeanLabel.Text = "平均值："; //+ Image.DSHistogram[BandSelectComboBox.SelectedIndex - 1].Item4.ToString("0.0000");
                StddevLabel.Text = "标准差："; //+ Image.DSHistogram[BandSelectComboBox.SelectedIndex - 1].Item5.ToString("0.0000");

                //设置轴最大最小值
                BandHistogram.ChartAreas[0].Axes[0].Minimum = xMin;
                BandHistogram.ChartAreas[0].Axes[0].Maximum = xMax;
                BandHistogram.ChartAreas[0].Axes[1].Maximum = yMax;
                this.Text = "总览" + " - " + Path.Substring(Path.LastIndexOf("\\") + 1);
            }
            //单波段模式
            else
            {
                //设置仅当前波段可见
                for (int i = 1; i <= Image.BandNum; i++)
                {
                    if (i != BandSelectComboBox.SelectedIndex)
                        BandHistogram.Series[i - 1].Enabled = false;
                    else
                        BandHistogram.Series[i - 1].Enabled = true;
                }

                //设置标签
                MinLabel.Text = "最小值：" + Image.Min[BandSelectComboBox.SelectedIndex - 1].ToString("0.0000");
                MaxLabel.Text = "最大值：" + Image.Max[BandSelectComboBox.SelectedIndex - 1].ToString("0.0000");
                MeanLabel.Text = "平均值：" + Image.Mean[BandSelectComboBox.SelectedIndex - 1].ToString("0.0000");
                StddevLabel.Text = "标准差：" + Image.Stddev[BandSelectComboBox.SelectedIndex - 1].ToString("0.0000");

                //设置轴最大最小值
                BandHistogram.ChartAreas[0].Axes[0].Minimum = Image.Min[BandSelectComboBox.SelectedIndex - 1];
                BandHistogram.ChartAreas[0].Axes[0].Maximum = Image.Max[BandSelectComboBox.SelectedIndex - 1];
                BandHistogram.ChartAreas[0].Axes[1].Maximum = BandHistogram.Series[BandSelectComboBox.SelectedIndex - 1].Points.FindMaxByValue().YValues[0];
                this.Text = "Band " + (BandSelectComboBox.SelectedIndex).ToString() + " - " + Path.Substring(Path.LastIndexOf("\\") + 1);
            }
            //灰度图情况的标签，全部设置为第一波段的。
            if (Image.IsGrayscale)
            {
                MinLabel.Text = "最小值：" + Image.Min[0].ToString("0.0000");
                MaxLabel.Text = "最大值：" + Image.Max[0].ToString("0.0000");
                MeanLabel.Text = "平均值：" + Image.Mean[0].ToString("0.0000");
                StddevLabel.Text = "标准差：" + Image.Stddev[0].ToString("0.0000");
            }
            PixelCountLabel.Text = "像素：" + Image.PixelCount.ToString();
        }

        //SizeChanged事件，自动改变控件分布
        private void SizeChange(object sender, EventArgs e)
        {

        }

        //Closed事件
        private void FormClose(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
