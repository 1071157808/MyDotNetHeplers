using System;
using System.Collections.Generic;
usingSystem.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace FromCurrentSynchronizationContextDemo {
    public partial class Form1 : Form {
        public Form1 () {
            InitializeComponent ();
        }
        private void button1_Click (object sender, EventArgs e) {
            Task task = new Task (() => {
                try {
                    Thread.Sleep (1000 * 5);
                    //label1.Text = "你好";
                } catch (Exception ex) {
                    MessageBox.Show (ex.Message);
                }
            });
            //加上了FromCurrentSynchronizationContext就可以对其他线程进行操作
            //因为它是同步上下文的taskSchedule
            //task.Start(TaskScheduler.FromCurrentSynchronizationContext());
            //下面的会报异常，线程间的操作无效
            //task.Start();
            // Task.Factory.StartNew都会使用threadpool，如何让task单独使用thread，我忘了
            //ContinueWith会启动另一个工作者线程来进行操作
            task.ContinueWith (t => {
                //对UI的更新的操作单独出来
                //把它与时间的操作分割开，就不会让UI等待
                //涉及到UI操作的都要瞬间完成
                label1.Text = "你好";
            }, TaskScheduler.FromCurrentSynchronizationContext ());
            task.Start ();
            //耗时的操作我们要放到threadpool
            //var task = Task.Factory.StartNew(() =>
            //{
            //    //默认耗时操作
            //    Thread.Sleep(1000 * 10);
            //});
            //更新操作放到同步上下文中,即时更新
            //task.ContinueWith(t =>
            //{
            //    label1.Text = "你好";
            //}, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}