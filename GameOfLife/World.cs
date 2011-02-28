using System.Text;

namespace GameOfLife
{
	public class World
	{
		private readonly Cell[,] _cells;

		public World(int height, int width)
		{
			_cells = new Cell[height,width];
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					SetCell(i, j, Cell.Dead);
				}
			}
		}

		public int Height
		{
			get { return _cells.GetUpperBound(0) + 1; }
		}

		public int Width
		{
			get { return _cells.GetUpperBound(1) + 1; }
		}

		public Cell GetCell(int row, int column)
		{
			return _cells[row, column];
		}

		public void SetCell(int row, int column, Cell cell)
		{
			if (row < 0 || column < 0 || row > _cells.GetUpperBound(0) || column > _cells.GetUpperBound(1))
			{
				return;
			}
			_cells[row, column] = cell;
		}

		public override string ToString()
		{
			StringBuilder worldBuilder = new StringBuilder();
			for (int i = 0; i < Height; i++)
			{
				StringBuilder rowBuilder = new StringBuilder();
				for (int j = 0; j < Width; j++)
				{
					rowBuilder.Append(GetCell(i, j).IsAlive() ? "O " : "- ");
				}
				worldBuilder.AppendLine(rowBuilder.ToString().TrimEnd());
			}
			return worldBuilder.ToString().TrimEnd();
		}
	}
}