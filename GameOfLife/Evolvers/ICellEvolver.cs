namespace GameOfLife.Evolvers
{
	public interface ICellEvolver
	{
		Cell Evolve(Cell cell, params Cell[] neighbors);
	}
}