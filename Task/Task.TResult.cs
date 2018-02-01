一：Task<TResult>
   前些课程主要讲没有返回值的task，本节课就超重去说这个有“返回值”的
实际开发中，带有TResult的形式还是特别多
二：Task<TResult>是继承于Task
1. Result 多了此属性
<2> 直接TResult
2. ContinueWith<TResult> 也可以具有返回值
3. Task.WhenAll<TResult>/ WhenAny
二：异常
AggregateException  是一个集合，因为task中可能会抛出多个异常，所以我们需要一种新的类型
把这些异常都追加到一个集合中
1. 什么时候抛出异常： Wait操作， TResult操作
2. 何时会有多个异常在 AggregateException，以及如何去一个一个的去获取
3. Handle方法，就是处理当前的异常数组，判断上一层我当前哪些已经处理好了，
   没有处理好的，还需要向上抛出
当前的Handle就是来遍历 异常数组，如果有一个异常信息是这样的，我认为是已经处理的。
如果你觉得异常还需要往上抛，请返回false，

