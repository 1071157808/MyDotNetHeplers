var query = from number in new int[] { 4, 14, -3, 8 } select number;
var sequence = query.ToObservable ();
//这个scan输出每一位和前一位的累加值的计算结果，序列的首位默认不参与不计算
var runningSum = sequence.Scan ((accumlator, value) => accumlator + value);
//输出的是4
//设置累加器的默认值
var runningSum2 = sequence.Scan (10, (accumlator, value) => accumlator + value);
//输出的是40......
runningSum.Subscribe (Console.WriteLine);
Console.WriteLine ();
runningSum2.Subscribe (Console.WriteLine);

// ---------------------------------------------------------------------

//使用scan来处理数组
var query3 = from number in Inputs select number;
var sequence3 = query3.ToObservable ();
var runingAverage3 = sequence3.Scan (
        new double[] { 0, 0, 0 },
        (accumulator, value) => {
            //这里自定义逻辑
            accumulator[2] = accumulator[1];
            accumulator[1] = accumulator[0];
            accumulator[0] = value;
            return accumulator;
        })
    .Select (accumulator => accumulator.Sum () / 3.0);
Console.Read ();