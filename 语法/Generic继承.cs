//泛型继承

// Contravariant interface.
// InCovariant Demo
interface IContravariant<in A> { }
// Extending contravariant interface.
interface IExtContravariant<in A> : IContravariant<A> { }
// Implementing contravariant interface.
class Sample<A> : IContravariant<A> { }
class Program
{
    static void Test()
    {
        IContravariant<Object> iobj = new Sample<Object>();
        IContravariant<String> istr = new Sample<String>();
        // You can assign iobj to istr because
        // the IContravariant interface is contravariant.
        istr = iobj;
    }
}


//  OutCovariantDemo

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OutCovariantDemo
{
    // Covariant interface. 协变接口
    interface ICovariant<out R> { }
    // Extending covariant interface.扩展协变接口
    interface IExtCovariant<out R> : ICovariant<R> { }
    // Implementing covariant interface.实现协变接口
    class Sample<R> : ICovariant<R> { }
    class Program
    {
        static void Test()
        {
            ICovariant<Object> iobj = new Sample<Object>();
            ICovariant<String> istr = new Sample<String>();
            // You can assign istr to iobj because
            // the ICovariant interface is covariant.
            //协变泛型对象
            iobj = istr;
        }
    }
}

