在winform，或者wpf中如果给一个控件赋值，都是调用invoke方法
《1》不要再UIThread做非常耗时的任务，否则会出问题。。。。
《2》 耗时的操作我们要放到threadpool，更新操作放到同步上下文中

