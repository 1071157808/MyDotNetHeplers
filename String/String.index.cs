
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "深圳市盈基实业有限公司国际通邓事文*深圳市盈基实业有限公司国际通邓事文";
            Label1.Text = str.IndexOf("中国").ToString();//返回 -1
            Label1.Text = str.IndexOf("盈基").ToString();//返回 3
            Label1.Text = str.IndexOf("盈基", 10).ToString();//返回21 说明：这是从第10个字符开始查起。
            Label1.Text = str.IndexOf("邓", 15, 10).ToString();//返回 -1
            Label1.Text = str.IndexOf("邓", 15, 20).ToString();//返回 -32 说明：从第15个字符开始查找，要查找的范围是从第15个字符开始后20个字符，即从第15-35个字符中查找。
            Console.Read();
        }
    }
}
