
//在将文本写入文件前，处理文本行
//StreamWriter一个参数默认覆盖
//StreamWriter第二个参数为false覆盖现有文件，为true则把文本追加到文件末尾
using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\testDir\test2.txt", true))
{
　　foreach (string line in lines)
　　{
　　　　if (!line.Contains("second"))
　　　　{
　　　　　　file.Write(line);//直接追加文件末尾，不换行
　　　　　　file.WriteLine(line);// 直接追加文件末尾，换行
　　　　}
　　}
}