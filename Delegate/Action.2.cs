Action<int> printRoot = delegate (int number) {
    Console.WriteLine (Math.Sqrt (number));
};
Action<IList<double>> printMean = delegate (IList<double> numbers) {
    double total = 0;
    foreach (double value in numbers) {
        total += value;
    }
    Console.WriteLine (total / numbers.Count);
};