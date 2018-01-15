// 在.NET4.0中，可以使用Lazy<T> 来实现对象的延迟初始化，从而优化系统的性能。
// 延迟初始化就是将对象的初始化延迟到第一次使用该对象时。
// 延迟初始化是我们在写程序时经常会遇到的情形，
// 例如创建某一对象时需要花费很大的开销，
// 而这一对象在系统的运行过程中不一定会用到，这时就可以使用延迟初始化，
// 在第一次使用该对象时再对其进行初始化，如果没有用到则不需要进行初始化,这样的话，
// 使用延迟初始化就提高程序的效率，从而使程序占用更少的内存

// Lazy<T> 对象初始化默认是线程安全的，
// 在多线程环境下，第一个访问 Lazy<T> 对象的 Value 属性的线程将初始化 Lazy<T> 对象，
// 以后访问的线程都将使用第一次初始化的数据。

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1 {
    public class Student {
        public Student () {
            this.Name = "DefaultName";
            this.Age = 0;
            Console.WriteLine ("Student is init...");
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}

//------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1 {
    class Program {
        static void Main (string[] args) {
            Lazy<Student> stu = new Lazy<Student> ();
            if (!stu.IsValueCreated)
                Console.WriteLine ("Student isn't init!");
            Console.WriteLine (stu.Value.Name);
            stu.Value.Name = "Tom";
            stu.Value.Age = 21;
            Console.WriteLine (stu.Value.Name);
            Console.Read ();
        }
    }
}