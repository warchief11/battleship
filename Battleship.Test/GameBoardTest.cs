using System;
using System.Linq;
using Battleship.Entity.Ship;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Battleship.Board;

namespace Battleship.Test
{
	[TestClass]
	public class GameBoardTest
	{
		[TestMethod]
		public void AddShip_ShouldAddAShip()
		{
			var board = new Board(10);
			var ship = ShipFactory.NewBatteship();
			var coordinate = new Coordinate(3, 3);
			var result = board.AddShip(ship, coordinate, Direction.Horizontal);
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void AddShipHorizontal_ShouldAddHorizontally()
		{
			var board = new Board(10);
			var ship = ShipFactory.NewDestoryer();
			var coordinate = new Coordinate(3, 3);

			var result = board.AddShip(ship, coordinate, Direction.Horizontal);

			var squaresWithShip = board.Squares.Where(x => x.Ship == ship);

			//verify rows are same
			Assert.AreEqual(squaresWithShip.Where(x => x.Coordinate.Row == coordinate.Row).Count(), ship.Length);
			Assert.AreEqual(squaresWithShip.Select(x => x.Coordinate.Column).Distinct().Count(), ship.Length);
		}

		[TestMethod]
		public void AddShipVertical_ShouldAddVertically()
		{
			var board = new Board(10);
			var ship = ShipFactory.NewDestoryer();
			var coordinate = new Coordinate(3, 3);

			var result = board.AddShip(ship, coordinate, Direction.Vertical);

			var squaresWithShip = board.Squares.Where(x => x.Ship == ship);

			//verify columns are same
			Assert.AreEqual(squaresWithShip.Where(x => x.Coordinate.Column == coordinate.Column).Count(), ship.Length);
			Assert.AreEqual(squaresWithShip.Select(x => x.Coordinate.Row).Distinct().Count(), ship.Length);
		}

		[TestMethod]
		public void AddShip_ShouldNotAdd_IfCordinatesOutside()
		{
			var board = new Board(10);
			var ship = ShipFactory.NewBatteship();

			var coordinate = new Coordinate(12, 12);
			var result = board.AddShip(ship, coordinate, Direction.Horizontal);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void AddShip_ShouldNotAdd_IfShipFallsOutsideBoundary()
		{
			var board = new Board(10);
			var ship = ShipFactory.NewBatteship();

			var coordinate = new Coordinate(0, 9);
			var result = board.AddShip(ship, coordinate, Direction.Horizontal);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void AddShip_ShouldNotAdd_IfSpotIsNotEmpty()
		{
			//arrange
			var board = new Board(10);
			var ship = ShipFactory.NewBatteship();

			var coordinate = new Coordinate(5, 1);
			var result = board.AddShip(ship, coordinate);

			//act
			ship = ShipFactory.NewBatteship();
			coordinate = new Coordinate(3, 1);
			result = board.AddShip(ship, coordinate);

			//assert
			Assert.IsFalse(result);
		}


		[TestMethod]
		public void TakeAttack_ShouldReturnHit_IfHit()
		{
			//arrange
			var board = new Board(10);
			var ship = ShipFactory.NewBatteship();

			var coordinate = new Coordinate(5, 1);
			board.AddShip(ship, coordinate, Direction.Horizontal);

			//act
			var result = board.TakeAttack(new Coordinate(5, 3));

			//assert
			Assert.IsTrue(result.IsHit);
		}

		[TestMethod]
		public void TakeAttack_ShouldReturnMiss_IfMissed()
		{
			//arrange
			var board = new Board(10);
			var ship = ShipFactory.NewBatteship();

			var coordinate = new Coordinate(5, 1);
			board.AddShip(ship, coordinate, Direction.Horizontal);

			//act
			var result = board.TakeAttack(new Coordinate(6, 3));

			//assert
			Assert.IsFalse(result.IsHit);
		}
	}
}
