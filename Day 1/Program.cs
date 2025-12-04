using Day_1;

var rows = CombinationsReader.ReadRows();

var safeForcer = new SafeForcer(50);
safeForcer.Attack(rows);

Console.WriteLine($"Result: {safeForcer.TimesZeroHit}");

Console.ReadKey();