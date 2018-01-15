using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace Throw {
    class Program {
        static List<int> testList = new List<int> () { 1, 2, 3, 4, 5 };
        static void Main (string[] args) {
            foreach (var item in testList) {
                Console.WriteLine (item);
            }
            Console.WriteLine ();
            foreach (var item in Test ()) {
                Console.WriteLine (item);
            }
            Console.Read ();
        }
        static IEnumerable<int> Test () {
            foreach (var item in testList) {
                if (item > 3) {
                    //yield可以记住游标
                    //所以必须配合IEnumberable<T>来使用
                    //IEnumerable是无法使用游标的
                    yield return item;
                }
            }
        }
    }
}