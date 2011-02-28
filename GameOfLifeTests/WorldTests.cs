using GameOfLife;
using NUnit.Framework;

namespace GameOfLifeTests
{
	[TestFixture]
	public class WorldTests
	{
		private const int Height = 3;
		private const int Width = 4;

		[Test]
		public void Cell_can_be_retrieved_as_set()
		{
			World world = new World(Height, Width);
			const int row = 2;
			const int column = 2;
			world.SetCell(row, column, Cell.Alive);
			Assert.IsTrue(world.GetCell(row, column).IsAlive());
		}


		[Test]
		public void Corner_cells_can_be_set()
		{
			World world = new World(Height, Width);
			world.SetCell(0, 0, Cell.Alive);
			world.SetCell(0, Width - 1, Cell.Alive);
			world.SetCell(Height - 1, Width - 1, Cell.Alive);
			world.SetCell(Height - 1, 0, Cell.Alive);
		}

		[Test]
		public void SetCell_ignores_out_of_bounds_calls()
		{
			World world = new World(Height, Width);
			world.SetCell(-1, 0, Cell.Alive);
			world.SetCell(0, -1, Cell.Alive);
			world.SetCell(Height, Width - 1, Cell.Alive);
			world.SetCell(Height - 1, Width, Cell.Alive);
		}

		[Test]
		public void World_is_initialized_with_dead_cells()
		{
			World world = new World(Height, Width);
			for (int i = 0; i < Height; i++)
			{
				for (int j = 0; j < Width; j++)
				{
					Assert.IsFalse(world.GetCell(i, j).IsAlive());
				}
			}
		}

		[Test]
		public void World_size_is_set_at_constuction()
		{
			World world = new World(Height, Width);
			Assert.AreEqual(Height, world.Height);
			Assert.AreEqual(Width, world.Width);
		}

		[Test]
		public void ToString_returns_a_grid_representing_the_world()
		{
			World world = new World(3, 3);
			Assert.AreEqual("- - -\r\n- - -\r\n- - -", world.ToString());
			world.SetCell(0, 0, Cell.Alive);
			world.SetCell(2, 0, Cell.Alive);
			world.SetCell(1, 1, Cell.Alive);
			world.SetCell(0, 2, Cell.Alive);
			world.SetCell(2, 2, Cell.Alive);
			Assert.AreEqual("O - O\r\n- O -\r\nO - O", world.ToString());
		}
	}
}