namespace GameOfLife.Evolvers
{
	public interface IWorldEvolver
	{
		World Evolve(World world);
	}
}