//这些类封装了这个task。。。所以我们可以用这些类来进行并行编程
//For
//串行计算
for (int i = 0; i < 100; i++) {
    Console.WriteLine (i);
}

//并行计算
Parallel.For (0, 100, (item) => {
    Console.WriteLine (item);
});

不要在Parallel.For中使用break或者stop，或许会给你引入一些不必要的bug。。。
因为大家都是并行执行的，所以别的线程是刹不住车的



//For的高级重载
//聚合函数是一样的。。。 其实就是一个并行的聚合计算
Parallel.For 可以实现一些数组的累计运算
Parallel.ForEach 应对一些集合运算 【非数组】
就是说Parallel函数，第一点就是要分区


