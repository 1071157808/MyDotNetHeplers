//int string Enum之间的转换
class Program
{
    static void Main(string[] args)
    {
        MyColor Page = (MyColor)1;
        //输出red
        Console.WriteLine(Page);
        MyColor Page2 = (MyColor)2;
        //输出2
        Console.WriteLine(Page2);
        //enum -> int
        int num = (int)Countries.中国;
        //num=5
        int[] nums = (int[])Enum.GetValues(typeof(Countries));
        //nums={5,6,7,8,9}
        //int -> enum
        Countries country = (Countries)8;
        //country=Countries.英国
        //enum -> string
        string str2 = Enum.GetName(typeof(Countries), 7);
        Console.WriteLine(str2);
        string[] strArray = Enum.GetNames(typeof(Countries));
        //strArray={"中国","美国","俄罗斯","英国","法国"};
        //string-> enum
        Countries myCountry = (Countries)Enum.Parse(typeof(Countries), "中国");
        //myCountry=Countries.中国
        Console.ReadKey();
    }
}
enum MyColor { Red = 1, Yellow = 3, Blue = 4 };
enum Countries
{
    中国 = 5,
    美国,
    俄罗斯,
    英国,
    法国
}
