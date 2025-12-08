using Day_7;

var result = BeamHelper.CalculateAmountsOfBeam();
Console.WriteLine($"Amount of beam: {result}");

var resultPaths = BeamHelper.CalculateAmountsOfPaths();
Console.WriteLine($"Amount of paths: {resultPaths}");

Console.ReadKey();