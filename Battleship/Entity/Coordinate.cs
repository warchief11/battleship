namespace Battleship
{
	public partial class Board
	{
		public struct Coordinate
		{
			public int Row { get; set; }
			public int Column { get; set; }

			public Coordinate(int row, int col)
			{
				this.Row = row;
				this.Column = col;
			}

			public static bool operator ==(Coordinate c1, Coordinate c2)
			{
				return c1.Equals(c2);
			}

			public static bool operator !=(Coordinate c1, Coordinate c2)
			{
				return !c1.Equals(c2);
			}

			public override bool Equals(object obj)
			{
				if (obj == null || GetType() != obj.GetType())
				{
					return false;
				}
				var objectToCompareWith = (Coordinate)obj;
				return objectToCompareWith.Row == Row && objectToCompareWith.Column == Column;
			}
		}
	}
}
