System.Collections.IDictionaryEnumerator d = ht.GetEnumerator();
while (d.MoveNext())
{
Console.WriteLine("key：{0} value：{1}", d.Entry.Key, d.Entry.Value);
} 
// 看了这个方法就一下子理解了IEnumerator类型和GetEnumerator方法的用法
