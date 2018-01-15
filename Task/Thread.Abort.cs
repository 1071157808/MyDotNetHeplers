ThreadStart ts = new ThreadStart(Speak);
Thread aa = new Thread(ts);
aa.Start();
aa.Abort();
ts += Speak2;
aa.Start(); // 这个会报错，因为已经被终止的线程无法再开启

// 注意：避免在正式的生产代码中使用Abort()函数，因为可能造成不可预测的结果，造成程序不稳定