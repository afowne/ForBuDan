using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace ToolForDan
{
    public partial class MainWindow:Window
    {
        //手动更新
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            textBox3.Text = "";
            textBox3.Foreground = Brushes.Blue;
            textBox3.Text = RealTimePrice.GetPriceStr();
            #region Parallel Obsolete
            //Timer timer = new Timer(60000);
            //timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            //Parallel.ForEach(LstServer.Where(p => p.ID == "G10P001039" || p.ID == "G10P001037" || p.ID == "G10P001017" || p.ID == "G10P001026" || p.ID == "G10P001011" || p.ID == "G10P001054").ToList(), q =>
            //{
            //    string html= GetHttpWebResponse(url,string.Format(para,q.ID));
            //    HtmlDocument doc = new HtmlDocument();
            //    doc.LoadHtml(html);
            //    HtmlNode node = doc.DocumentNode;
            //    var nc = node.SelectSingleNode("//*[@id='shouitem_1']/ul[2]/li[4]/span/span");
            //}); 
            #endregion
        }

        public void timeCycle(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox3.Foreground = Brushes.Green;
            textBox3.Text = RealTimePrice.GetPriceStr();
        }
    }
}
