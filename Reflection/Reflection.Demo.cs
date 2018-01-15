using System.Reflection;
//加载指定的程序集
Assembly objAssembly = Assembly.load("mscorlib,2.0.0.0,Neutral,b77a5c561934e089");
//加载当前程序集
Assembly objAssembly = Assembly.GetExecutingAssembly();
