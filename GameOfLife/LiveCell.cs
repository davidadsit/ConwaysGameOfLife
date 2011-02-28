using System;

namespace GameOfLife
{
	public class LiveCell : Cell
	{
		public override bool IsAlive()
		{
			return true;
		}
	}
}