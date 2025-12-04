namespace Day_3
{
	internal static class BatteryReader
	{
		public static IEnumerable<string> ReadRanges(string fileName = "batteries.txt")
		{
			var path = Path.Combine(Directory.GetCurrentDirectory(), fileName);


			if (!File.Exists(path))
			{
				throw new FileNotFoundException($"File not found: {path}");
			}

			foreach (var battery in File.ReadLines(path))
			{
				yield return battery.Trim();
			}
		}
	}
}
