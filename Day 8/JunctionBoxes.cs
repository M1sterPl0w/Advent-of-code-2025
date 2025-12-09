namespace Day_8
{
	internal static class JunctionBoxes
	{
		private static List<(int x, int y, int z)> _boxes = new();

		private static string[] LoadBoxes()
		{
			_boxes = new List<(int x, int y, int z)>();
			var path = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");
			if (!File.Exists(path))
			{
				throw new FileNotFoundException($"File not found: {path}");
			}
			var lines = File.ReadLines(path).ToArray();

			return lines;
		}

		public static long PartOne()
		{
			var boxes = new List<int[]>();
			var inputFile = LoadBoxes();

			foreach (var line in inputFile)
			{
				boxes.Add(line.Split(',')
							  .Select(int.Parse)
							  .ToArray());
			}

			int n = boxes.Count;

			// Build all edges
			var edges = new List<(int A, int B, double Dist)>();
			for (int i = 0; i < n; i++)
			{
				for (int j = i + 1; j < n; j++)
				{
					double dist = Distance(boxes[i], boxes[j]);
					edges.Add((i, j, dist));
				}
			}

			// Sort edges by distance
			edges.Sort((e1, e2) => e1.Dist.CompareTo(e2.Dist));

			// Union-Find setup
			var parent = Enumerable.Range(0, n).ToArray();

			int Root(int x)
			{
				if (parent[x] == x) return x;
				parent[x] = Root(parent[x]);
				return parent[x];
			}

			void Merge(int a, int b)
			{
				parent[Root(a)] = Root(b);
			}

			// Merge first 1000 edges
			int limit = Math.Min(1000, edges.Count);
			for (int i = 0; i < limit; i++)
			{
				var e = edges[i];
				Merge(e.A, e.B);
			}

			// Count sizes of connected components
			var sizes = new int[n];
			for (int i = 0; i < n; i++)
			{
				sizes[Root(i)]++;
			}

			Array.Sort(sizes);
			Array.Reverse(sizes);

			// Print product of top 3
			long result = (long)sizes[0] * sizes[1] * sizes[2];

			return result;
		}

		public static long PartTwo()
		{
			var boxes = new List<int[]>();
			var inputFile = LoadBoxes();

			foreach (var line in inputFile)
			{
				boxes.Add(line.Split(',')
							  .Select(int.Parse)
							  .ToArray());
			}

			int n = boxes.Count;

			// Build all edges
			var edges = new List<(int A, int B, double Dist)>();
			for (int i = 0; i < n; i++)
			{
				for (int j = i + 1; j < n; j++)
				{
					double dist = Distance(boxes[i], boxes[j]);
					edges.Add((i, j, dist));
				}
			}

			// Sort edges by distance
			edges.Sort((e1, e2) => e1.Dist.CompareTo(e2.Dist));

			// Union-Find setup
			var parent = Enumerable.Range(0, n).ToArray();

			int Root(int x)
			{
				if (parent[x] == x) return x;
				parent[x] = Root(parent[x]);
				return parent[x];
			}

			void Merge(int a, int b)
			{
				parent[Root(a)] = Root(b);
			}

			var circuits = boxes.Count;

			var result = 0;

			for (int i = 0; i < edges.Count; i++)
			{
				var e = edges[i];
				if (Root(e.A) == Root(e.B)) continue;
				Merge(e.A, e.B);
				circuits -= 1;
				if (circuits == 1)
				{
					result = boxes[e.A][0] * boxes[e.B][0];
					break;
				}
			}

			return result;
		}

		static double Distance(int[] a, int[] b)
		{
			double sum = 0;
			for (int i = 0; i < a.Length; i++)
			{
				double diff = a[i] - b[i];
				sum += diff * diff;
			}
			return Math.Sqrt(sum);
		}
	}
}
