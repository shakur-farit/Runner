namespace Code.Infrastructure.Installers
{
	public interface ILevelFactory
	{
		Environment CreateLevel(LevelTypeId typeId);
	}
}