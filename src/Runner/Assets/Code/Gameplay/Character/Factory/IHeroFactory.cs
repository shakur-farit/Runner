using Assets.Code.Gameplay.Character.Behaviours;
using UnityEngine;

namespace Assets.Code.Gameplay.Character.Factory
{
	public interface IHeroFactory
	{
		Hero CreateHero(Vector3 at, float roadWidth);
	}
}