dynamic dyn = 1;
int j = dyn;
//下面这句话会无法通过编译,typeof 运算符无法用在动态类型上
//如果你是typeof(dynamic)会报typeof运算符无法用在动态类型上的错误
//Console.WriteLine(typeof(dynamic));
Console.WriteLine(typeof(List<dynamic>));
//在大多数情况下， dynamic 类型与 object 类型的行为是一样的
//但是，不会用编译器对包含 dynamic 类型表达式的操作进行解析或类型检查
// 编译器将有关该操作信息打包在一起，并且该信息以后用于计算运行时操作
//在此过程中，类型 dynamic 的变量会编译到类型 object 的变量中
// 因此，类型 dynamic 只在编译时存在，在运行时则不存在。
