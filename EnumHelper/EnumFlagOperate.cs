
//Flag位运算例子：
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            Style ss = Style.ShowBorder | Style.ShowCaption;
            Console.WriteLine(ss.ToString());   //显示 ： ShowBorder,ShowCaption
            int i = (int)ss;   //强制转换可以直接将位运算计算成计算结果
            Console.WriteLine(i);  //显示：3
            Style s2 = (Style)Enum.Parse(typeof(Style), ss.ToString());
            Console.WriteLine(s2);  //显示：ShowBorder,ShowCaption
            s2 = s2 & (~Style.ShowCaption); //从枚举的多个Flags状态中去掉一个元素。
            Console.WriteLine(s2);   // 显示： ShowBorder
            Console.Read();
        }
    }
    [Flags]
    enum Style
    {
        ShowBorder = 1, //是否显示边框
        ShowCaption = 2, //是否显示标题
        ShowToolbox = 4 //是否显示工具箱
    }
}
