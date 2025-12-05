using Day_5;

var result = FoodChecker.FreshFood();
Console.WriteLine($"Amount of fresh foods: {result}");

var resultPartTwo = FoodChecker.CountPossibleFoodIds();
Console.WriteLine($"Amount of possible food ids: {resultPartTwo}");

Console.ReadKey();