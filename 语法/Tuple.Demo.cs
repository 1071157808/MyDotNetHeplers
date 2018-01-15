//Tuple元组类型是根据item来取值，根据放入的顺序来决定item1,item2等等
// Create a 7-tuple.
var population = new Tuple<string, int, int, int, int, int, int>(
"New York", 7891957, 7781984,
7894862, 7071639, 7322564, 8008278);
// Display the first and last elements.
Console.WriteLine ("Population of {0} in 2000: {1:N0}",
    population.Item1, population.Item7);
// The example displays the following output://      Population of New York in 2000: 8,008,2781
//不过最多还是放入8位数字（  Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> ），而且调用第八位数字的时候，需要使用XXX.Rest.Item1这种调用方法
//正常的是（ Tuple<T1, T2, T3, T4, T5, T6, T7> ）
var primes = Tuple.Create (2, 3, 5, 7, 11, 13, 17, 19);
Console.WriteLine ("Prime numbers less than 20: " +
    "{0}, {1}, {2}, {3}, {4}, {5}, {6}, and {7}",
    primes.Item1, primes.Item2, primes.Item3,
    primes.Item4, primes.Item5, primes.Item6,
    primes.Item7, primes.Rest.Item1);
// The example displays the following output://    Prime numbers less than 20: 2, 3, 5, 7, 11, 13, 17, and 19