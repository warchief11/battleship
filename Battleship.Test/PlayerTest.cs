using Battleship.Entity.Ship;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Battleship.Board;

namespace Battleship.Test
{
	[TestClass]
	public class PlayerTest
	{
		[TestMethod]
		public void HasLost_ShouldReturnTrue_IfAllShipSunk()
		{
			//arrange
			var player = new Player("Test Player");
			var ship = ShipFactory.NewCruiser();

			var coordinate = new Coordinate(5, 1);
			player.AddShip(ship, coordinate, Direction.Horizontal);

			//act
			var result = player.TakeAttack(new Coordinate(5, 1));
			player.TakeAttack(new Coordinate(5, 2));
			player.TakeAttack(new Coordinate(5, 3));

			Assert.IsTrue(player.HasLost());
		}

		[TestMethod]
		public void HasLost_ShouldReturnFals_IfAllShipNotSunk()
		{
			//arrange
			var player = new Player("Test Player");
			var ship = ShipFactory.NewCruiser();

			var coordinate = new Coordinate(5, 1);
			player.AddShip(ship, coordinate, Direction.Horizontal);

			//act
			var result = player.TakeAttack(new Coordinate(5, 1));
			player.TakeAttack(new Coordinate(5, 2));

			Assert.IsFalse(player.HasLost());
		}
	}
}
