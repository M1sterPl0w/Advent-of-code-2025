namespace Day_3
{
	internal static class BatteryValidator
	{
		public static int ValidatePartOne(IEnumerable<string> batteries)
		{
			var total = 0;

			foreach (var battery in batteries)
			{
				var highestIndex = 0;
				var result = "";

				for (int i = 0; i < battery.Length; i++)
				{
					if (i == 0)
					{
						highestIndex = 0;
					}
					else
					{
						if (battery[i] > battery[highestIndex] && (i + 1) < battery.Length)
						{
							highestIndex = i;
						}
					}
				}

				result += battery[highestIndex];

				var highestSecondIndex = highestIndex + 1;
				for (int i = highestSecondIndex; i < battery.Length; i++)
				{
					if (battery[i] > battery[highestSecondIndex])
					{
						highestSecondIndex = i;
					}
				}

				result += battery[highestSecondIndex];


				total += int.Parse(result);
			}

			return total;
		}

		public static long ValidatePartTwo(IEnumerable<string> batteries)
		{
			long total = 0;
			var amountOfNumbers = 12; // set to any N >= 1

			foreach (var battery in batteries)
			{
				var result = "";
				int lastHighestIndex = -1;
				int length = battery.Length;

				for (int i = 0; i < amountOfNumbers; i++)
				{
					int startIndex = (i == 0) ? 0 : lastHighestIndex + 1;

					int maxIndex = length - amountOfNumbers + i;

					if (startIndex > maxIndex || startIndex >= length)
					{
						break;
					}

					int highestIndex = startIndex;
					for (int j = startIndex + 1; j <= maxIndex; j++)
					{
						if (battery[j] > battery[highestIndex])
						{
							highestIndex = j;
						}
					}

					lastHighestIndex = highestIndex;
					result += battery[highestIndex];
				}

				total += long.Parse(result);
			}

			return total;
		}
	}
}
