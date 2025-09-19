using Assets.Code.Gameplay.Level.Behaviours;

namespace Assets.Code.Gameplay.Level.Factory
{
	public interface ILevelFactory
	{
		Environment CreateLevel(LevelTypeId typeId);
	}
}