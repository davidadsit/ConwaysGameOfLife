namespace GameOfLife
{
	public class DeadCell : Cell
	{
		private const string DeadCellRepresentation = "-";

		public override bool IsAlive()
		{
			return false;
		}

		public override string ToString()
		{
			return DeadCellRepresentation;
		}
	}
}