using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        const string Segmentation = "----";
        private Dictionary<int, string> dicArea = new Dictionary<int, string>() 
        { 
        { 1, "上海2区" },
        { 2, "浙江4/5区" },
        { 3, "湖北5区" },
        { 4, "广东8区" },
        { 5, "四川5区" },
        { 6, "江苏5/7区" }
        };
        private string E = "1,2,3,4,5,6";
        private string F = "2,3,4,5,1,6";
        private string G = "4,5,1,2,3,6";
        private string H = "3,4,5,1,2,6";
        private string I = "5,1,2,3,4,6";
        private string K = "1,2,3,4,5,6";
        private string L = "5,1,2,3,4,6";

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var txtAll = TextBox1.Text.Trim();
            List<string> lstAll = txtAll.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();

            List<Waiting> lstWaiting = new List<Waiting>();
            lstAll.ForEach((p) =>
            {
                var idpw = Regex.Split(p, Segmentation);
                lstWaiting.Add(new Waiting() { ID = idpw[0], PW = idpw[1] });
            });

            StringBuilder strRe = new StringBuilder();
            lstWaiting.ForEach((p) =>
            {
                ConvertSequence(GetCheckedRadio()).ForEach((x) =>
                {
                    strRe.AppendFormat("{0},{1},{2}\r\n", p.ID, p.PW, x);
                });
            });

            TextBox2.Text = strRe.ToString();
        }

        private List<string> ConvertSequence(string orderType)
        {
            List<string> serverSequence = new List<string>();
            if (!string.IsNullOrEmpty(orderType))
            {
                orderType.Split(',').ToList().ForEach((p) =>
                {
                    serverSequence.Add(dicArea[Convert.ToInt32(p)]);
                });
            }
            return serverSequence;
        }

        private string GetCheckedRadio()
        {
            if (RadioButton1.Checked)
            {
                return E;
            }
            else if (RadioButton2.Checked)
            {
                return F;
            }
            else if (RadioButton3.Checked)
            {
                return G;
            }
            else if (RadioButton4.Checked)
            {
                return H;
            }
            else if (RadioButton5.Checked)
            {
                return I;
            }
            else if (RadioButton6.Checked)
            {
                return K;
            }
            else if (RadioButton7.Checked)
            {
                return L;
            }
            else
            {
                return string.Empty;
            }
        }

        public class Waiting
        {
            public string ID;
            public string PW;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(TextBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WinAPItest.SecondTest();
        }
    }
}
