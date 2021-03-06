using System.Collections.Generic;
using GameOfLife;
using GameOfLife.Evolvers;
using GameOfLife.Evolvers.Implementations;
using NUnit.Framework;

namespace GameOfLifeTests
{
	[TestFixture]
	public class CellEvolverTests
	{
		private const int DefaultNeighbors = 8;

		[Test]
		public void CellEvolver_is_an_ICellEvolver()
		{
			Assert.IsInstanceOf(typeof (ICellEvolver), new B3S23CellEvolver());
		}

		[Test]
		public void When_a_dead_cell_with_3_living_neighbors_evolves_the_result_is_alive()
		{
			B3S23CellEvolver cellEvolver = new B3S23CellEvolver();
			Cell evolved = cellEvolver.Evolve(Cell.Dead, GetNeighbors(3));
			Assert.IsTrue(evolved.IsAlive());
		}

		[Test]
		public void When_a_dead_cell_with_2_living_neighbors_evolves_the_result_is_dead()
		{
			B3S23CellEvolver cellEvolver = new B3S23CellEvolver();
			Cell evolved = cellEvolver.Evolve(Cell.Dead, GetNeighbors(2));
			Assert.IsFalse(evolved.IsAlive());
		}

		[Test]
		public void When_a_living_cell_with_0_living_neighbors_evolves_the_result_is_dead()
		{
			B3S23CellEvolver cellEvolver = new B3S23CellEvolver();
			Cell evolved = cellEvolver.Evolve(Cell.Alive, GetNeighbors(0));
			Assert.IsFalse(evolved.IsAlive());
		}

		[Test]
		public void When_a_living_cell_with_1_living_neighbors_evolves_the_result_is_dead()
		{
			B3S23CellEvolver cellEvolver = new B3S23CellEvolver();
			Cell evolved = cellEvolver.Evolve(Cell.Alive, Cell.Alive);
			Assert.IsFalse(evolved.IsAlive());
		}

		[Test]
		public void When_a_living_cell_with_2_living_and_1_dead_neighbor_evolves_the_result_is_alive()
		{
			B3S23CellEvolver cellEvolver = new B3S23CellEvolver();
			Cell evolved = cellEvolver.Evolve(Cell.Alive, GetNeighbors(2, 1));
			Assert.IsTrue(evolved.IsAlive());
		}

		[Test]
		public void When_a_living_cell_with_2_living_neighbors_evolves_the_result_is_alive()
		{
			B3S23CellEvolver cellEvolver = new B3S23CellEvolver();
			Cell evolved = cellEvolver.Evolve(Cell.Alive, GetNeighbors(2));
			Assert.IsTrue(evolved.IsAlive());
		}

		[Test]
		public void When_a_living_cell_with_3_living_neighbors_evolves_the_result_is_alive()
		{
			B3S23CellEvolver cellEvolver = new B3S23CellEvolver();
			Cell evolved = cellEvolver.Evolve(Cell.Alive, GetNeighbors(3));
			Assert.IsTrue(evolved.IsAlive());
		}

		[Test]
		public void When_a_living_cell_with_4_living_neighbors_evolves_the_result_is_dead()
		{
			B3S23CellEvolver cellEvolver = new B3S23CellEvolver();
			Cell evolved = cellEvolver.Evolve(Cell.Alive, GetNeighbors(4));
			Assert.IsFalse(evolved.IsAlive());
		}

		[Test]
		public void When_a_living_cell_with_5_living_neighbors_evolves_the_result_is_dead()
		{
			B3S23CellEvolver cellEvolver = new B3S23CellEvolver();
			Cell evolved = cellEvolver.Evolve(Cell.Alive, GetNeighbors(5));
			Assert.IsFalse(evolved.IsAlive());
		}

		[Test]
		public void When_a_living_cell_with_6_living_neighbors_evolves_the_result_is_dead()
		{
			B3S23CellEvolver cellEvolver = new B3S23CellEvolver();
			Cell evolved = cellEvolver.Evolve(Cell.Alive, GetNeighbors(6));
			Assert.IsFalse(evolved.IsAlive());
		}

		[Test]
		public void When_a_living_cell_with_7_living_neighbors_evolves_the_result_is_dead()
		{
			B3S23CellEvolver cellEvolver = new B3S23CellEvolver();
			Cell evolved = cellEvolver.Evolve(Cell.Alive, GetNeighbors(7));
			Assert.IsFalse(evolved.IsAlive());
		}

		[Test]
		public void When_a_living_cell_with_8_living_neighbors_evolves_the_result_is_dead()
		{
			B3S23CellEvolver cellEvolver = new B3S23CellEvolver();
			Cell evolved = cellEvolver.Evolve(Cell.Alive, GetNeighbors(8));
			Assert.IsFalse(evolved.IsAlive());
		}

		private static Cell[] GetNeighbors(int living)
		{
			return GetNeighbors(living, DefaultNeighbors - living);
		}

		private static Cell[] GetNeighbors(int living, int dead)
		{
			List<Cell> neighbors = new List<Cell>();
			for (int i = 0; i < living; i++)
			{
				neighbors.Add(Cell.Alive);
			}
			for (int i = 0; i < dead; i++)
			{
				neighbors.Add(Cell.Dead);
			}
			return neighbors.ToArray();
		}
	}
}