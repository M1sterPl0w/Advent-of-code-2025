namespace Day_7
{
	internal static class BeamHelper
	{
		public static long CalculateAmountsOfBeam()
		{
			var path = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");
			if (!File.Exists(path))
			{
				throw new FileNotFoundException($"File not found: {path}");
			}

			_grid = File.ReadAllLines(path).Select(x => x.Select(c => c).ToArray()).ToArray();

			var sPosition = GetPosition(_grid);

			var beams = new Queue<(int row, int col)>();
			beams.Enqueue(sPosition);

			var seen = new List<(int row, int col)> { sPosition };

			var count = 0;

			while (beams.Count > 0)
			{
				var (r, c) = beams.Dequeue();
				if (_grid[r][c] == '.' || _grid[r][c] == 'S')
				{
					if (r == _grid.Length - 1)
					{
						continue;
					}
					if (!seen.Contains((r + 1, c)))
					{
						beams.Enqueue((r + 1, c));
						seen.Add((r + 1, c));
					}
				}
				else if (_grid[r][c] == '^')
				{
					count++;
					if (!seen.Contains((r, c - 1)))
					{
						beams.Enqueue((r, c - 1));
						seen.Add((r, c - 1));
					}

					if (!seen.Contains((r, c + 1)))
					{
						beams.Enqueue((r, c + 1));
						seen.Add((r, c + 1));
					}
				}
			}

			return count;
		}


		static char[][] _grid;
		static Dictionary<(int r, int c), long> memo = new();

		public static long CalculateAmountsOfPaths()
		{
			var path = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");
			if (!File.Exists(path))
			{
				throw new FileNotFoundException($"File not found: {path}");
			}

			_grid = File.ReadAllLines(path).Select(x => x.Select(c => c).ToArray()).ToArray();

			var sPosition = GetPosition(_grid);

			var result = Solve(sPosition.row, sPosition.col);

			return result;
		}

		static long Solve(int r, int c)
		{
			// Memoized?
			if (memo.TryGetValue((r, c), out long val))
				return val;

			// Base case: below _grid
			if (r >= _grid.Length)
				return memo[(r, c)] = 1;

			char cell = _grid[r][c];

			if (cell == '.' || cell == 'S')
			{
				return memo[(r, c)] = Solve(r + 1, c);
			}
			else if (cell == '^')
			{
				long left = Solve(r, c - 1);
				long right = Solve(r, c + 1);
				return memo[(r, c)] = left + right;
			}

			// In case of unexpected character
			return memo[(r, c)] = 0;
		}


		private static (int row, int col) GetPosition(char[][] grid, char character = 'S')
		{
			(int row, int col)? sPosition = null;
			for (int r = 0; r < grid.Length; r++)
			{
				var row = grid[r];
				for (int c = 0; c < row.Length; c++)
				{
					if (row[c] == character)
					{
						sPosition = (r, c);
						break;
					}
				}

				if (sPosition.HasValue)
				{
					break;
				}
			}

			if (sPosition == null) throw new Exception();

			return sPosition.Value;
		}
	}
}
