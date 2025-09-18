using Code.Infrastructure.Installers;
using Code.Meta.Ui.Windows;
using Code.Meta.Ui.Windows.Behaviours;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.StaticData
{
	public interface IStaticDataService
	{
		UniTask LoadAll();
		WindowConfig GetWindowConfig(WindowId id);
		LevelConfig GetLevelConfig(LevelTypeId typeId);
		HeroConfig GetHeroConfig();
	}
}