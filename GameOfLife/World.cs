using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
	public class World : IEnumerable<Coordinate>
	{
		private readonly Cell[,] _cells;

		public World(int height, int width)
		{
			if (height < 3 || width < 3)
			{
				throw new IndexOutOfRangeException("Sorry, the World must be at least 3x3.");
			}
			_cells = new Cell[height,width];
			foreach (Coordinate coordinate in this)
			{
				SetCell(coordinate, Cell.Dead);
			}
		}

		public World(string initialWorld)
		{
			string[] rows = initialWorld.Split(new[] {"\r\n"}, StringSplitOptions.None);
			int height = rows.Length;
			int width = rows[0].Trim().Replace(" ", string.Empty).Length;
			if (height < 3 || width < 3)
			{
				throw new IndexOutOfRangeException("Sorry, the World must be at least 3x3.");
			}
			_cells = new Cell[height,width];
			for (int i = 0; i < height; i++)
			{
				string row = rows[i].Trim().Replace(" ", string.Empty);
				for (int j = 0; j < row.Length; j++)
				{
					Coordinate coordinate = GetCoordinate(i, j);
					SetCell(coordinate, Cell.FromChar(row[j]));
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

		public Cell GetCell(Coordinate coordinate)
		{
			return _cells[coordinate.Row, coordinate.Column];
		}

		public Coordinate GetCoordinate(int row, int column)
		{
			if (row < 0 || column < 0 || row > _cells.GetUpperBound(0) || column > _cells.GetUpperBound(1))
			{
				throw new IndexOutOfRangeException("Can't create Coordinate out of bounds of World.");
			}
			return new Coordinate(row, column);
		}

		public IEnumerator<Coordinate> GetEnumerator()
		{
			for (int i = 0; i < Height; i++)
			{
				for (int j = 0; j < Width; j++)
				{
					yield return new Coordinate(i, j);
				}
			}
		}

		public List<Cell> GetNeighbors(Coordinate coordinate)
		{
			if (IsTopLeftCorner(coordinate))
			{
				return GetTopLeftCornerNeighbors();
			}
			if (IsTopRightCorner(coordinate))
			{
				return GetTopRightCornerNeighbors();
			}
			if (IsBottomLeftCorner(coordinate))
			{
				return GetBottomLeftCornerNeighbors();
			}
			if (IsBottomRightCorner(coordinate))
			{
				return GetBottomRightCornerNeighbors();
			}
			if (IsLeftEdge(coordinate))
			{
				return GetLeftEdgeNeighbors(coordinate);
			}
			if (IsRightEdge(coordinate))
			{
				return GetRightEdgeNeighbors(coordinate);
			}
			if (IsTopEdge(coordinate))
			{
				return GetTopEdgeNeighbors(coordinate);
			}
			if (IsBottomEdge(coordinate))
			{
				return GetBottomEdgeNeighbors(coordinate);
			}
			return new List<Cell>
			       	{
			       		GetCell(GetCoordinate(coordinate.Row - 1, coordinate.Column - 1)),
			       		GetCell(GetCoordinate(coordinate.Row - 1, coordinate.Column)),
			       		GetCell(GetCoordinate(coordinate.Row - 1, coordinate.Column + 1)),
			       		GetCell(GetCoordinate(coordinate.Row, coordinate.Column - 1)),
			       		GetCell(GetCoordinate(coordinate.Row, coordinate.Column + 1)),
			       		GetCell(GetCoordinate(coordinate.Row + 1, coordinate.Column - 1)),
			       		GetCell(GetCoordinate(coordinate.Row + 1, coordinate.Column)),
			       		GetCell(GetCoordinate(coordinate.Row + 1, coordinate.Column + 1)),
			       	};
		}

		public void SetCell(Coordinate coordinate, Cell cell)
		{
			_cells[coordinate.Row, coordinate.Column] = cell;
		}

		public override string ToString()
		{
			StringBuilder worldBuilder = new StringBuilder();
			for (int i = 0; i < Height; i++)
			{
				StringBuilder rowBuilder = new StringBuilder();
				for (int j = 0; j < Width; j++)
				{
					Coordinate coordinate = new Coordinate(i, j);
					rowBuilder.Append(GetCell(coordinate).ToString()).Append(" ");
				}
				worldBuilder.AppendLine(rowBuilder.ToString().TrimEnd());
			}
			return worldBuilder.ToString().TrimEnd();
		}

		private List<Cell> GetBottomEdgeNeighbors(Coordinate coordinate)
		{
			return new List<Cell>
			       	{
			       		GetCell(GetCoordinate(coordinate.Row, coordinate.Column - 1)),
			       		GetCell(GetCoordinate(coordinate.Row, coordinate.Column + 1)),
			       		GetCell(GetCoordinate(coordinate.Row - 1, coordinate.Column - 1)),
			       		GetCell(GetCoordinate(coordinate.Row - 1, coordinate.Column)),
			       		GetCell(GetCoordinate(coordinate.Row - 1, coordinate.Column + 1)),
			       	};
		}

		private List<Cell> GetBottomLeftCornerNeighbors()
		{
			return new List<Cell>
			       	{
			       		GetCell(GetCoordinate(Height - 1, 0)),
			       		GetCell(GetCoordinate(Height - 2, 1)),
			       		GetCell(GetCoordinate(Height - 2, 1)),
			       	};
		}

		private List<Cell> GetBottomRightCornerNeighbors()
		{
			return new List<Cell>
			       	{
			       		GetCell(GetCoordinate(Height - 1, Width - 2)),
			       		GetCell(GetCoordinate(Height - 2, Width - 2)),
			       		GetCell(GetCoordinate(Height - 2, Width - 1)),
			       	};
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		private List<Cell> GetLeftEdgeNeighbors(Coordinate coordinate)
		{
			return new List<Cell>
			       	{
			       		GetCell(GetCoordinate(coordinate.Row - 1, coordinate.Column)),
			       		GetCell(GetCoordinate(coordinate.Row + 1, coordinate.Column)),
			       		GetCell(GetCoordinate(coordinate.Row - 1, coordinate.Column + 1)),
			       		GetCell(GetCoordinate(coordinate.Row, coordinate.Column + 1)),
			       		GetCell(GetCoordinate(coordinate.Row + 1, coordinate.Column + 1)),
			       	};
		}

		private List<Cell> GetRightEdgeNeighbors(Coordinate coordinate)
		{
			return new List<Cell>
			       	{
			       		GetCell(GetCoordinate(coordinate.Row - 1, coordinate.Column)),
			       		GetCell(GetCoordinate(coordinate.Row + 1, coordinate.Column)),
			       		GetCell(GetCoordinate(coordinate.Row - 1, coordinate.Column - 1)),
			       		GetCell(GetCoordinate(coordinate.Row, coordinate.Column - 1)),
			       		GetCell(GetCoordinate(coordinate.Row + 1, coordinate.Column - 1)),
			       	};
		}

		private List<Cell> GetTopEdgeNeighbors(Coordinate coordinate)
		{
			return new List<Cell>
			       	{
			       		GetCell(GetCoordinate(coordinate.Row, coordinate.Column - 1)),
			       		GetCell(GetCoordinate(coordinate.Row, coordinate.Column + 1)),
			       		GetCell(GetCoordinate(coordinate.Row + 1, coordinate.Column - 1)),
			       		GetCell(GetCoordinate(coordinate.Row + 1, coordinate.Column)),
			       		GetCell(GetCoordinate(coordinate.Row + 1, coordinate.Column + 1)),
			       	};
		}

		private List<Cell> GetTopLeftCornerNeighbors()
		{
			return new List<Cell> {GetCell(GetCoordinate(1, 0)), GetCell(GetCoordinate(1, 1)), GetCell(GetCoordinate(0, 1)),};
		}

		private List<Cell> GetTopRightCornerNeighbors()
		{
			return new List<Cell>
			       	{
			       		GetCell(GetCoordinate(0, Width - 2)),
			       		GetCell(GetCoordinate(1, Width - 2)),
			       		GetCell(GetCoordinate(1, Width - 1)),
			       	};
		}

		private bool IsBottomEdge(Coordinate coordinate)
		{
			return coordinate.Row == Height - 1 && !IsBottomLeftCorner(coordinate) && !IsBottomRightCorner(coordinate);
		}

		private bool IsBottomLeftCorner(Coordinate coordinate)
		{
			return coordinate.Row == Height - 1 && coordinate.Column == 0;
		}

		private bool IsBottomRightCorner(Coordinate coordinate)
		{
			return coordinate.Row == Height - 1 && coordinate.Column == Width - 1;
		}

		private bool IsLeftEdge(Coordinate coordinate)
		{
			return coordinate.Column == 0 && !IsTopLeftCorner(coordinate) && !IsBottomLeftCorner(coordinate);
		}

		private bool IsRightEdge(Coordinate coordinate)
		{
			return coordinate.Column == Width - 1 && !IsTopRightCorner(coordinate) && !IsBottomRightCorner(coordinate);
		}

		private bool IsTopEdge(Coordinate coordinate)
		{
			return coordinate.Row == 0 && !IsTopLeftCorner(coordinate) && !IsTopRightCorner(coordinate);
		}

		private bool IsTopLeftCorner(Coordinate coordinate)
		{
			return coordinate.Row == 0 && coordinate.Column == 0;
		}

		private bool IsTopRightCorner(Coordinate coordinate)
		{
			return coordinate.Row == 0 && coordinate.Column == Width - 1;
		}
	}
}