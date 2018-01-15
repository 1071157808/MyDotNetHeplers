using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApplication7 {
    class Program {
        static void Main () {
            Console.WriteLine (Test ());
            Console.ReadKey ();
        }
        static int Test () {
            int num = 0;
            try {
                num = 1;
                throw new Exception ("Exception in try");
                return num;
            } catch (Exception e) {
                Console.WriteLine (e.Message);
                return num;
            } finally {
                //不管有木有出现异常，finally块中代码都会执行
                //当try和catch中有return时，finally仍然会执行
                //finally是在return后面的表达式运算后执行的（此时并没有返回运算后的值，
                //而是先把要返回的值保存起来，管finally中的代码怎么样，返回的值都不会改变，
                //仍然是之前保存的值），所以函数返回值是在finally执行前确定的
                //finally中无法包含return
                num++;
                Console.WriteLine ("num={0},Exception in finally", num);
            }
        }
    }
}