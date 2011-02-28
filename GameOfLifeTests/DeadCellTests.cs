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
			Cell cell = Cell.Dead;
			Assert.IsFalse(cell.IsAlive());
		}

		[Test]
		public void DeadNamedCtorReturnsDeadCell()
		{
			Assert.IsInstanceOf(typeof (DeadCell), Cell.Dead);
		}
	}
}