using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ToolForDan
{
    public class QQAcountTransformer
    {
        private string txtInput;
        private string orderType;
        private List<GameArea> forOrder;

        public QQAcountTransformer(string TxtInput, List<GameArea> ForOrder)
        {
            txtInput = TxtInput;
            forOrder = ForOrder;
        }

        public string Transform()
        {
            List<string> lstInput = txtInput.Split(new string[] { Consts.WrapSymbol }, StringSplitOptions.None).ToList();

            ConfigHelper cfh = new ConfigHelper();
            var Separator1 = cfh.GetValue("Separator1");
            var Separator2 = cfh.GetValue("Separator2");
            var Separator3 = cfh.GetValue("Separator3");

            List<QQAccount> lstWaiting = new List<QQAccount>();
            lstInput.ForEach((p) =>
            {
                string[] idpw = Regex.Split(p, Separator1);
                lstWaiting.Add(new QQAccount() { ID = idpw[0], PW = idpw[1] });
            });

            StringBuilder strRe = new StringBuilder();
            var temp = forOrder.Select(q => q.Name).ToList();
            lstWaiting.ForEach((p) =>
            {
                int turn = 1;
                strRe.Append("[账号]" + Consts.WrapSymbol);
                temp.ForEach((x) =>
                {
                    strRe.Append(turn.ToString() + "=" + p.ID + "|" + p.PW + "|" + x + "|1|2" + Consts.WrapSymbol);
                    turn++;
                });
            });
            return strRe.ToString();
        }
    }
}
