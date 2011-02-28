using GameOfLife;
using NUnit.Framework;

namespace GameOfLifeTests
{
	[TestFixture]
	public class DeadCellTests
	{
		[Test]
		public void DeadCellIsACell()
		{
			Assert.IsInstanceOf(typeof (Cell), new DeadCell());
		}

		[Test]
		public void DeadCellIsAlive()
		{
			Cell cell = new DeadCell();
			Assert.IsFalse(cell.IsAlive());
		}
	}
}