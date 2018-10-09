using Battleship.Entity.Ship;
using System.Collections.Generic;
using System.Linq;

namespace Battleship
{
	public partial class Board
	{
		private int _boardSize;
		public List<Square> Squares { get; set; }

		public Board(int size = 10)
		{
			_boardSize = size;
			Squares = new List<Square>();
			for (int i = 1; i <= size; i++)
			{
				for (int j = 1; j <= size; j++)
				{
					Squares.Add(new Square(i, j));
				}
			}
		}

		public bool AddShip(Ship ship, Coordinate coordinate, Direction direction = Direction.Vertical)
		{
			var endRow = coordinate.Row;
			var endColumn = coordinate.Column;
			if (direction == Direction.Vertical)
			{
				endRow += ship.Length - 1;
			}
			else
			{
				endColumn += ship.Length - 1;

			}

			//get all avaialbe squares which are empty for ship's placement 
			var availableSquares = Squares.Where(x => x.Coordinate.Row >= coordinate.Row && x.Coordinate.Row <= endRow
										&& x.Coordinate.Column >= coordinate.Column && x.Coordinate.Column <= endColumn
										&& x.Ship == null).ToList();

			//if available squares are not enough , cannot place ship
			if (availableSquares.Count() < ship.Length)
			{
				return false;
			}

			//allocate squares to this ship
			availableSquares.ForEach(x => { x.Ship = ship; });

			return true;
		}

		public HitResult TakeAttack(Coordinate hitCoordinate)
		{
			HitResult result = new HitResult();
			var hitsquare = this.Squares.FirstOrDefault(x => x.Coordinate == hitCoordinate);
			if (hitsquare == null)
			{
				return new HitResult { IsValid = false, Message = "Coordinates out of range of Board." };
			}

			//Its a miss if no ship is at this square
			if (hitsquare.Ship == null)
			{
				return new HitResult { IsHit = false, Message = "Missed" };
			}
			else
			{
				//let ship take the hit
				hitsquare.Ship.TakeHit();

				string message = "Hit";

				if (hitsquare.Ship.IsSunk)
				{
					message = $"Hit and ${hitsquare.Ship.Name} sunk";
				}

				return new HitResult { IsHit = true, Message = message };
			}
		}
	}
}
