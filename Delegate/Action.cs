
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1
{
    class TestAction
    {
        public static void Main(String[] args)
        {
            var t = new Test();
            t.DoSome = a => Console.WriteLine(a);
            t.DoSome("asdfasdf");
            Console.ReadKey();
        } //main
    } //IsInstanceTes
    public class Test
    {
        public Action<string> DoSome { get; set; }
    }
}




//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            var cache = new Cache<int, string>();
            var entity = cache.GetEntity(1, ctx =>
            {
                //这里的Monitor是被配置好的action，所以这是直接调用
                ctx.Monitor(false);
                return "xxxxx";
            });
            Console.WriteLine(entity.Result);
            Console.Read();
        }
    }
    public class Cache<TKey, TResult>
    {
        public Entity GetEntity(TKey key, Func<AcquireContext<TKey>, TResult> aquire)
        {
            var entity = new Entity();
            // 将entity的DoSomething给monitor
            var context = new AcquireContext<TKey>(key, entity.DoSomeThing);
            // 将AcquireContext的TResult 返回给entity的TResult
            entity.Result = aquire(context);
            return entity;
        }
        public class Entity
        {
            public TResult Result { get; set; }
            public void DoSomeThing(bool tt)
            {
                Console.WriteLine("我是Entity中的DoSomeThing");
            }
        }
    }
    public class AcquireContext<TKey>
    {
        public AcquireContext(TKey key, Action<bool> monitor)
        {
            Key = key;
            Monitor = monitor;
        }
        public TKey Key { get; private set; }
        public Action<bool> Monitor { get; private set; }
    }
}
