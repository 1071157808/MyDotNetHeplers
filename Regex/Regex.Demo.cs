string test = "Abcccccc";
Regex reg = newRegex ("abc");
Console.WriteLine (reg.IsMatch (test)); //false
Regex reg1 = newRegex ("abc", RegexOptions.IgnoreCase); //不区分大小写
Console.WriteLine (reg1.IsMatch (test)); //true
string test = "vvv123===456vvv";
Regex reg = newRegex ("\\d+"); //  123 从左到右 匹配连续数字
Console.WriteLine (reg.Match (test));
//RightToLeft  从右到左 匹配连续数字
Regex reg1 = newRegex ("\\d+", RegexOptions.RightToLeft);
Console.WriteLine (reg1.Match (test)); // 456 从右到左 匹配连续数字
//MultiLine多行匹配
StringBuilder input = newStringBuilder ();
input.AppendLine ("A bbbb A");
input.AppendLine ("C bbbb C");
string pattern = @"^\w";
Console.WriteLine (input.ToString ());
MatchCollection matchCol = Regex.Matches (input.ToString (), pattern, RegexOptions.Multiline);
foreach (Match item in matchCol) {
    Console.WriteLine ("结果：{0}", item.Value);
}
//Replace()
string name3 = "xiaolizi";
var name4 = Regex.Replace (name3, @"[a-z]", "123");
Console.WriteLine (name4);
//Match()
string name = @"go ogle is a VERY good 20 company for
everybody!";
var bb = Regex.Match (name, @"goog?"); // []里面的空格也是算的，[]里面的元素是或的意思，匹配里面的字符串直至匹配不成功为止
Console.WriteLine (bb);
Console.ReadKey ();
//IsMatch()
string str1 = "abcbbbbbbbb";
string str2 = @"^abc";
Console.WriteLine (Regex.IsMatch (str1, str2)); //静态的重载方法