//Using的特点Using 打开什么，就自动关闭什么，using中包含的其他类是否关闭，using是不管的
//XML文档读取
//重点：必须是标准的xml文档，否则会出错
string xmlxx = @"C:\1.xml";
using (XmlReader reader = XmlReader.Create(xmlxx))
{
    while (reader.Read())
    {
        if (reader.NodeType == XmlNodeType.Text)
        {
            Console.WriteLine(reader.Value + "\r\n");
        }
    }
}
Console.ReadKey();
