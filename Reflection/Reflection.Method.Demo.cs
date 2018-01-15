//MethodInfo的使用，取得方法、属性、字段
//从类型中获取方法的实例
MethodInfo m = t.GetMethod("testFunction");
//调用testFunction方法，并传入实例化的对象和参数
var tt = m.Invoke(obj, "param");
//从类型中获取字段
var m = t.GetFields();
//从类型中获取属性
var m = t.GetProperites();
