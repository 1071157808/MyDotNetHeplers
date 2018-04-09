using System;
using System.Threading;

class Test {
    static void Main () {
        Thread[] newThreads = new Thread[4];
        for (int i = 0; i < newThreads.Length; i++) {
            newThreads[i] = new Thread (
                new ThreadStart (Slot.SlotTest));
            newThreads[i].Start ();
        }
    }
}
//虽然所有thread公用要给LocalDataStoreSlot对象，但是这个对象对每个thread来说都是单独的
//这种方式没有[ThreadStaticAttribute] 这种性能好
class Slot {
    static Random randomGenerator;
    static LocalDataStoreSlot localSlot;

    static Slot () {
        randomGenerator = new Random ();
        localSlot = Thread.AllocateDataSlot ();
    }

    public static void SlotTest () {
        // Set different data in each thread's data slot.
        Thread.SetData (localSlot, randomGenerator.Next (1, 200));

        // Write the data from each thread's data slot.
        Console.WriteLine ("Data in thread_{0}'s data slot: {1,3}",
            AppDomain.GetCurrentThreadId ().ToString (),
            Thread.GetData (localSlot).ToString ());

        // Allow other threads time to execute SetData to show
        // that a thread's data slot is unique to the thread.
        Thread.Sleep (1000);

        Console.WriteLine ("Data in thread_{0}'s data slot: {1,3}",
            AppDomain.GetCurrentThreadId ().ToString (),
            Thread.GetData (localSlot).ToString ());
    }
}



// Data in thread_5512's data slot:  41
// Data in thread_3448's data slot: 111
// Data in thread_5476's data slot: 127
// Data in thread_13356's data slot: 120
// Data in thread_5512's data slot:  41
// Data in thread_3448's data slot: 111
// Data in thread_13356's data slot: 120
// Data in thread_5476's data slot: 127