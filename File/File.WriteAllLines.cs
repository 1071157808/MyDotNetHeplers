
//如果文件不存在，则创建；存在则覆盖
//该方法写入字符数组换行显示
string[] lines = { "first line", "second line", "third line", "第四行" };
System.IO.File.WriteAllLines(@"C:\testDir\test.txt", lines, Encoding.UTF8);