一：我们集合是没有锁机制的
   我们目前的所有集合都是线程不安全。。。
二：到底有哪些线程安全的集合
// System.Collections.Concurrent
1. ConcurrentQueue   => Queue
2. ConcurrentDictionary<TKey, TValue> => Dictionary
3. ConcurrentStack<T>    => Stack
4. ConcurrentBag<T>     ！=> List/ LinkList ???  都不对应
三：分析ConcurrentBag到底是什么样的数据结构
ThreadLocal 是什么意思？？？ 每个线程有一个自己的备份(线程不可见)
1. 每一个线程分配一个“链表” 这个链表可以任务是list（ThreadLocalList）
当你Ａｄｄ操作的时候，locals里面有一份新增的数据，【只有本线程看得见】
同时head和next也是有数据的。。。。为什么有？？因为我们的算法有一个“偷盗”的行为
TryTake: 获取数据
如果有三个线程做Add操作，那么三个线程的数据槽中都有一份子集数据。。。
t1: 1,2,3    locals
t2: 1,3,2    locals
t3: 2,3,4    locals 
这个时候，如果你在t3线程中执行了三个TryTake。。
t1: 1,2,3    locals
t2: 1,3,2    locals
t3: empty    locals
如果这个时候我在t3线程上进行tryTake，怎么办？？？
这个时候就到Bag的下一级的ttl head 和 next中去找。。。。【steal 偷盗的时候使用的】
    for (threadLocalList = this.m_headList; threadLocalList != null; threadLocalList = threadLocalList.m_nextList)
        {
            list.Add(threadLocalList.m_version);
            if (threadLocalList.m_head != null && this.TrySteal(threadLocalList, out result, take))
            {
                return true;
            }
        }

总结：ConcurrentBag就是利用线程槽来分摊Bag中的所有数据
ConcurrentBag的所有数据都是防止在多个插入线程的槽位中。。每个线程一个子集
链表的头插法
        static void Main(string[] args)
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();

            bag.Add(1);

            bag.Add(2);

            var result = 0;
            bag.TryTake(out result);
        }

2. ConcurrentStack

   线程安全的Stack是使用链表的形式，而同步版本是用 数组 实现的。。。
   线程安全的Stack是使用Interlocked来实现线程安全
        而没有使用 内核锁
        static void Main(string[] args)
        {
            ConcurrentStack<int> stack = new ConcurrentStack<int>();

            stack.Push(1);

            stack.Push(2);

            var result = 0;
            stack.TryPop(out result);

            Console.WriteLine(result);
        }

3. ConcurrentQueue   =>  同步版本使用 数组

        static void Main(string[] args)
        {
            ConcurrentQueue<int> queue = new ConcurrentQueue<int>();

            queue.Enqueue(1);

            var result = 0;
            queue.TryDequeue(out result);

            Console.WriteLine(result);
        }

4. ConcurrentDictionary

            ConcurrentDictionary<int, int> dic = new ConcurrentDictionary<int, int>();

            dic.TryAdd(1, 10);

            dic.ContainsKey(1);

            foreach (var item in dic)
            {
                Console.WriteLine(item.Key + item.Value);
            }

ConcurrentDictionary  => 同步 + lock/其他锁机制 也是可以的。。。



BlockingCollection<T> 与经典的阻塞队列数据结构类似，BlockingCollection<T>能够适用于多个任务添加和删除数据的生产者-消费者的情形。BlockingCollection<T>是对一个IProducerConsumer<T>实例的包装器，提供了阻塞和界限的能力。

ConcurrentBag<T>
提供了一个无需的对象集合。当不用考虑顺序时非常有用
。
ConcurrentDictionary<TKey, TValue>——
与经典的键•值对的字典类似，提供了并发
的键值访问

ConcurrentQueuc< T>--------
个 FIFO(first in, firsKmt，先进先出)的集合^•支持很多-
任务并发地进行元素入队和出队操作。

CencurrentStack<T>-------- 个LIFO(last in， first out，后逃先出）的集合，支持很多任务并发地进行压入和弹出元素操作。

