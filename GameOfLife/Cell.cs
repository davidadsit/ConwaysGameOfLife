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

		public static Cell FromChar(char c)
		{
			return c.ToString() == Alive.ToString() ? Alive : Dead;
		}

		public abstract bool IsAlive();
	}
}