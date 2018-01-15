class Program
{
    static void Main(string[] args)
    {
        //out的用法
        int i = 1;
        int x;
        Add(i, out x); //x被带入计算并被返回，输出11
        Console.WriteLine(x);
        //ref的用法
        AddTen(ref i, ref x);
        Console.WriteLine(i);   //输出11
        Console.WriteLine(x);   //输出21
        //params的用法
        int[] intArray = new int[] { i, i + 1, i + 2 };
        AddParams(i, intArray); //被标注了params的数组是可变长的，是null的也可以
        Console.ReadKey();
    }
    public static void Add(int i, out int j)
    {
        j = i + 10;
    }
    public static void AddTen(ref int i, ref int j)
    {
        i = i + 10;
        j = j + 10;
    }
    public static void AddParams(int i, params int[] intArray)
    {
        Console.WriteLine(intArray[1]);
    }
}
