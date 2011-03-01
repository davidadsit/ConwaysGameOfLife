namespace GameOfLife
{
	public class LiveCell : Cell
	{
		private const string LiveCellRepresentation = "O";

		public override bool IsAlive()
		{
			return true;
		}

		public override string ToString()
		{
			return LiveCellRepresentation;
		}
	}
}