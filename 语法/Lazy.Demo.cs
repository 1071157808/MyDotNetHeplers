
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp30
{
    class Program
    {
        static void Main(string[] args)
        {
            Lazy<Large> lazyObject = new Lazy<Large>();
            //初始化的时候使用了里面的函数也不行，
            //必须是在lazy外单独调用了lazy对象里面的属性或者值才行
            Console.WriteLine(lazyObject.IsValueCreated);
            //lazyObject.Value.Test();
            lazyObject.Value.Name = "asdfa";
            Console.WriteLine(lazyObject.IsValueCreated);
            Console.Read();
        }
    }
    [Serializable]
    class Large
    {
        public Large()
        {
            Test();
        }
        public string Name { get; set; }
        public void Test()
        {
            Console.WriteLine("Test");
        }
    }
}
