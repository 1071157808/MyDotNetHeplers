using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace FrontThreadBackThread {
    class Program {
        static void Main (string[] args) {
            //front thread 前台线程
            //running even if main thread quit
            //Thread th1 = new Thread(Fucntion1);
            //th1.Start();
            //Console.WriteLine("第一个程序测试完成");
            //back thread 后台线程
            //running until main thread quit
            Thread th2 = new Thread (Fucntion1);
            th2.IsBackground = true;
            th2.Start ();
            Console.WriteLine ("第二个程序测试完成");
        }
        static void Fucntion1 () {
            Console.WriteLine ("第一个程序开始执行，请输入");
            Console.ReadLine ();
            Console.WriteLine ("第一个程序执行结束");
        }
        static void Function2 () {
            Console.WriteLine ("第二个程序开始执行，请输入");
            Console.ReadLine ();
            Console.WriteLine ("第二个程序执行结束");
        }
    }
}