using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
usingSystem.Net;
using System.Text;
using System.Threading.Tasks;
namespace TaskAsyncDemo {
    class Program {
        static void Main (string[] args) {
            //字节流文件的读取
            #region 将async包装成task
            FileStream fs = new FileStream (Environment.CurrentDirectory + "//1.txt", FileMode.Open);
            var bytes = new byte[fs.Length];
            var task = Task.Factory.FromAsync (fs.BeginRead, fs.EndRead, bytes, 0, bytes.Length, string.Empty);
            var nums = task.Result;
            Console.WriteLine (nums);
            #endregion
            #region 单独使用async
            FileStream fs2 = new FileStream (Environment.CurrentDirectory + "//1.txt", FileMode.Open);
            var bytes2 = new byte[fs.Length];
            fs2.BeginRead (bytes, 0, bytes2.Length, (aysc) => {
                var nums2 = fs2.EndRead (aysc);
                Console.WriteLine (nums2);
            }, string.Empty);
            Console.Read ();
            #endregion
            #region 包装action
            //action中的动作其实是invoke的调用
            //Action action = () =>
            //{
            //    System.Threading.Thread.Sleep(100000);
            //    Console.WriteLine("hello world!");
            //};
            //var task = Task.Factory.FromAsync(action.BeginInvoke, action.EndInvoke, string.Empty);
            ////task.Start();
            #endregion
            #region 事件包装成task
            var task3 = GetTaskAsyc ("http://cnblogs.com");
            var nums3 = task3.Result;
            Console.WriteLine (nums3.Length);
            #endregion
        }
        public static Task<byte[]> GetTaskAsyc (string url) {
            TaskCompletionSource<byte[]> source = new TaskCompletionSource<byte[]> ();
            WebClient client = new WebClient ();
            client.DownloadDataCompleted += (sender, e) => {
                try {
                    //如果下载完成了，将当前的byte[]个数给task包装器
                    source.TrySetResult (e.Result);
                } catch (Exception ex) {
                    source.TrySetException (ex);
                }
            };
            client.DownloadDataAsync (new Uri (url));
            return source.Task;
        }
    }
}