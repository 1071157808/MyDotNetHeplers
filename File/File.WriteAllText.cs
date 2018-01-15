
//如果文件不存在，则创建；存在则覆盖
string strTest = "该例子测试一个字符串写入文本文件。";
System.IO.File.WriteAllText(@"C:\testDir\test1.txt", strTest, Encoding.UTF8);