// StreamReader 的Read方法的使用
StreamReader sr = new StreamReader(@"E:\\111.txt", Encoding.GetEncoding("GB2312"));
//通常需要转码为GB2312
int Ichar = 0;
   while ((Ichar = sr.Read()) != -1)
   // 不再有可用的字符，则为 -1
   {
       Console.Write(Convert.ToChar(Ichar).ToString()
   );
    //StreamReader的Read方法返回的是字符串的二进制数字
    //可以用ToChar转换成ASCII字符串，将int类型转成ASCII字符 }
    Console.ReadKey();
