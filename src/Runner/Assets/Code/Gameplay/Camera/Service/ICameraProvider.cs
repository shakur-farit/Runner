using UnityEngine;

namespace Code.Infrastructure.Installers
{
	public interface ICameraProvider
	{
		Camera MainCamera { get; }
		Transform FollowTarget { get; }
		void SetMainCamera(Camera mainCamera);
		void SetFollowTarget(Transform followTarget);
	}
}