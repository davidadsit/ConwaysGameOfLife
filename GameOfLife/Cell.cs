using System;

namespace GameOfLife
{
	public abstract class Cell
	{
		public abstract bool IsAlive();

		public static Cell Alive
		{
			get
			{
				return new LiveCell();
			}
		}

		public static Cell Dead
		{
			get { return new DeadCell(); }
		}
	}
}