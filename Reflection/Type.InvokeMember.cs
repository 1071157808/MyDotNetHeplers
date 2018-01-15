
Assembly assembly = Assembly.LoadFrom(sDllName);
Type fType = assembly.GetType(sClassName);
object instance = Activator.CreateInstance(fType);
fType.InvokeMember("classmethod",BindingFlags.InvokeMethod,null,instance,sParams);//调用指定实例instance的classmethod方法，sParams为传入参数，数量不固定，达到方法的重载
//InvokeMethod  指定要调用一个方法。它不能是构造函数或类型初始值设定项。
