using Battleship.Entity.Ship;
using System.Collections.Generic;
using System.Linq;
using static Battleship.Board;

namespace Battleship
{
	public class Player
	{
		public string Name { get; set; } = "Player 1";
		public List<Ship> Ships { get; set; } = new List<Ship>();

		public Board Board { get; set; }

		public Player(string name, Board board = null)
		{
			this.Name = name;
			this.Board = board ?? new Board(10);
		}

		public bool HasLost()
		{
			return this.Ships.All(x => x.IsSunk);
		}

		public bool AddShip(Ship ship, Coordinate coordinate, Direction direction = Direction.Vertical)
		{
			if (this.Board.AddShip(ship, coordinate, direction))
			{
				this.Ships.Add(ship);
				return true;
			}
			return false;
		}

		public HitResult TakeAttack(Coordinate hitCoordinate)
		{
			return this.Board.TakeAttack(hitCoordinate);
		}
	}
}
