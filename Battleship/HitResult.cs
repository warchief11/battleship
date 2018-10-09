namespace Battleship
{
	public partial class Board
	{
		public class HitResult
		{
			public bool IsValid { get; set; }
			public bool IsHit { get; set; }
			public string Message { get; set; }
		}
	}
}
