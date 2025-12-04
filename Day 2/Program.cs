// See https://aka.ms/new-console-template for more information


using Day_2;

var ranges = RangeReader.ReadRanges();

var result = IdValidator.ValidateRangesPartOne(ranges);

Console.WriteLine($"Result part 1 is: {result}");

var resultPartTwo = IdValidator.ValidateRangesPartTwo(ranges);

Console.WriteLine($"Result part 2 : {resultPartTwo}");

Console.ReadKey();
