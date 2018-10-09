using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Entity.Ship
{
	public static class ShipFactory
	{
		public static Ship NewCarrier()
		{
			return new Ship("Carrier", 5, 5);
		}

		public static Ship NewBatteship()
		{
			return new Ship("BattleShip", 4, 4);
		}

		public static Ship NewCruiser()
		{
			return new Ship("Cruiser", 3, 3);
		}

		public static Ship NewSubmarine()
		{
			return new Ship("Submarine ", 3, 3);
		}

		public static Ship NewDestoryer()
		{
			return new Ship("Destroyer", 2, 2);
		}
	
	}
}
