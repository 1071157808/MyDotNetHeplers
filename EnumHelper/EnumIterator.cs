
//Enum遍历
namespace Enum遍历
{
    enum aa { a = 1, b = 2, c = 3 };
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var a in Enum.GetValues(typeof(aa)))
            {
                string s = $" {a} ";
                object num = a;
                string name = a.ToString();
                Console.WriteLine(s);
            }
            //上面输出的是  a  b  c
            foreach (int a in Enum.GetValues(typeof(aa)))
            {
                string s = $" {a} ";
                Console.WriteLine(s);
            }
            //上面这段代码输出的是 1  2   3
            //感觉这个可能是枚举类型的一个方法，虽然Enum.GetValues返回的是一个数组，但是这个数组
            //是string类型数组，还是int类型数组，是有var  或者int决定的
            Console.ReadKey();
        }
    }
}
