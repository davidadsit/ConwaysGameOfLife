using GameOfLife;
using GameOfLife.Evolvers;
using GameOfLife.Evolvers.Implementations;
using NUnit.Framework;

namespace GameOfLifeTests
{
	[TestFixture]
	public class CellEvolverTests
	{
		[Test]
		public void CellEvolverIsAnICellEvolver()
		{
			Assert.IsInstanceOf(typeof(ICellEvolver), new CellEvolver());
		}

		[Test]
		public void When_a_living_cell_with_2_living_neighbors_evolves_the_result_is_alive()
		{
			CellEvolver cellEvolver = new CellEvolver();
			Cell evolved = cellEvolver.Evolve(new LiveCell(), new LiveCell(), new LiveCell());
			Assert.IsTrue(evolved.IsAlive());
		}
	}
}