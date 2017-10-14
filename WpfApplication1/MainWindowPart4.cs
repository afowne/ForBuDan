using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.ComponentModel;
using System.Threading;

namespace ToolForDan
{
    public partial class MainWindow : Window
    {
        BackgroundWorker backgroundWorker1 = new BackgroundWorker();

        private void InitBW()
        {
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text.Trim()))
            {
                return;
            }
            backgroundWorker1.RunWorkerAsync(textBox4.Text);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> lstInput = e.Argument.ToString().Split(new string[] { Consts.WrapSymbol }, StringSplitOptions.None).ToList();
            string errList = string.Empty;
            for (int i = 0; i < lstInput.Count; i++)
            {
                try
                {
                    var temp = MyHttp.GetHttpWebResponse(Consts.url2, "srv=0&card=" + lstInput[i]);
                    Result res = JsonHelper.DeserializeJsonToObject<Result>(temp);
                    if (res.err != "1") errList += lstInput[i] + Consts.WrapSymbol;

                    Thread.Sleep(100);
                    backgroundWorker1.ReportProgress(i + 1);
                }
                catch (Exception)
                {
                    continue;
                }
            }

            e.Result = errList;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label1.Content = "解至第" + e.ProgressPercentage + "个！";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            textBox4.Text = e.Result.ToString();
            MessageBox.Show("解绑结束！");
        }


        private void button2_Click(object sender, RoutedEventArgs e)
        {
            textBox4.Text = "";
        }

        public class Result
        {
            public string err { set; get; }
            public string msg { set; get; }
        }
    }
}
