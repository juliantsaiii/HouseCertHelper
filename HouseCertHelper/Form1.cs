using HouseCertHelper.Entity;
using HouseCertHelper.Tool;
using Newtonsoft.Json;
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

namespace HouseCertHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = ChooseCert();
        }


        public string ChooseCert()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "图像文件(*.jpg;*.png;*.gif;*.jpeg;*.bmp)|*.jpg;*.png;*.gif;*.jpeg;*.bmp";//过滤一下，只要图片格式的
            ofd.InitialDirectory = "c:\\";
            ofd.RestoreDirectory = true;
            ofd.FilterIndex = 1;
            ofd.AddExtension = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.ShowHelp = true;//是否显示帮助按钮
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                return ofd.FileName;
            }
            return "";
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            this.button2.Enabled = false;
            this.label2.Visible = true;
            new Thread(() => {
                try
                {
                    string Result = OCRHelper.CertHelper(this.textBox1.Text);
                    //string Result = OCRHelper.CertHelper();
                    Root root = Util.ToJson<Root>(Result);
                    string 共有情况 = root.data.共有情况;
                    string 土地权利性质_取得方式 = root.data.土地权利性质_取得方式;
                    string 坐落 = root.data.坐落;
                    string 建筑面积= root.data.建筑面积;
                    string 房产证号= root.data.房产证号;
                    string 房屋性质= root.data.房屋性质;
                    string 房屋用途 = root.data.房屋用途;
                    string 权利人 = root.data.权利人;
                    string 登记时间 = root.data.登记时间;
                    string ShowResult = @"房产证号:" + 房产证号 + "\r\n\r\n共有情况:" + 共有情况 + "\r\n\r\n土地权利性质_取得方式:" + 土地权利性质_取得方式 + "\r\n\r\n坐落:" + 坐落 + "\r\n\r\n建筑面积:" + 建筑面积 + "\r\n\r\n房屋性质:" + 房屋性质 + "\r\n\r\n房屋用途:" + 房屋用途 + "\r\n\r\n权利人:" + 权利人 + "\r\n\r\n登记时间:" + 登记时间;
                    this.textBox2.Text = ShowResult;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                    MessageBox.Show("天呐，软件开小差了，请联系开发人员蔡宗麟");
                    return;
                }
                finally
                {
                    this.button1.Enabled = true;
                    this.button2.Enabled = true;
                    this.label2.Visible = false;
                }
                //MessageBox.Show("恭喜您，识别成功");
            })
            {
                IsBackground = true,
                Priority = ThreadPriority.Highest
            }.Start(); 

        }


    }
}
