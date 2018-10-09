using Battleship.Entity.Ship;

namespace Battleship
{
	public partial class Board
	{
		public class Square
		{
			public Coordinate Coordinate { get; set; }
			public Ship Ship { get; set; }

			public Square(int row, int col)
			{
				this.Coordinate = new Coordinate(row, col);
			}

			public Square(Coordinate coordinate)
			{
				this.Coordinate = coordinate;
			}
		}
	}
}
