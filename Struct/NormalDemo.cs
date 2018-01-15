class Program
{
    static void Main(string[] args)
    {
        StructOne structOne = new StructOne();
        structOne.Value = 1;
        Console.WriteLine(structOne.Value);
        StructTwo structTwo = new StructTwo(2);
        Console.WriteLine(structTwo.Value);
        structTwo.Value = 21;
        Console.WriteLine(structTwo.Value);
        StructThree structThree = new StructThree(3);
        Console.WriteLine(structThree.Value);
        structThree.Value = 31;
        Console.WriteLine(structThree.Value);
        Console.ReadKey();
    }
}
public struct StructOne
{
    public int Value { get; set; }
}
public struct StructTwo
{
    public int Value { get; set; }
    public StructTwo(int value)
    {
        this.Value = 2;
    }
}
public struct StructThree
{
    public int Value { get; set; }
    public StructThree(int value) : this()
    {
        this.Value = 3;
    }
}
