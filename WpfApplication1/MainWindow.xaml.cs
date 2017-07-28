using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using System.Diagnostics;
using System.Windows.Data;
using System.Windows.Controls;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Input;
using System.Data;
using Newtonsoft.Json;

namespace ToolForDan
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private static DispatcherTimer timerRenew = null;

        public MainWindow()
        {
            InitializeComponent();
            InitBW();
        }

        private void tabItem2_Initialized(object sender, EventArgs e)
        {
            if (timerRenew == null)
            {
                timerRenew = new DispatcherTimer();
                timerRenew.Tick += new EventHandler(timeCycle); timerRenew.Interval = new TimeSpan(0, 0, 0, 10);
                timerRenew.Start();
            }
        }
        //转换
        private void btnTransform_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                System.Windows.MessageBox.Show("请选取编号！");
            }
            else
            {
                try
                {
                    textBox2.Text = new QQAcountTransformer(textBox1.Text.Trim(), (comboBox1.SelectedItem as CustomSequence).LstCodeSequence).Transform();
                }
                catch (Exception ex)
                {
                    textBox2.Text = "错误信息：" + ex.Message;
                }
            }
        }
        //复制
        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetDataObject(textBox2.Text);
        }
        //清空
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void tabItem3_Initialized(object sender, EventArgs e)
        {
            var cfgHelper = new ConfigHelper();
            var temp = GameArea.GetSelectedGameAreas();
            if (temp.Count > 0)
            {
                Consts.LstServer.Except(temp).ToList().ForEach(p => listBox1.Items.Add(p));
                temp.ForEach(p => listBox2.Items.Add(p));
            }
            else
            {
                Consts.LstServer.ForEach(p => listBox1.Items.Add(p));
            }
            Reload();
        }

        private void tabItem1_Initialized(object sender, EventArgs e)
        {
            comboBox1.ItemsSource = CustomSequence.GetAllCustomSequenceName(true);
        }

        
    }
}
