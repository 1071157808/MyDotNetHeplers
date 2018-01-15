using System;
using System.Threading;
namespace MutiThreadSample.ThreadSynchronization {
    class Program {
        static void Main (string[] args) {
            CookResetEvent cook = new CookResetEvent ();
            cook.Cook ();
            Console.WriteLine ("这一句可以输出的");
            Console.Read ();
        }
    }
    /// <summary>
    /// 案例：做饭
    /// 今天的Dinner准备吃鱼，还要熬粥
    /// 熬粥和做鱼，是比较复杂的工作流程，
    /// 做粥：选材、淘米、熬制
    /// 做鱼：洗鱼、切鱼、腌制、烹调
    /// 我们用两个线程来准备这顿饭
    /// 但是，现在只有一口锅，只能等一个做完之后，另一个才能进行最后的烹调
    /// </summary>
    class CookResetEvent {
        /// <summary>
        ///
        /// </summary>
        private AutoResetEvent resetEvent = new AutoResetEvent (false); 
        //首先false就是设置为阻塞，意思是到waitOne的时候会自动停止，直到有地方直接给它set成true才可以
        //继续执行waitOne下面的资源
        /// <summary>
        /// 做饭
        /// </summary>
        public void Cook () {
            Thread SuCai = new Thread (new ThreadStart (MakeSuCai));
            SuCai.Name = "SuCai";
            SuCai.Start ();
            Thread makeFishThread = new Thread (new ThreadStart (MakeFish));
            makeFishThread.Name = "MakeFish";
            makeFishThread.Start ();
            Thread porridgeThread = new Thread (new ThreadStart (Porridge));
            porridgeThread.Name = "Porridge";
            porridgeThread.Start ();
            //等待5秒
            Thread.Sleep (5000);
            //阻塞线程
            resetEvent.Reset ();
        }
        /// <summary>
        /// 熬粥
        /// </summary>
        public void Porridge () {
            //选材
            Console.WriteLine ("Thread:{0},开始选材", Thread.CurrentThread.Name);
            //淘米
            Console.WriteLine ("Thread:{0},开始淘米", Thread.CurrentThread.Name);
            //熬制
            Console.WriteLine ("Thread:{0},开始熬制，需要2秒钟", Thread.CurrentThread.Name);
            //需要2秒钟
            Thread.Sleep (2000);
            Console.WriteLine ("Thread:{0},粥已经做好，锅闲了", Thread.CurrentThread.Name);
            //发出信号,waitOne处的线程获得资源执行下一步
            resetEvent.Set ();
        }
        /// <summary>
        /// 做鱼
        /// </summary>
        public void MakeFish () {
            //洗鱼
            Console.WriteLine ("Thread:{0},开始洗鱼", Thread.CurrentThread.Name);
            //腌制
            Console.WriteLine ("Thread:{0},开始腌制", Thread.CurrentThread.Name);
            //等信号，等待锅空闲出来
            resetEvent.WaitOne ();
            //烹调
            Console.WriteLine ("Thread:{0},终于有锅了", Thread.CurrentThread.Name);
            Console.WriteLine ("Thread:{0},开始做鱼,需要5秒钟", Thread.CurrentThread.Name);
            Thread.Sleep (5000);
            Console.WriteLine ("Thread:{0},鱼做好了，好香", Thread.CurrentThread.Name);
            //发出信号,waitOne处的线程获得资源执行下一步
            resetEvent.Set ();
        }
        /// <summary>
        /// 做素菜
        /// </summary>
        public void MakeSuCai () {
            //洗鱼
            Console.WriteLine ("Thread:{0},开始做素菜", Thread.CurrentThread.Name);
            //腌制
            Console.WriteLine ("Thread:{0},开始做素材", Thread.CurrentThread.Name);
            //等信号，等待锅空闲出来
            resetEvent.WaitOne ();
            //烹调
            Console.WriteLine ("Thread:{0},终于有锅了", Thread.CurrentThread.Name);
            Console.WriteLine ("Thread:{0},开始素菜,需要5秒钟", Thread.CurrentThread.Name);
            Thread.Sleep (5000);
            Console.WriteLine ("Thread:{0},素菜做好了，好香", Thread.CurrentThread.Name);
            //释放线程
            resetEvent.Set ();
        }
    }
}