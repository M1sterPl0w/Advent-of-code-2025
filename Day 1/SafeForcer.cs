namespace Day_1
{
	internal class SafeForcer(int position)
	{
		public int TimesZeroHit { get; private set; } = 0;

		public void Attack(IEnumerable<string> rows)
		{
			foreach (var row in rows)
			{
				var direction = row[0];
				var moves = int.Parse(row[1..]);

				if (direction == 'L')
				{
					ClickLeft(moves);
				}
				else if (direction == 'R')
				{
					ClickRight(moves);
				}
				else
				{
					throw new InvalidOperationException("Unknown direction");
				}

				if (position == 0)
				{
					TimesZeroHit++;
				}
			}
		}

		private void ClickLeft(int moves)
		{
			position = ((position - moves) % 100 + 100) % 100;
		}

		private void ClickRight(int moves)
		{
			position = (position + moves) % 100;
		}
	}
}
