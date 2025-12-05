namespace Day_4
{
	internal static class WarehouseManager
	{
		private static char[][] ClearAllFlags(char[][] warehouse)
		{
			for (int i = 0; i < warehouse.Length; i++)
			{
				for (int j = 0; j < warehouse[i].Length; j++)
				{
					if (warehouse[i][j] == 'X')
					{
						warehouse[i][j] = '.';
					}
				}
			}

			return warehouse;
		}

		public static long CheckAmountPaperRollsThatCanBeRemoved_PartTwo()
		{
			long totalResult = 0;
			var warehouse = GetWarehouse();
			while (true)
			{
				long result = 0;
				warehouse = ClearAllFlags(warehouse);

				for (int row = 0; row < warehouse.Length; row++)
				{
					for (int cell = 0; cell < warehouse[row].Length; cell++)
					{
						if (warehouse[row][cell] != '@')
						{
							continue;
						}

						var adjecentRolls = 0;

						// Check row above
						if (!(row - 1 < 0))
						{
							if (cell - 1 >= 0)
							{
								if (warehouse[row - 1][cell - 1] == '@' || warehouse[row - 1][cell - 1] == 'X')
								{
									adjecentRolls++;
								}
							}

							if (warehouse[row - 1][cell] == '@' || warehouse[row - 1][cell] == 'X')
							{
								adjecentRolls++;
							}

							if (cell + 1 < warehouse[row].Length)
							{
								if (warehouse[row - 1][cell + 1] == '@' || warehouse[row - 1][cell + 1] == 'X')
								{
									adjecentRolls++;
								}
							}
						}
						// Check current row
						if (cell - 1 >= 0)
						{
							if (warehouse[row][cell - 1] == '@' || warehouse[row][cell - 1] == 'X')
							{
								adjecentRolls++;
							}
						}

						if (cell + 1 < warehouse[row].Length)
						{
							if (warehouse[row][cell + 1] == '@' || warehouse[row][cell + 1] == 'X')
							{
								adjecentRolls++;
							}
						}

						// Check row below
						if (row + 1 < warehouse.Length)
						{
							if (cell - 1 >= 0)
							{
								if (warehouse[row + 1][cell - 1] == '@' || warehouse[row + 1][cell - 1] == 'X')
								{
									adjecentRolls++;
								}
							}

							if (warehouse[row + 1][cell] == '@' || warehouse[row + 1][cell] == 'X')
							{
								adjecentRolls++;
							}

							if (cell + 1 < warehouse[row].Length)
							{
								if (warehouse[row + 1][cell + 1] == '@' || warehouse[row + 1][cell + 1] == 'X')
								{
									adjecentRolls++;
								}
							}
						}

						if (adjecentRolls < 4)
						{
							warehouse[row][cell] = 'X';
							result++;
						}
					}
				}

				if (result == 0)
				{
					break;
				}

				totalResult += result;
			}

			return totalResult;
		}


		public static long CheckAmountPaperRollsThatCanBeRemoved_PartOne()
		{
			long result = 0;

			var warehouse = GetWarehouse();

			for (int row = 0; row < warehouse.Length; row++)
			{
				for (int cell = 0; cell < warehouse[row].Length; cell++)
				{
					if (warehouse[row][cell] != '@')
					{
						continue;
					}

					var adjecentRolls = 0;

					// Check row above
					if (!(row - 1 < 0))
					{
						if (cell - 1 >= 0)
						{
							if (warehouse[row - 1][cell - 1] == '@' || warehouse[row - 1][cell - 1] == 'X')
							{
								adjecentRolls++;
							}
						}

						if (warehouse[row - 1][cell] == '@' || warehouse[row - 1][cell] == 'X')
						{
							adjecentRolls++;
						}

						if (cell + 1 < warehouse[row].Length)
						{
							if (warehouse[row - 1][cell + 1] == '@' || warehouse[row - 1][cell + 1] == 'X')
							{
								adjecentRolls++;
							}
						}
					}
					// Check current row
					if (cell - 1 >= 0)
					{
						if (warehouse[row][cell - 1] == '@')
						{
							adjecentRolls++;
						}
					}

					if (cell + 1 < warehouse[row].Length)
					{
						if (warehouse[row][cell + 1] == '@')
						{
							adjecentRolls++;
						}
					}

					// Check row below
					if (row + 1 < warehouse.Length)
					{
						if (cell - 1 >= 0)
						{
							if (warehouse[row + 1][cell - 1] == '@')
							{
								adjecentRolls++;
							}
						}

						if (warehouse[row + 1][cell] == '@')
						{
							adjecentRolls++;
						}

						if (cell + 1 < warehouse[row].Length)
						{
							if (warehouse[row + 1][cell + 1] == '@')
							{
								adjecentRolls++;
							}
						}
					}

					if (adjecentRolls < 4)
					{
						result++;
					}
				}

			}
			return result;
		}

		private static char[][] GetWarehouse(string fileName = "input.txt")
		{
			var path = Path.Combine(Directory.GetCurrentDirectory(), fileName);


			if (!File.Exists(path))
			{
				throw new FileNotFoundException($"File not found: {path}");
			}

			var lines = new List<char[]>();

			foreach (var row in File.ReadLines(path))
			{
				lines.Add(row.ToArray());
			}

			return [.. lines];
		}
	}
}
