using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Roughness
{
    public partial class RoughnessForm : Form
    {
        public RoughnessForm()
        {
            InitializeComponent();
        }
        Thread BgCal;
        List<string[]> ReplaceList = new List<string[]>();
        bool IsProcessing = false;
        string OutPutFileName;

        //用户选择文件路径
        private void GetFilePath(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog OFD = new OpenFileDialog
                {
                    InitialDirectory = Environment.SpecialFolder.Desktop.ToString(),
                    CheckFileExists = true,
                    Filter = "asc Files (*.asc)|*.asc",
                    FilterIndex = 1,
                };
                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    FilePathTextBox.Text = OFD.FileName;
                    GetFileHead();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void ExitApp(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //转换操作控制
        private void GetR(object sender, EventArgs e)
        {
            try
            {
               
                StartConvertButton.Enabled = false; //临时禁用转换按钮
                
                if(String.IsNullOrWhiteSpace(FilePathTextBox.Text)) //检查文件路径
                {
                    throw new NoNullAllowedException("请输入文件路径！");
                }
                OutPutFileName = FilePathTextBox.Text.Substring(0, FilePathTextBox.Text.LastIndexOf('.')) + "_out.asc";
                switch (ModeTabControl.SelectedIndex)
                {
                    case 0:
                        {
                            if (String.IsNullOrWhiteSpace(RoughnessTextBox.Text) || String.IsNullOrWhiteSpace(NoDataValueTextBox.Text)) //检查数值框
                            {
                                throw new NoNullAllowedException("输入的糙率或NoData值不正确！");
                            }
                            break;
                        }
                    case 1:
                        {
                            if(ValuesDataGridView.RowCount<2)
                            {
                                throw new Exception("无数据。");
                            }
                            ReplaceList.Clear();
                            for (int i = 0; i < ValuesDataGridView.RowCount - 1; i++)
                            {
                                string[] ReplaceItem = new string[2] { ValuesDataGridView[0, i].Value.ToString(), ValuesDataGridView[2, i].Value.ToString() };
                                ReplaceList.Add(ReplaceItem);
                            }

                            break;
                        }
                    default:
                        {
                            throw new Exception("???");
                        }
                }
                //输出文件路径及名称
                if (sender == StartConvertButton)    //转换按钮事件
                {
                    //文件覆盖检查
                    if (File.Exists(OutPutFileName))
                    {  
                        if(MessageBox.Show(FilePathTextBox.Text+"已存在，是否覆盖？","",MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)==DialogResult.OK)
                        {
                            StartThread();
                        }
                        else
                        {
                            StopProcessing();
                        }
                    }
                    else
                    {
                        StartThread();
                    }  
                }
                if (sender == CancelConvertButton) //取消按钮事件
                {
                    if (MessageBox.Show("是否取消当前转换任务？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        if (BgCal.IsAlive)
                        {
                            BgCal.Abort();
                            StopProcessing();
                            ProgressLabel.Text = "你烟了";
                            ConvertProgressBar.ForeColor = Color.Red;
                        }
                    }
                }
            }
            catch (NoNullAllowedException err)
            {
                MessageBox.Show(err.Message);
                StopProcessing();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                StopProcessing();
            }
        }

        //开始转换线程方法
        private void StartThread()
        {
            BgCal = new Thread(Calc)
            {
                Priority = ThreadPriority.Normal
            };
            BgCal.Start();  //在新线程上执行转换任务，不会卡界面
            StartProcessing();
        }

        //转换线程调用方法
        private void Calc()
        {
            try
            {
                string CurrentLine = null;  //当前行字符串
                double CLine = 0;   //当前行指示器
                double TLine = 0;   //总行数指示器

                using (StreamReader sr = new StreamReader(FilePathTextBox.Text))
                {
                    //读取行数及跳过文件头
                    for (int i = 0; i < 6; i++)
                    {
                        CurrentLine = sr.ReadLine();
                        if (i == 1)
                        {
                            TLine = Convert.ToInt32(CurrentLine.Substring(14).Replace("\r\n", String.Empty)); //自动读取行数
                        }
                    }

                    //写文件头
                    var OutPutEncoding = new UTF8Encoding(false);
                    using (StreamWriter sw = new StreamWriter(OutPutFileName, false, OutPutEncoding))
                    {
                        sw.Write(FileContentRichTextBox.Text);
                    }
                    using (StreamWriter sw = new StreamWriter(OutPutFileName, true, OutPutEncoding))
                    {

                        while ((CurrentLine = sr.ReadLine()) != null)   //读取直到文档末尾
                        {
                            string[] DEMValues = CurrentLine.Split(' ');    //拆分当前行
                            string Converted;
                            for (long j = 0; j < DEMValues.Length - 1; j++)
                            {
                                switch (ModeTabControl.SelectedIndex)
                                {
                                    case 0:
                                        {
                                            if (DEMValues[j] != NoDataValueTextBox.Text)
                                            {
                                                DEMValues[j] = RoughnessTextBox.Text;
                                            }
                                            break;
                                        }
                                    case 1:
                                        {
                                            if (DEMValues[j] == NoDataValueTextBox.Text)
                                            {
                                                continue;
                                            }
                                            int i;
                                            for (i = 0; i < ReplaceList.Count; i++)
                                            {
                                                if (DEMValues[j] == ReplaceList[i][0])
                                                {
                                                    DEMValues[j] = ReplaceList[i][1];
                                                    break;
                                                }
                                            }
                                            if (i == ReplaceList.Count)
                                            {
                                                DEMValues[j] = "0.03";
                                            }
                                            break;
                                        }
                                }

                            }
                            Converted = String.Join(" ", DEMValues);
                            //Converted += " ";

                            sw.WriteLine(Converted);
                            CLine++;
                            ConvertProgressBar.Value = (CLine / TLine) * 100 <= 100 ? Convert.ToInt32((CLine / TLine) * 100) : 100;
                            ProgressLabel.Text = "Processing: " + CLine.ToString() + " / " + TLine.ToString();
                            this.Refresh();
                            if (CLine >= TLine)
                            {
                                StopProcessing();
                            }
                        }
                    }
                }
            }
            catch (ThreadAbortException)
            {
                StopProcessing();
            }
        }

        //获取文件头
        private void GetFileHead()
        {
            FileContentRichTextBox.Clear();
            using (StreamReader sr = new StreamReader(FilePathTextBox.Text))
            {
                for (int i = 0; i < 6; i++)
                {
                    string CurrentLine = sr.ReadLine();
                    if (i == 5)
                    {
                        double TLine = Convert.ToDouble(CurrentLine.Substring(14).Replace("\r\n", String.Empty)); //自动读取NoDATA值
                        NoDataValueTextBox.Text = TLine.ToString();
                    }
                    FileContentRichTextBox.Text += CurrentLine + "\r\n";
                    this.Refresh();
                }
            }
        }

        //设置拖放模式
        private void PreDragDrop(object sender, DragEventArgs e)
        {
             e.Effect = DragDropEffects.Copy;
        }

        //拖放文件获取路径
        private void DragToLocateFile(object sender, DragEventArgs e)
        {
            try
            {             
                if (!IsProcessing)
                {
                    string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
                    if (files.GetLength(0) > 1)
                    {
                        throw new Exception("每次仅可加载一个数据文件！");
                    }
                    var Extension = System.IO.Path.GetExtension(files[0]);
                    if (Extension.Equals(".asc", StringComparison.CurrentCultureIgnoreCase))
                    {
                        FilePathTextBox.Text = System.IO.Path.GetFullPath(files[0]);   //定位到当前文件夹 
                        GetFileHead();
                    }
                    else
                    {
                        throw new Exception("请选择.asc文件！");
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                StopProcessing();
            }
        }

        //开始处理的按钮状态
        private void StartProcessing()
        {
            IsProcessing = true;
            ModeTabControl.Enabled = false;
            ModeTabControl.Cursor = Cursors.No;
            StartConvertButton.Enabled = false;
            StartConvertButton.Cursor = Cursors.No;
            CancelConvertButton.Enabled = true;
            CancelConvertButton.Cursor = Cursors.Hand;
        }

        //停止处理的按钮状态
        private void StopProcessing()
        {
            IsProcessing = false;
            ModeTabControl.Enabled = true;
            ModeTabControl.Cursor = Cursors.Arrow;
            StartConvertButton.Enabled = true;
            StartConvertButton.Cursor = Cursors.Hand;
            CancelConvertButton.Enabled = false;
            CancelConvertButton.Cursor = Cursors.No;
        }

        private void ShowAuthor(object sender, EventArgs e)
        {
            MessageBox.Show("DEM转糙率程序，由Rikakoist制作。更多工具请访问https://github.com/Rikakoist。", "2333~", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void ClickToDeleteRow(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1 && e.RowIndex < ValuesDataGridView.Rows.Count - 1)
                {
                    ValuesDataGridView.Rows.RemoveAt(e.RowIndex);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }
    }
}
