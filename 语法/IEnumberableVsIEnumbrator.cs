using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace index {
    class Program {
        static void GoOnIEnumberator (IEnumerator<Man> mans) {
            while (mans.MoveNext ()) {
                Console.WriteLine (mans.Current.age);
            }
        }
        static void Main (string[] args) {
            List<Man> mans = new List<Man> () {
                new Man {
                age = 10,
                name = "spike"
                },
                new Man {
                age = 11,
                name = "spiderMan"
                },
                new Man {
                age = 12,
                name = "ironMnan"
                },
                new Man {
                age = 13,
                name = "hulk"
                },
                new Man {
                age = 14,
                name = "wukong"
                }
            };
            //IEnumberable的用法
            //IEnumberable是IEnumberator的语法糖，让程序更短
            foreach (var item in mans) {
                Console.WriteLine (item.name);
            }
            //IEnumberator的用法
            //IEnumberator的与IEnumberable的最大区别就是：IEnumberator可以在函数跳转的时候
            //保存当前指针的状态
            IEnumerator<Man> manIEnumberator = mans.GetEnumerator ();
            while (manIEnumberator.MoveNext ()) {
                if (manIEnumberator.Current.age > 12) {
                    Console.WriteLine (manIEnumberator.Current.age);
                    GoOnIEnumberator (manIEnumberator);
                } else {
                    Console.WriteLine (manIEnumberator.Current.age);
                }
            }
            Console.ReadKey ();
        }
    }
    class Man {
        public int age { get; set; }
        public string name { get; set; }
    }
}