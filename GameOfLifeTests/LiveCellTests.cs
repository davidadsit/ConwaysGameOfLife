using GameOfLife;
using NUnit.Framework;

namespace GameOfLifeTests
{
	[TestFixture]
	public class LiveCellTests
	{
		[Test]
		public void AliveNamedCtorReturnsLiveCell()
		{
			Assert.IsInstanceOf(typeof (LiveCell), Cell.Alive);
		}

		[Test]
		public void LiveCellIsACell()
		{
			Assert.IsInstanceOf(typeof (Cell), new LiveCell());
		}

		[Test]
		public void LiveCellIsAlive()
		{
			Cell cell = Cell.Alive;
			Assert.IsTrue(cell.IsAlive());
		}
	}
}