using System;

namespace GameOfLife.Evolvers.Implementations
{
	public class CellEvolver : ICellEvolver
	{
		public Cell Evolve(Cell cell, params Cell[] neighbors)
		{
			return Cell.Alive;
		}
	}
}