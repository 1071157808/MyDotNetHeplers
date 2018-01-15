
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1
{
    public interface IMyIfc
    {
    } //IMyIfc
    public class MyClass : IMyIfc
    {
    } //MyClass
    public class MyDerivedClass : MyClass
    {
    } //MyDerivedClass
    class IsInstanceTest
    {
        public static void Main(String[] args)
        {
            Type imyifcType = typeof(IMyIfc);
            MyClass mc = new MyClass();
            Type mcType = mc.GetType();
            MyClass mdc = new MyDerivedClass();
            Type mdcType = mdc.GetType();
            int[] array = new int[10];
            Type arrayType = typeof(Array);
            Console.WriteLine("Is int[] an instance of the Array class? {0}.",
                System.Convert.ToString(arrayType.IsInstanceOfType(array)));
            Console.WriteLine("Is myclass an instance of MyClass? {0}.",
                System.Convert.ToString(mcType.IsInstanceOfType(mc)));
            Console.WriteLine("Is myderivedclass an instance of MyClass? {0}.",
                System.Convert.ToString(mcType.IsInstanceOfType(mdc)));
            Console.WriteLine("Is myclass an instance of IMyIfc? {0}.",
                System.Convert.ToString(imyifcType.IsInstanceOfType(mc)));
            Console.WriteLine("Is myderivedclass an instance of IMyIfc? {0}.",
                System.Convert.ToString(imyifcType.IsInstanceOfType(mdc)));
            Console.Read();
        } //main
    } //IsInstanceTes
}





using System;
public interface IExample { }
public class BaseClass : IExample { }
public class DerivedClass : BaseClass { }
public class Example
{
    public static void Main()
    {
        var interfaceType = typeof(IExample);
        var base1 = new BaseClass();
        var base1Type = base1.GetType();
        var derived1 = new DerivedClass();
        var derived1Type = derived1.GetType();
        int[] arr = new int[11];
        Console.WriteLine("Is int[] an instance of the Array class? {0}.",
                           typeof(Array).IsInstanceOfType(arr));
        Console.WriteLine("Is base1 an instance of BaseClass? {0}.",
                          base1Type.IsInstanceOfType(base1));
        Console.WriteLine("Is derived1 an instance of BaseClass? {0}.",
                          base1Type.IsInstanceOfType(derived1));
        Console.WriteLine("Is base1 an instance of IExample? {0}.",
                          interfaceType.IsInstanceOfType(base1));
        Console.WriteLine("Is derived1 an instance of IExample? {0}.",
                          interfaceType.IsInstanceOfType(derived1));
    }
}
// The example displays the following output:
//    Is int[] an instance of the Array class? True.
//    Is base1 an instance of BaseClass? True.
//    Is derived1 an instance of BaseClass? True.
//    Is base1 an instance of IExample? True.
//    Is derived1 an instance of IExample? True.

