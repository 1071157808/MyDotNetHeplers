一：Plinq => linq
为了能够达到最大的灵活度，linq有了并行的版本

二：如何将linq转换为plinq。。。
linq to object 
            var nums = Enumerable.Range(0, 100);
            var query = from n in nums.AsParallel()
                        select new
                        {
                            thread = Thread.CurrentThread.ManagedThreadId,
                            num = n
                        };
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
AsParallel() 可以将串行的代码转换为并行
AsOrdered() 就是将并行结果还是按照 未排序的样子（原始的序列顺序）进行排序
asOrdered => orderby
[10,1,2,3,4]  => 并行计算.asOrderrd => [10,1,2,3,4]
[10,1,2,3,4]  => orderby             =>[1,2,3,4,10]
AsUnordered()  不按照原始的顺序排序
AsSequential()  <=> AsParallel() 是相对应的
AsSequential     前者将plinq转换为linq
AsParallel   后者将linq转换为plinq


plinq底层都是用task的
基于task的一些编程模型，让我们快速进行并行计算的
WithDegreeOfParallelism：
WithDegreeOfParallelism(Environment.ProcessorCount) 告诉plinq当前8个线程都要参与
WithCancellation： 如果执行之前被取消，那就不要执行了
WithExecutionMode：此参数可以告诉系统当前是否强制并行
public enum ParallelExecutionMode
{
    Default = 0,
    ForceParallelism = 1
 }
Plinq ：主要是划分区块，然后对区块进行聚合计算，从而达到分而治之
        sum
smallsum   smallsum   smallsum  smallsum
      -> mergesum   <-              -> mergesum  <-
                      ->  totalsum  <
最灵活的东西莫过于自己去写业务逻辑，封装的越厉害，灵活性越差，性能自然也越差

