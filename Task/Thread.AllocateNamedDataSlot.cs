// 主线程 子线程 命名空间、 数据的隔离

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace DataSlot {
    class Program {
        static void Main (string[] args) {
            //分配一个命名的槽位
            var slot = Thread.AllocateNamedDataSlot ("username");
            //分配一个不命名的槽位
            var slot2 = Thread.AllocateDataSlot ();
            //释放槽位
            Thread.FreeNamedDataSlot ("username");
            //主线程 上 设置槽位，， 也就是hello world 只能被主线程读取，其他线程无法读取
            Thread.SetData (slot, "hello world!!!");
            var t = new Thread (() => {
                var obj = Thread.GetData (slot);
                //新的子线程中无法访问主线程中的变量
                Console.WriteLine ("当前工作线程:{0}", obj);
            });
            t.Start ();
            var obj2 = Thread.GetData (slot);
            Console.WriteLine ("主线程:{0}", obj2);
            Console.Read ();
        }
    }
}