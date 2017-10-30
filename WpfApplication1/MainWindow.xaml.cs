using System;
using System.Windows;
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
        public MainWindow()
        {
            InitializeComponent();
            InitBW();
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

        private void tabItem1_Initialized(object sender, EventArgs e)
        {
            comboBox1.ItemsSource = CustomSequence.GetAllCustomSequenceName(true);
        }
    }
}
