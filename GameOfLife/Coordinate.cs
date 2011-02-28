using System;

namespace GameOfLife
{
	public class Coordinate
	{
		private readonly int _column;
		private readonly int _row;

		internal Coordinate(int row, int column)
		{
			_row = row;
			_column = column;
		}

		public int Column
		{
			get { return _column; }
		}

		public int Row
		{
			get { return _row; }
		}
	}
}