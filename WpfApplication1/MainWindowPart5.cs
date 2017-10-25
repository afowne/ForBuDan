using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.ComponentModel;
using System.Threading;
using System.IO;

namespace ToolForDan
{
    public partial class MainWindow : Window
    {
        BackgroundWorker backgroundWorker222 = new BackgroundWorker();

        private static ConfigHelper cfh = new ConfigHelper();

        private string SourceFilePathKey = "SourceFilePath";
        private string SplitRowCountKey = "SplitRowCount";

        private void tabItem5_Initialized(object sender, EventArgs e)
        {
            if (!cfh.Exist(SourceFilePathKey))
            {
                cfh.Add(SourceFilePathKey, textBox3.Text.Trim());
            }
            if (!cfh.Exist(SplitRowCountKey))
            {
                cfh.Add(SplitRowCountKey, textBox5.Text.Trim());
            }
            textBox3.Text = cfh.GetValue(SourceFilePathKey);
            textBox5.Text = cfh.GetValue(SplitRowCountKey);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            string file = textBox3.Text.Trim();
            string rcount = textBox5.Text.Trim();
            int defRow = 0;
            #region 检查
            if (string.IsNullOrEmpty(file))
            {
                MessageBox.Show("路径不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(rcount))
            {
                MessageBox.Show("截取行数不能为空！");
                return;
            }
            if (!int.TryParse(rcount, out defRow))
            {
                MessageBox.Show("行数只能为数字！");
                return;
            } 
            #endregion
            try
            {
                string filepath = Path.GetDirectoryName(file);
                #region 文件名
                string NewFileName = string.Empty;
                if (radioButton1.IsChecked.Value)
                {
                    NewFileName = DateTime.Today.ToString("MM.dd-") + textBox6.Text;
                }
                else if (radioButton2.IsChecked.Value)
                {
                    NewFileName = textBox7.Text;
                }
                if (string.IsNullOrEmpty(NewFileName))
                {
                    MessageBox.Show("文件名不能为空！");
                    return;
                }
                NewFileName += ".txt";
                if (File.Exists(filepath + "\\" + NewFileName))
                {
                    if (MessageBox.Show("存在同名文件，是否覆盖？", "警告", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                    {
                        return;
                    }
                }
                #endregion
                #region 截取行数
                //FileStream fs = new FileStream(file, FileMode.Open);
                //StreamReader sr = new StreamReader(fs);
                var Splited0 = File.ReadAllLines(file, Encoding.Default).Take(defRow).ToArray();
                if (Splited0.Length < defRow)
                {
                    MessageBox.Show("源文件行数不足" + defRow + "行,请更新源文件！");
                    return;
                }
                #endregion
                #region 写新文件
                //File.WriteAllLines(filepath + "\\" + NewFileName, Splited, Encoding.Default);
                FileStream fs = new FileStream(filepath + "\\" + NewFileName, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                for (int i = 0; i < Splited0.Length; i++)
                {
                    sw.Write(Splited0[i]);
                    if (i != Splited0.Length - 1)
                    {
                        sw.WriteLine();
                    }
                }
                sw.Flush();
                sw.Close();
                fs.Close();
                #endregion
                #region 源文件覆盖
                if (!checkBox1.IsChecked.Value)
                {
                    var Splited1 = File.ReadAllLines(file, Encoding.Default).Skip(defRow).ToArray();
                    File.WriteAllLines(file, Splited1, Encoding.Default);
                }
                #endregion
                //自增长
                if (radioButton1.IsChecked.Value) textBox6.Text = (int.Parse(textBox6.Text.Trim()) + 1).ToString();
                //更新配置文件
                cfh.Delete(SourceFilePathKey);
                cfh.Add(SourceFilePathKey, textBox3.Text.Trim());
                cfh.Delete(SplitRowCountKey);
                cfh.Add(SplitRowCountKey, textBox5.Text.Trim());
            }
            catch (FileNotFoundException ef)
            {
                MessageBox.Show(ef.Message);
            }
            catch (Exception eo)
            {
                MessageBox.Show(eo.Message);
            }
        }

    }
}