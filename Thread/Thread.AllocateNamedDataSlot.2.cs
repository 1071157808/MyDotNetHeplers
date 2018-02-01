using System;
using System.Threading;

class Test {
    public static void Main () {
        Thread[] newThreads = new Thread[4];
        int i;
        for (i = 0; i < newThreads.Length; i++) {
            newThreads[i] =
                new Thread (new ThreadStart (Slot.SlotTest));
            newThreads[i].Start ();
        }
        Thread.Sleep (2000);
        for (i = 0; i < newThreads.Length; i++) {
            newThreads[i].Join ();
            Console.WriteLine ("Thread_{0} finished.",
                newThreads[i].ManagedThreadId);
        }
    }
}

class Slot {
    private static Random randomGenerator = new Random ();

    public static void SlotTest () {
        // Set random data in each thread's data slot.
        int slotData = randomGenerator.Next (1, 200);
        int threadId = Thread.CurrentThread.ManagedThreadId;

        Thread.SetData (
            Thread.GetNamedDataSlot ("Random"),
            slotData);

        // Show what was saved in the thread's data slot.
        Console.WriteLine ("Data stored in thread_{0}'s data slot: {1,3}",
            threadId, slotData);

        // Allow other threads time to execute SetData to show
        // that a thread's data slot is unique to itself.
        Thread.Sleep (1000);

        int newSlotData =
            (int) Thread.GetData (Thread.GetNamedDataSlot ("Random"));

        if (newSlotData == slotData) {
            Console.WriteLine ("Data in thread_{0}'s data slot is still: {1,3}",
                threadId, newSlotData);
        } else {
            Console.WriteLine ("Data in thread_{0}'s data slot changed to: {1,3}",
                threadId, newSlotData);
        }
    }
}


// Data stored in thread_3's data slot: 191
// Data stored in thread_6's data slot: 182
// Data stored in thread_4's data slot:  93
// Data stored in thread_5's data slot: 127
// Data in thread_3's data slot is still: 191
// Data in thread_5's data slot is still: 127
// Data in thread_4's data slot is still:  93
// Data in thread_6's data slot is still: 182
// Thread_3 finished.
// Thread_4 finished.
// Thread_5 finished.
// Thread_6 finished