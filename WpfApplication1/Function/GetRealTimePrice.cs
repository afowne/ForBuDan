using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace ToolForDan
{
    public class RealTimePrice
    {
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
    }
}
