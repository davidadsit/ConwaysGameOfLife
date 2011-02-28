namespace GameOfLife
{
	public class DeadCell : Cell
	{
		public override bool IsAlive()
		{
			return false;
		}
	}
}