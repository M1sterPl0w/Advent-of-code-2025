var path = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");
if (!File.Exists(path))
{
	throw new FileNotFoundException($"File not found: {path}");
}
var lines = File.ReadLines(path).ToArray();

var coordinates = lines.Select(x =>
{
	var split = x.Split(',');
	return (X: long.Parse(split[0]), Y: long.Parse(split[1]));
}
).ToList();
Console.WriteLine("Part one");

long areaResult = 0;

foreach (var a in coordinates)
{
	foreach (var b in coordinates)
	{
		if (a == b)
		{
			continue;
		}

		var tempArea = (Math.Abs(a.X - b.X) + 1) * (Math.Abs(a.Y - b.Y) + 1);
		if (tempArea > areaResult)
		{
			areaResult = tempArea;
		}
	}
}

Console.WriteLine($"Result part one, area of {areaResult} tiles");

Console.WriteLine("Part two");

//
//  YEAH, this not my code.... found it online and adapted it....  https://www.youtube.com/watch?v=RyLuE5xFLxw&t=508s
//

// Create circular tuple windows (consecutive pairs wrapping around)
var lineSegments = new List<((long X, long Y) Start, (long X, long Y) End)>();
for (int i = 0; i < coordinates.Count; i++)
{
	var start = coordinates[i];
	var end = coordinates[(i + 1) % coordinates.Count];
	lineSegments.Add((start, end));
}

// Find all combinations of two points and calculate areas
var candidateBoxes = new List<((long X, long Y) A, (long X, long Y) B, ulong Area)>();
for (int i = 0; i < coordinates.Count; i++)
{
	for (int j = i + 1; j < coordinates.Count; j++)
	{
		var a = coordinates[i];
		var b = coordinates[j];
		var area = (ulong)(Math.Abs(a.X - b.X) + 1) * (ulong)(Math.Abs(a.Y - b.Y) + 1);
		candidateBoxes.Add((a, b, area));
	}
}

// Sort by area descending
candidateBoxes = candidateBoxes.OrderByDescending(x => x.Area).ToList();

// Find the first box that doesn't intersect with any line segment
var maxBox = candidateBoxes.FirstOrDefault(box =>
{
	var (a, b, area) = box;

	// Check if this box doesn't intersect with any line segment
	return lineSegments.All(line =>
	{
		var (lineStart, lineEnd) = line;

		// Check if line segment is completely outside the rectangle
		var leftOfRect = Math.Max(a.X, b.X) <= Math.Min(lineStart.X, lineEnd.X);
		var rightOfRect = Math.Min(a.X, b.X) >= Math.Max(lineStart.X, lineEnd.X);
		var above = Math.Max(a.Y, b.Y) <= Math.Min(lineStart.Y, lineEnd.Y);
		var below = Math.Min(a.Y, b.Y) >= Math.Max(lineStart.Y, lineEnd.Y);

		return leftOfRect || rightOfRect || above || below;
	});
});

if (maxBox != default)
{
	Console.WriteLine($"Result part two, area of {maxBox.Area} tiles");
}
else
{
	Console.WriteLine("No valid box found");
}

Console.ReadKey();