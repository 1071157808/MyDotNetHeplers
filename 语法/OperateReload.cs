//运算符重载
namespace 运算符重载
{
    class Program
    {
        public int Value { get; set; }
        static void Main(string[] args)
        {
            // 运算符重载
            ///若要在自定义类中重载运算符，您需要在该类中创建具有正确签名的方法。
            /// 该方法必须命名为“operator X”，其中 X 是正在重载的运算符的名称或符号。
            /// 一元运算符具有一个参数，二元运算符具有两个参数。
            /// 在每种情况下，参数的类型必须与声明该运算符的类或结构的类型相同
            /// public static Complex operator +(Complex c1, Complex c2)
            Program t1 = new Program();
            t1.Value = 11;
            Program t2 = new Program();
            t2.Value = 22;
            Program t3 = t1 * t2;
            Console.WriteLine(t3.Value);
            Console.ReadKey();
        }
        public static Program operator *(Program p1, Program p2)
        {
            Program t1 = new Program();
            t1.Value = p1.Value + p2.Value;
            return t1;
        }
    }
}
