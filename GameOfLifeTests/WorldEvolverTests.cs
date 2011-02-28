using GameOfLife.Evolvers;
using GameOfLife.Evolvers.Implementations;
using NUnit.Framework;

namespace GameOfLifeTests
{
	[TestFixture]
	public class WorldEvolverTests
	{
		[Test]
		public void WorldEvolver_is_an_IWorldEvolver()
		{
			Assert.IsInstanceOf(typeof (IWorldEvolver), new WorldEvolver());
		}
	}
}