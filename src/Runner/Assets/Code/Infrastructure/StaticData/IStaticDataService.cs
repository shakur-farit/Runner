using Assets.Code.Gameplay.Character.Config;
using Assets.Code.Gameplay.Enemy;
using Assets.Code.Gameplay.Enemy.Config;
using Assets.Code.Gameplay.Level;
using Assets.Code.Gameplay.Level.Config;
using Assets.Code.Gameplay.Loot;
using Assets.Code.Gameplay.Loot.Config;
using Assets.Code.Gameplay.SoundEffect;
using Assets.Code.Gameplay.SoundEffect.Config;
using Assets.Code.Meta.UI.Windows;
using Assets.Code.Meta.UI.Windows.Config;
using Cysharp.Threading.Tasks;

namespace Assets.Code.Infrastructure.StaticData
{
	public interface IStaticDataService
	{
		UniTask LoadAll();
		WindowConfig GetWindowConfig(WindowId id);
		LevelConfig GetLevelConfig(LevelTypeId typeId);
		HeroConfig GetHeroConfig();
    EnemyConfig GetEnemyConfig(EnemyTypeId typeId);
    LootConfig GetLootConfig(LootTypeId typeId);
    SoundEffectConfig GetSoundEffectConfig(SoundEffectTypeId typeId);
  }
}