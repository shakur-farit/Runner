using UnityEngine;

namespace Code.Infrastructure.Installers
{
	public interface IHeroFactory
	{
		Hero CreateHero(Vector3 at, float roadWidth);
	}
}