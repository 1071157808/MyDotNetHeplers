using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace ReaderWriterLockSlimDemo {
    class Program {
        static void Main (string[] args) {
            ReaderWriterLockSlim slim = new ReaderWriterLockSlim ();
            slim.EnterReadLock ();
            slim.ExitReadLock ();
            slim.EnterWriteLock ();
            slim.ExitWriteLock ();
            ReaderWriterLock rwlock = new ReaderWriterLock ();
            //rwlock.AcquireReaderLock()
            Console.Read ();
        }
    }
}

//  --------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace AcquireWriterLockDemo {
    class Program {
        static ReaderWriterLock rwlock = new ReaderWriterLock ();
        static void Main (string[] args) {
            //比如开启5个task
            for (int i = 0; i < 5; i++) {
                Task.Factory.StartNew (() => {
                    Read ();
                });
            }
            Task.Factory.StartNew (() => {
                Write ();
            });
            Console.Read ();
        }
        static int nums = 0;
        /// <summary>
        /// 线程读
        /// </summary>
        static void Read () {
            while (true) {
                Thread.Sleep (10);
                rwlock.AcquireReaderLock (int.MaxValue);
                Thread.Sleep (10);
                Console.WriteLine ("当前 t={0} 进行读取 {1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now);
                rwlock.ReleaseReaderLock ();
            }
        }
        /// <summary>
        /// 线程写
        /// </summary>
        static void Write () {
            while (true) {
                //3s进行一次写操作
                Thread.Sleep (3000);
                rwlock.AcquireWriterLock (int.MaxValue);
                Thread.Sleep (3000);
                Console.WriteLine ("当前 t={0} 进行写入。。。。。。。。。。。。。。。。。。。。。。。{1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now);
                rwlock.ReleaseWriterLock ();
            }
        }
    }
}