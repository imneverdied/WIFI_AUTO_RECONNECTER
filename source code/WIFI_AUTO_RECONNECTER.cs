using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace AUTO_WIFI_CONNECTER
{
    class Program
    {// args[0] can be an IPaddress or host name.
        public static void Main()
        {
            loop_timer();
        }
        public static void loop_timer()
        {
            WIFIcheck();
            Console.WriteLine(",5分鐘後再次檢查");
            //Thread.Sleep(600000);//10min
            Thread.Sleep(300000);//1min
            loop_timer();

        }
        public static void WIFIcheck()
        {
            Ping pingSender = new Ping();
            PingReply reply = pingSender.Send("www.google.com", 120);//第一個引數為ip地址,第二個引數為ping的時間
            if (reply.Status == IPStatus.Success)
            {
                //ping的通   
                Console.Write(DateTime.Now + " 網路連接正常");
                int pause = 0;
            }
            else
            {
                Console.Write(DateTime.Now + " 網路連接異常，嘗試呼叫BAT重新連接WIFI");
                //ping不通
                ProcessStartInfo Info2 = new ProcessStartInfo();
                Info2.FileName = "WIFI.bat";//執行的檔案名稱
                //Info2.WorkingDirectory = @"d:\test";//檔案所在的目錄
                Process.Start(Info2);//
            }
            int a = 1;
        }
    }
}
