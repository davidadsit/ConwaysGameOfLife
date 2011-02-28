using GameOfLife;
using NUnit.Framework;

namespace GameOfLifeTests
{
	[TestFixture]
	public class LiveCellTests
	{
		[Test]
		public void LiveCellIsACell()
		{
			Assert.IsInstanceOf(typeof (Cell), new LiveCell());
		}

		[Test]
		public void LiveCellIsAlive()
		{
			Cell cell = new LiveCell();
			Assert.IsTrue(cell.IsAlive());
		}
	}
}