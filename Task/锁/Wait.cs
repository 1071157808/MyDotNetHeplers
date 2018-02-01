<1> 原始的WaitOne函数调用方式
// System.Threading.WaitHandle
[SecurityCritical]
[MethodImpl (MethodImplOptions.InternalCall)]
private static extern int WaitOneNative 
    (SafeHandle waitableSafeHandle, uint millisecondsTimeout, 
        bool hasThreadAffinity, bool exitContext); 

<2> 新的Wait方式
for (int i = 0; i < spinCount; i++) {
    if (this.IsSet) {
        return true;
    }
    if (i < num2) {
        if (i == num2 / 2) {
            Thread.Yield ();
        } else {
            Thread.SpinWait (PlatformHelper.ProcessorCount * (4 << i));
        }
    } else {
        if (i % num4 == 0) {
            Thread.Sleep (1);
        } else {
            if (i % num3 == 0) {
                Thread.Sleep (0);
            } else {
                Thread.Yield ();
            }
        }
    }
    if (i >= 100 && i % 10 == 0) {
        cancellationToken.ThrowIfCancellationRequested ();
    }
}