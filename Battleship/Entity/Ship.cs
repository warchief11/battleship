namespace Battleship.Entity.Ship
{
	public class Ship
	{
		public string Name { get; set; }
		public int Length { get; set; }
		public int HitPoints { get; set; }
		public int TotalHP { get; set; }

		public Ship(string name, int length, int? totalHP = null)
		{
			this.Name = name;
			this.Length = length;
			this.TotalHP = totalHP ?? length;
			this.HitPoints = this.TotalHP;
		}

		public bool IsSunk
		{
			get
			{
				return HitPoints <= 0;
			}
		}

		public virtual void TakeHit(int hpLost = 1)
		{
			if (!this.IsSunk)
			{
				this.HitPoints -= hpLost;
			}
		}
	}
}
