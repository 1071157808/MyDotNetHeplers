using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace SumTest {
    //dynamic 与反射的效率对比，结果证明dynamic比反射的效率高，这个代码不存在问题，但是结论可能存在问题，是博客园上的一个人写的
    class Program {
        static void Main (string[] args) {
            //初始化的时候total就已经被确定为int类型了
            dynamic total = default (int);
            total = (total + 10);
            //一个int类型的total当然可以隐式转换为double类型
            double xx = total;
            //当然可以把total再变成dynamic类型的
            //但是由于total是int类型的，所以totalTwo也是int类型的
            dynamic totalTwo = total;
            //故需要强制转化
            string jjj = totalTwo.ToString ();
            //所以，dynamic只不过是比var缺少了编译期间的检查
            //但它在刚开始执行的时候，就确定了变量的类型
            //所以用起来和var差不多
            Console.WriteLine (jjj);
            //使用dynamic简化反射
            //原始的写法
            DynamicSample dynamicSample = new DynamicSample ();
            //create instance为了简化演示，我没有使用反射
            var addMethod = typeof (DynamicSample).GetMethod ("Add");
            int re = default (int);
            for (int i = 0; i < 1000000; i++) //测试时间是436ms
            {
                re = (int) addMethod.Invoke (dynamicSample, new object[] { 1, 2 });
            }
            Console.WriteLine (re);
            //简化写法
            dynamic dynamicSample2 = new DynamicSample ();
            int re2 = default (int);
            for (int i = 0; i < 1000000; i++) //测试时间是43ms
            {
                re2 = dynamicSample2.Add (1, 2);
            }
            Console.WriteLine (re2);
            //我们可能会对这样的简化不以为然，毕竟看起来代码并没有减少多少，
            //但是，如果考虑到效率兼优美两个特性，那么dynamic的优势就显现出来了
            //编译器对dynamic进行了优化，比没有经过缓存的反射效率快了很多。
            //如果非要比较，可以将上面两者的代码（调用Add方法部分）运行1000000就可以得出结论
            Console.ReadKey ();
        }
    }
    public class DynamicSample {
        public string Name { get; set; }
        public int Add (int a, int b) {
            return a + b;
        }
    }
}