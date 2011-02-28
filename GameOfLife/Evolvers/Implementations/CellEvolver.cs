using System.Linq;

namespace GameOfLife.Evolvers.Implementations
{
	public class CellEvolver : ICellEvolver
	{
		public Cell Evolve(Cell cell, params Cell[] neighbors)
		{
			int livingNeighbors = neighbors.Count(x => x.IsAlive());
			if (livingNeighbors > 3 || livingNeighbors < 2)
			{
				return Cell.Dead;
			}
			return Cell.Alive;
		}
	}
}