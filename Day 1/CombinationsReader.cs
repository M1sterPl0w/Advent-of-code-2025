namespace Day_1
{
	internal static class CombinationsReader
	{
		public static IEnumerable<string> ReadRows(string fileName = "combinations.txt")
		{
			var path = Path.Combine(Directory.GetCurrentDirectory(), fileName);


			if (!File.Exists(path))
			{
				throw new FileNotFoundException($"File not found: {path}");
			}

			foreach (var raw in File.ReadLines(path))
			{
				var line = raw?.Trim();
				if (string.IsNullOrEmpty(line))
					continue;
				yield return line;
			}
		}
	}
}
