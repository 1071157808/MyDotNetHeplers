using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
namespace BufferBlockDemo {
    class Program {
        static void Main (string[] args) {
            // Create a BufferBlock<int> object.
            //表示一般用途的异步消息结构
            // 此类存储先进先出 (FIFO) 消息队列，此消息队列可由多个源写入或从多个目标读取。
            // 在目标收到来自消息BufferBlock<> </> > 对象，从消息队列中移除该消息
            var bufferBlock = new BufferBlock<int> ();
            // Post several messages to the block.
            for (int i = 0; i < 3; i++) {
                bufferBlock.Post (i);
            }
            // Receive the messages back from the block.
            for (int i = 0; i < 4; i++) {
                Console.WriteLine (bufferBlock.Receive ());
            }
            Console.Read ();
            /* Output:
               0
               1
               2
             */
        }
    }
}