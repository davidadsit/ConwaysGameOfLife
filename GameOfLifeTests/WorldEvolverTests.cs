using System;
using System.Collections.Generic;
using GameOfLife;
using GameOfLife.Evolvers;
using GameOfLife.Evolvers.Implementations;
using Moq;
using NUnit.Framework;

namespace GameOfLifeTests
{
	[TestFixture]
	public class WorldEvolverTests
	{
		private Mock<ICellEvolver> _cellEvolverMock;
		private WorldEvolver _worldEvolver;

		[SetUp]
		public void SetUp()
		{
			_cellEvolverMock = new Mock<ICellEvolver>();
			_worldEvolver = new WorldEvolver(_cellEvolverMock.Object);
		}

		[TearDown]
		public void TearDown()
		{
			_cellEvolverMock.Verify();
		}

		[Test]
		public void Evolve_calls_ICellEvolver_for_each_cell()
		{
			World world = new World(3, 3);
			int[] callbackCount = new[] {0};
			_cellEvolverMock
				.Setup(x => x.Evolve(It.IsAny<Cell>(), It.IsAny<Cell[]>()))
				.Returns(Cell.Alive)
				.Callback(() => callbackCount[0]++)
				.Verifiable();
			_worldEvolver.Evolve(world);
			Assert.AreEqual(9, callbackCount[0]);
		}

		[Test]
		public void Evolve_generates_a_new_world_with_the_same_dimensions()
		{
			World world = new World(4, 7);
			World evolved = _worldEvolver.Evolve(world);
			Assert.AreNotSame(world, evolved);
			Assert.AreEqual(world.Height, evolved.Height);
			Assert.AreEqual(world.Width, evolved.Width);
		}

		[Test]
		public void Evolve_initialize_new_world_with_results_of_cell_evolver()
		{
			World world = new World(3, 3);
			_cellEvolverMock
				.Setup(x => x.Evolve(It.IsAny<DeadCell>(), It.IsAny<Cell[]>()))
				.Returns(Cell.Alive);
			World evolvedWorld = _worldEvolver.Evolve(world);
			foreach (Coordinate coordinate in evolvedWorld)
			{
				Assert.IsTrue(evolvedWorld.GetCell(coordinate).IsAlive());
			}
		}

		[Test]
		public void GetNeighbors_returns_3_neighbors_for_corner_cells()
		{
			World world = new World(5, 5);
			Coordinate coordinate = world.GetCoordinate(0, 0);
			List<Cell> cells = world.GetNeighbors(coordinate);
			Assert.AreEqual(3, cells.Count);
		}

		[Test]
		public void GetNeighbors_returns_5_neighbors_for_corner_cells()
		{
			World world = new World(5, 5);
			Coordinate coordinate = world.GetCoordinate(2, 0);
			List<Cell> cells = world.GetNeighbors(coordinate);
			Assert.AreEqual(5, cells.Count);
		}

		[Test]
		public void GetNeighbors_returns_8_neighbors_for_non_edge_cells()
		{
			World world = new World(5, 5);
			Coordinate coordinate = world.GetCoordinate(2, 2);
			List<Cell> cells = world.GetNeighbors(coordinate);
			Assert.AreEqual(8, cells.Count);
		}

		[Test]
		public void Blinker_test()
		{
			WorldEvolver worldEvolver = new WorldEvolver(new CellEvolver());
			World world = new World(3, 3);
			world.SetCell(world.GetCoordinate(1, 0), Cell.Alive);
			world.SetCell(world.GetCoordinate(1, 1), Cell.Alive);
			world.SetCell(world.GetCoordinate(1, 2), Cell.Alive);
			Console.Out.WriteLine(world);
			Console.Out.WriteLine("");
			world = worldEvolver.Evolve(world);
			Console.Out.WriteLine(world);
			Console.Out.WriteLine("");
			world = worldEvolver.Evolve(world);
			Console.Out.WriteLine(world);
		}

		[Test]
		public void Beacon_test()
		{
			WorldEvolver worldEvolver = new WorldEvolver(new CellEvolver());
			World world = new World(6, 6);
			world.SetCell(world.GetCoordinate(1, 1), Cell.Alive);
			world.SetCell(world.GetCoordinate(1, 2), Cell.Alive);
			world.SetCell(world.GetCoordinate(2, 1), Cell.Alive);
			world.SetCell(world.GetCoordinate(4, 3), Cell.Alive);
			world.SetCell(world.GetCoordinate(4, 4), Cell.Alive);
			world.SetCell(world.GetCoordinate(3, 4), Cell.Alive);
			Console.Out.WriteLine(world);
			Console.Out.WriteLine("");
			world = worldEvolver.Evolve(world);
			Console.Out.WriteLine(world);
			Console.Out.WriteLine("");
			world = worldEvolver.Evolve(world);
			Console.Out.WriteLine(world);
		}

		[Test]
		public void WorldEvolver_is_an_IWorldEvolver()
		{
			Assert.IsInstanceOf(typeof (IWorldEvolver), _worldEvolver);
		}
	}
}