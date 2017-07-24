using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;  


namespace WindowsFormsApplication1
{


    public class WinAPItest
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hwnd, uint wMsg, int wParam, int lParam);

        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow", SetLastError = true)]
        private static extern void SetForegroundWindow(IntPtr hwnd);

        public static void FirtTest()
        {

            const uint BM_CLICK = 0xF5; //鼠标点击的消息，对于各种消息的数值，大家还是得去API手册  

            IntPtr hwndPhoto = FindWindow(null, "巅峰批量卡iPhone新版 V1.3"); //查找拍照程序的句柄【任务管理器中的应用程序名称】  

            if (true)
            {
                IntPtr hwndThree = FindWindowEx(hwndPhoto, IntPtr.Zero, null, "开   始"); //获取按钮快照的句柄  

                SetForegroundWindow(hwndPhoto);    //将UcDemo程序设为当前活动窗口  

                System.Threading.Thread.Sleep(500);   //暂停500毫秒  

                SendMessage(hwndThree, BM_CLICK, 0, 0);//模拟点击拍照按钮  
            }
            else
            {
                MessageBox.Show("没有启动 UcDemo");
            }

        }

        public static void SecondTest()
        {
            const uint BM_CLICK = 0xF5; //鼠标点击的消息，对于各种消息的数值，大家还是得去API手册  

            IntPtr hwndPhoto = FindWindow(null, "卜丹工具1号"); //查找拍照程序的句柄【任务管理器中的应用程序名称】  

            int ct = 0;
            IntPtr result = IntPtr.Zero;
            do
            {
                result = FindWindowEx(hwndPhoto, result, null, null);
                if (result != IntPtr.Zero)
                {
                    ++ct;
                }
            } while (ct < 10 && result != IntPtr.Zero);
        }

    }
}
