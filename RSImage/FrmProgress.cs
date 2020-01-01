using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSImage
{
    public partial class FrmProgress : Form
    {
        //禁用窗体的关闭按钮
        //private const int CP_NOCLOSE_BUTTON = 0x200;
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams myCp = base.CreateParams;
        //        myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
        //        return myCp;
        //    }
        //}
        public bool CanCancel = true;
        public bool Canceled = false;
        public bool Log = false;
        private DateTime startTime;
        private DateTime endTime;

        public FrmProgress(bool Log = false)
        {
            InitializeComponent();
            startTime = DateTime.Now;
            this.Log = Log;
            //this.ControlBox = false;
        }

        private void FrmProgress_Load(object sender, EventArgs e)
        {
            AbortButton.Enabled = CanCancel ? true : false;
            this.ControlBox = CanCancel ? true : false;
            Output(startTime+" - 开始操作...");
        }

        public void SetProgress1(string Prefix, double Now, double Target,string Suffix)
        {
            FirstLabel.Text = Prefix + Now.ToString() + "/" + Target.ToString() + Suffix;
            FirstPBar.Value = (((int)(Now * 100.0 / Target)) > 100) ? 100 : ((((int)(Now * 100.0 / Target)) < 0) ? 0 : (int)(Now * 100.0 / Target));
            FirstLabel.Invalidate();
            FirstPBar.Invalidate();
        }

        public void SetProgress2(string Prefix, double Now, double Target, string Suffix)
        {
            SecondLabel.Text = Prefix + Now.ToString() + "/" + Target.ToString() + Suffix;
            SecondPBar.Value = (((int)(Now * 100.0 / Target)) > 100) ? 100 : ((((int)(Now * 100.0 / Target)) < 0) ? 0 : (int)(Now * 100.0 / Target));
            SecondLabel.Invalidate();
            SecondPBar.Invalidate();
        }

        public void CancelProgress()
        {
            FirstPBar.BackColor = Color.Red;
            SecondPBar.BackColor = Color.Red;
            FirstPBar.Invalidate();
            SecondPBar.Invalidate();
        }

        public void Output(string str)
        {
            OutText.Text += str + "\r\n";
            OutText.Select(OutText.TextLength, 0);
            OutText.ScrollToCaret();
            OutText.Invalidate();
        }

        public void Finish()
        {
            endTime = DateTime.Now;
            Output(endTime+" - 已完成，耗时"+(endTime-startTime));
            if (Log)
            {
                string logStr = Tools.Common.GetTempFileName(".log");
                StreamWriter FileWriter = new StreamWriter(logStr, true);
                FileWriter.Write(this.OutText.Text);
                FileWriter.Close();
            }
            Thread.Sleep(500);
            this.Close();
            this.Dispose();
        }

        private void AbortButton_Click(object sender, EventArgs e)
        {
            Canceled = true;
            AbortButton.Text = "正在取消...";
            AbortButton.Enabled = false;
            AbortButton.Cursor = Cursors.No;
            CancelProgress();
        }

        private void FrmProgress_FormClosing(object sender, FormClosingEventArgs e)
        {
            AbortButton_Click(null, null);
        }
    }
}
