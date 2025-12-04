using Day_3;

var batteries = BatteryReader.ReadRanges();

var resultPartOne = BatteryValidator.ValidatePartOne(batteries);
Console.WriteLine($"Result part one is: {resultPartOne}");

var resultPartTwo = BatteryValidator.ValidatePartTwo(batteries);
Console.WriteLine($"Result part two is: {resultPartTwo}");

Console.ReadKey();