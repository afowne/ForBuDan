using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Threading;
using System.Windows.Threading;

namespace ToolForDan
{
    public partial class MainWindow : Window
    {
        private static DispatcherTimer timerRenew = null;

        private void tabItem2_Initialized(object sender, EventArgs e)
        {
            if (timerRenew == null)
            {
                timerRenew = new DispatcherTimer();
                timerRenew.Tick += new EventHandler(timeCycle); timerRenew.Interval = new TimeSpan(0, 0, 0, 10);
                timerRenew.Start();
            }
        }

        //手动更新
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            dataGrid1.ItemsSource = RealTimePrice.GetPriceTB().DefaultView;
            dataGrid1.Foreground = Brushes.Blue;

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
            Thread thread = new Thread(UpdateDT);
            thread.Start();
        }

        private void UpdateDT()
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate()
                {
                    dataGrid1.ItemsSource = RealTimePrice.GetPriceTB().DefaultView;
                    dataGrid1.Foreground = Brushes.Black;
                }
            );
        }
    }
}
