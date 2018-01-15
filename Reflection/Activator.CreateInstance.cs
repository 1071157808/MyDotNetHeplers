C#在类工厂中动态创建类的实例，所使用的方法为：
1. Activator.CreateInstance (Type)
2. Activator.CreateInstance (Type, Object[])


两种方法区别仅为：创建无参数的构造方法和创建有参数的构造函数。
//Activator.CreateInstance(Type)
object result = null;
Type typeofControl =null;
typeofControl = Type.GetType(vFullClassName);
result = Activator.CreateInstance(typeofControl);
//Activator.CreateInstance(Type,Object[])
object result = null;
Type typeofControl =null;
typeofControl = Type.GetType(vFullClassName);
result = Activator.CreateInstance(typeofControl, objParam);


但是在动态创建时，可能会动态使用到外部应用的DLL中类的实例，则此时需要进行反编译操作，使用Reflection命名控件下的Assembly类。
//先使用Assembly类载入DLL，再根据类的全路径获取类

object result = null;
Type typeofControl = null;
Assembly tempAssembly;
tempAssembly = Assembly.LoadFrom(vDllName);
typeofControl = tempAssembly.GetType(vFullClassName);
result = Activator.CreateInstance(typeofControl, objParam);

