using System.Linq;

namespace GameOfLife.Evolvers.Implementations
{
	public class B3S23CellEvolver : ICellEvolver
	{
		public Cell Evolve(Cell cell, params Cell[] neighbors)
		{
			int livingNeighbors = neighbors.Count(x => x.IsAlive());
			if (livingNeighbors > 3 || livingNeighbors < 2)
			{
				return Cell.Dead;
			}
			return livingNeighbors == 2 ? cell : Cell.Alive;
		}
	}
}