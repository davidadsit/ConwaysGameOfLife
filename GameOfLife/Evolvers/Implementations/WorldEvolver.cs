using System.Collections.Generic;

namespace GameOfLife.Evolvers.Implementations
{
	public class WorldEvolver : IWorldEvolver
	{
		private readonly ICellEvolver _cellEvolver;

		public WorldEvolver(ICellEvolver cellEvolver)
		{
			_cellEvolver = cellEvolver;
		}

		public World Evolve(World world)
		{
			World evolved = new World(world.Height, world.Width);
			foreach (Coordinate coordinate in evolved)
			{
				Cell unevolvedCell = world.GetCell(coordinate);
				List<Cell> neighbors = world.GetNeighbors(coordinate);
				Cell evolvedCell = _cellEvolver.Evolve(unevolvedCell, neighbors.ToArray());
				evolved.SetCell(coordinate, evolvedCell);
			}
			return evolved;
		}
	}
}