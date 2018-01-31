BindingFlags.Default  
//不指定绑定标志
BindingFlags.IgnoreCase
//表示忽略 name 的大小写，不应考虑成员名的大小写
BindingFlags.DeclaredOnly
//只应考虑在所提供类型的层次结构级别上声明的成员。不考虑继承成员。
BindingFlags.Instance
//只搜索实例成员
BindingFlags.Static
//只搜索静态成员
BindingFlags.Public
//只搜索公共成员
BindingFlags.NonPublic
//只搜索非公共成员（即私有成员和受保护的成员）。
BindingFlags.FlattenHierarchy
//应返回层次结构上的公共静态成员和受保护的静态成员。不返回继承类中的私有静态成员。静态成员包括字段、方法、事件和属性。不返回嵌套类型。
BindingFlags.InvokeMethod
//表示调用方法，而不调用构造函数或类型初始值设定项。对 SetField 或 SetProperty 无效。
BindingFlags.CreateInstance
//表示调用构造函数。忽略 name。对其他调用标志无效。
BindingFlags.GetField
//表示获取字段值。对 SetField 无效。
BindingFlags.SetField
//表示设置字段值。对 GetField 无效。
BindingFlags.GetProperty
//表示获取属性。对 SetProperty 无效。
BindingFlags.SetProperty
//表示设置属性。对 GetProperty 无效。
参考资料：反射中BindingFlags的值   http://www.studyofnet.com/news/1046.html



