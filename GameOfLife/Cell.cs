namespace GameOfLife
{
	public abstract class Cell
	{
		public static Cell Alive
		{
			get { return new LiveCell(); }
		}

		public static Cell Dead
		{
			get { return new DeadCell(); }
		}

		public abstract bool IsAlive();
	}
}