The ObjectContext instance has been disposed and can no longer be used for 

这个错误使用using（）｛｝再新建一个db对象来处理db中的各种数据，可能是iis对数据库连接池有GC操作
