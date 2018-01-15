BitArray array1 = newBitArray (new [] { true, false, false, true, true });
BitArray array2 = newBitArray (new [] { true, false, true, false, false });

Console.WriteLine ("--Or--");
foreach (bool b in array1.Or (array2))
    Console.WriteLine (b);

array1 = newBitArray (new [] { true, false, false, true, true });
array2 = newBitArray (new [] { true, false, true, false, false });

Console.WriteLine ("\n--And--");
foreach (bool b in array1.And (array2))
    Console.WriteLine (b);

array1 = newBitArray (new [] { true, false, false, true, true });
array2 = newBitArray (new [] { true, false, true, false, false });

Console.WriteLine ("\n--Xor--");
foreach (bool b in array1.Xor (array2))
    Console.WriteLine (b);

Console.ReadLine ();