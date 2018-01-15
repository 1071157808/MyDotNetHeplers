//反射中的Types
//从程序集获取所有的
types Type[] types = objAssembly.GetTypes();
//从程序集中获取某个类的类型
Type t = objAssembly.GetType("Relfection.Car", false, true);
//另外两种获取类型的方法
Type t2 = Type.GetType("System.String", false, true);
Type t3 = typeof(string);
//查看类型的全名
Type typeName = t.FullName();
//使用Activator动态创建对象
//使用Activator的静态方法CreateInstance创建类型t的实例
object obj = Activator.CreateInstance(t);
