using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApplication9 {
    class Program {
        static void Main (string[] args) {
            //IsGenericType
            ///////////////////////////////////////
            var v1 = typeof (DateTime).IsGenericType;
            Console.WriteLine (v1); //false
            var v2 = typeof (List<int>).IsGenericType;
            Console.WriteLine (v2); //true
            var v3 = typeof (Dictionary<,>).IsGenericType;
            Console.WriteLine (v3); //true
            //T[], List[] 等等数组时, IsGenericType为False
            //typeof(T[]).GetElementType().IsGenericType才是True
            var v4 = typeof (List<int>[]).IsGenericType;
            Console.WriteLine (v4); //false
            //IsGenericTypeDefinition
            //MakeGenericType
            //////////////////////////////
            //获取一个值，该值指示当前 Type 是否表示可以用来构造其他泛型类型的泛型类型定义。
            var v5 = typeof (List<int>).IsGenericTypeDefinition;
            Console.WriteLine (v5); //false
            var v6 = typeof (List<>).IsGenericTypeDefinition;
            Console.WriteLine (v6); //true
            //例子
            var typeList = typeof (List<>);
            Type typeDataList = typeList.MakeGenericType (typeof (DateTime)); //通过List<>构建出List<DateTime>
            //IsGenericParameter
            //////////////////////////////
            //表明当前类型是一个T类型
            var t = typeof (List<int>);
            t = typeof (Dictionary<string, object>);
            if (t.IsGenericType) {
                // If this is a generic type, display the type arguments.
                //
                Type[] typeArguments = t.GetGenericArguments ();
                Console.WriteLine ("\tList type arguments ({0}):",
                    typeArguments.Length);
                foreach (Type tParam in typeArguments) {
                    // If this is a type parameter, display its
                    // position.
                    //
                    if (tParam.IsGenericParameter) {
                        Console.WriteLine ("\t\t{0}\t(unassigned - parameter position {1})",
                            tParam,
                            tParam.GenericParameterPosition);
                    } else {
                        Console.WriteLine ("\t\t{0}", tParam);
                    }
                }
            }
        }
    }
}