using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

namespace ToolForDan
{
    public partial class MainWindow : Window
    {
        private void button1_Click(object sender, RoutedEventArgs e)
        {

            List<string> lstInput = textBox4.Text.Split(new string[] { Consts.WrapSymbol }, StringSplitOptions.None).ToList();
            textBox4.Text = "";
            foreach (var item in lstInput)
            {
                var temp = MyHttp.GetHttpWebResponse("http://120.55.70.104/Unbind", "card=" + item);

                Result res = JsonHelper.DeserializeJsonToObject<Result>(temp);

                if (res.err != "1")
                {
                    textBox4.Text += item + Consts.WrapSymbol;
                }
            }
            
        }

        public class Result
        {
            public string err { set; get; }
            public string msg { set; get; }
        }
    }
}
