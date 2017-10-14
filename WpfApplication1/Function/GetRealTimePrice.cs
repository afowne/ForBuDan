using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Data;

namespace ToolForDan
{
    public class RealTimePrice
    {
        [Obsolete]
        public static string GetPriceStr()
        {
            string str = string.Empty;
            try
            {
                GameArea.GetSelectedGameAreas().ForEach(p =>
                {
                    string html = string.Empty;
                    if (p.Code.StartsWith("G10P001"))
                    {
                        html = MyHttp.GetHttpWebResponse(Consts.url, string.Format(Consts.para1, p.Code));
                    }
                    else if (p.Code.StartsWith("G10P002"))
                    {
                        html = MyHttp.GetHttpWebResponse(Consts.url, string.Format(Consts.para2, p.Code));
                    }
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(html);
                    HtmlNode node = doc.DocumentNode;
                    var nc = node.SelectSingleNode("//*[@id='shouitem_1']/ul[2]/li[4]/span/span");
                    str += p.Name + ":" + nc.InnerHtml + Consts.WrapSymbol;
                });
            }
            catch (Exception ex)
            {
                return str;
            }
            return str;
        }

        public static DataTable GetPriceTB()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("qf", typeof(string));
            dt.Columns.Add("shj", typeof(string));

            try
            {
                string html = MyHttp.GetHttpWebResponse(Consts.url_allprice, string.Empty);
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);
                HtmlNode node = doc.DocumentNode;
                var qf = node.SelectNodes("/html/body/section/div[6]/div[2]/div[2]/div/ul/li/span/a/font[@class='qf']");
                var shj = node.SelectNodes("/html/body/section/div[6]/div[2]/div[2]/div/ul/li/span/a/font[@class='shj']");

                GameArea.GetSelectedGameAreas().ForEach(p =>
                {
                    for (int i = 0; i < qf.Count; i++)
                    {
                        if (qf[i].InnerHtml == p.Name)
                        {
                            DataRow row = dt.NewRow();
                            row["qf"] = p.Name;
                            row["shj"] = (shj[i].InnerHtml + "0").Substring(0, 5);
                            dt.Rows.Add(row);
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                return dt;
            }
            return dt;
        }
    }
}
