using System;
using System.Collections; //使用Hashtable时，必须引入这个命名空间
class hashtable {
    public static void Main () {
        Hashtable ht = new Hashtable (); //创建一个Hashtable实例
        ht.Add ("E", "e"); //添加key/value键值对
        ht.Add ("A", "a");
        ht.Add ("C", "c");
        ht.Add ("B", "b");

        string s = (string) ht["A"];
        if (ht.Contains ("E")) //判断哈希表是否包含特定键,其返回值为true或false
            Console.WriteLine ("the E key:exist");
        ht.Remove ("C"); //移除一个key/value键值对
        Console.WriteLine (ht["A"]); //此处输出a
        ht.Clear (); //移除所有元素
        Console.WriteLine (ht["A"]); //此处将不会有任何输出
    }
}