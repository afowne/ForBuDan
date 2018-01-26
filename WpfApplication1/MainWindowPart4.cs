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
        private string AjaxUnbindUrlKey = "AjaxUnbindUrl";
        private string AjaxUnbindServerKey = "AjaxUnbindServer";
        const int RETRYTIMES = 3;

        BackgroundWorker backgroundWorker1 = new BackgroundWorker();

        private void InitBW()
        {
            textBox9.Text = cfh.GetValue(AjaxUnbindUrlKey);
            comboBox2.SelectedIndex = int.Parse(string.IsNullOrEmpty(cfh.GetValue(AjaxUnbindServerKey)) ? "0" : cfh.GetValue(AjaxUnbindServerKey));
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
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
            cfh.Delete(AjaxUnbindUrlKey);
            cfh.Add(AjaxUnbindUrlKey, textBox9.Text.Trim());
            cfh.Delete(AjaxUnbindServerKey);
            cfh.Add(AjaxUnbindServerKey, comboBox2.SelectionBoxItem.ToString());

            backgroundWorker1.RunWorkerAsync(new { a = textBox4.Text, b = textBox9.Text, c = comboBox2.SelectionBoxItem.ToString() });
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            dynamic z = e.Argument;
            var lstInput = z.a.ToString().Trim().Split(new string[] { Consts.WrapSymbol }, StringSplitOptions.None);
            string errList = string.Empty;
            int successCount = 0;
            BWR bwr = new BWR();
            for (int i = 0; i < lstInput.Length; i++)
            {
                try
                {
                    for (int j = 0; j < RETRYTIMES; j++)
                    {
                        if (backgroundWorker1.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }
                        var temp = MyHttp.GetHttpWebResponse(z.b.ToString(), "srv=" + z.c.ToString() + "&card=" + lstInput[i]);
                        Result res = JsonHelper.DeserializeJsonToObject<Result>(temp);
                        bwr.th1 = (i + 1).ToString();
                        bwr.th2 = (j + 1).ToString();
                        if (res.err == "1")
                        {
                            successCount++;
                            bwr.th3 = successCount.ToString();
                            Thread.Sleep(100);
                            backgroundWorker1.ReportProgress(i + 1, bwr);
                            break;
                        }
                        else
                        {
                            bwr.th3 = successCount.ToString();
                            Thread.Sleep(100);
                            backgroundWorker1.ReportProgress(i + 1, bwr);
                            if ((j + 1) == RETRYTIMES) errList += lstInput[i] + Consts.WrapSymbol;
                        }
                    }
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
            BWR bwr = (BWR)e.UserState;
            label1.Content = "正在解绑第" + bwr.th1 + "个（请求第" + bwr.th2 + "次）" + Consts.WrapSymbol + "已成功" + bwr.th3 + "个。";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("解绑停止！");
            }
            else
            {
                textBox4.Text = e.Result.ToString();
                MessageBox.Show("解绑结束！");
            }
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            backgroundWorker1.CancelAsync();
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

        public class BWR
        {
            //第几个
            public string th1 { set; get; }
            //第几次
            public string th2 { set; get; }
            //成功几个
            public string th3 { set; get; }
        }
    }
}
