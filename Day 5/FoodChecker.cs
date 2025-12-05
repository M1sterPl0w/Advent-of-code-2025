namespace Day_5
{
	internal static class FoodChecker
	{
		private static List<long> GetFoodIds()
		{
			var result = new List<long>();

			var path = Path.Combine(Directory.GetCurrentDirectory(), "foods.txt");

			if (!File.Exists(path))
			{
				throw new FileNotFoundException($"File not found: {path}");
			}

			foreach (var foodId in File.ReadLines(path))
			{
				result.Add(long.Parse(foodId));
			}

			return result;
		}

		private static List<Tuple<long, long>> GetFoodRanges()
		{
			var result = new List<Tuple<long, long>>();
			var path = Path.Combine(Directory.GetCurrentDirectory(), "food_ranges.txt");
			if (!File.Exists(path))
			{
				throw new FileNotFoundException($"File not found: {path}");
			}

			foreach (var range in File.ReadLines(path))
			{
				var parts = range.Split('-', StringSplitOptions.RemoveEmptyEntries);
				if (parts.Length == 2)

				{
					var start = long.Parse(parts[0]);
					var end = long.Parse(parts[1]);
					result.Add(new Tuple<long, long>(start, end));
				}
			}
			return result;
		}

		public static long CountPossibleFoodIds()
		{
			var foodRanges = GetFoodRanges();
			var sorted = foodRanges.OrderBy(r => r.Item1).ToList();

			long total = 0;
			long curStart = sorted[0].Item1;
			long curEnd = sorted[0].Item2;

			for (int i = 1; i < sorted.Count; i++)
			{
				var rStart = sorted[i].Item1;
				var rEnd = sorted[i].Item2;

				// safe overlap/adjacency check that avoids overflow on curEnd + 1
				bool adjacentOrOverlap = rStart <= curEnd || (curEnd != long.MaxValue && rStart == curEnd + 1);

				if (adjacentOrOverlap)
				{
					if (rEnd > curEnd) curEnd = rEnd;
				}
				else
				{
					// add merged range length (checked to surface overflow if it happens)
					total = total + (curEnd - curStart + 1);
					curStart = rStart;
					curEnd = rEnd;
				}
			}

			// add final merged range
			total = total + (curEnd - curStart + 1);
			return total;
		}

		public static int FreshFood()
		{
			var result = 0;

			var foodIds = GetFoodIds();
			var foodRanges = GetFoodRanges();

			foreach (var id in foodIds)
			{
				foreach (var range in foodRanges)
				{
					if (id >= range.Item1 && id <= range.Item2)
					{
						result++;
						break;
					}
				}
			}

			return result;
		}
	}
}
