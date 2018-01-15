using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
namespace BasicConcat {
    class Program {
        static void Main (string[] args) {
            const int start = 1;
            const int length = 10;
            var seq1 = (from number in Enumerable.Range (start, length) select number)
                .ToObservable ();
            var seq2 = (from number in Enumerable.Range (start + length, length) select number)
                .ToObservable ();
            seq1.Concat (seq2).Subscribe (Console.WriteLine);
        }
    }
}
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
namespace IncrementalConcat {
    class Program {
        static void Main (string[] args) {
            const int start = 0;
            const int length = 10;
            var sequence = (from number in Enumerable.Range (start, length) select number)
                .ToObservable ();
            for (var index = 2; index < 5; index++) {
                //下面的这种写法并不会改变原来的sequence
                //因为sequence.Concat返回的是一个复制过的对象
                sequence.Concat (
                    (from number in Enumerable.Range (length * index, length) select number)
                    .ToObservable ());
            }
            sequence.Subscribe (Console.WriteLine);
        }
    }
}