//匿名类型匿名方法
namespace Anonymous_Type
{
    delegate void Speak(string a);
    class Program
    {
        static void Main(string[] args)
        {
            //匿名类型
            var n = new { name = "school", age = 25 };
            Console.WriteLine(n.name);
            Console.WriteLine(n.age);
            //匿名方法
            Speak ss = delegate (string b) { Console.WriteLine("this is the string {0}", b); };
            ss("what do you want?");
            Console.ReadKey();
        }
    }
}
