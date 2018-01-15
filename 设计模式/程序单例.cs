
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace ConsoleApp2
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //we need to get the current proccess name
            string strProcessName = Process.GetCurrentProcess().ProcessName;
            //check if this process name is existing in the current running process
            Process[] Oprocesses = Process.GetProcessesByName(strProcessName);
            //if its existing then exit
            if (Oprocesses.Length > 1)
            {
                Console.WriteLine("已经有一个进程在运行了");
            }
            else
            {
                Console.WriteLine("现在开始执行程序");
            }
        }
    }
}
