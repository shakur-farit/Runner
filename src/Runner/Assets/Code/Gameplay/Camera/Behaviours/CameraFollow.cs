using Assets.Code.Gameplay.Camera.Service;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Camera.Behaviours
{
	public class CameraFollow : MonoBehaviour
	{
		private const float Offset = 10f;

		private ICameraProvider _cameraProvider;

		[Inject]
		public void Constructor(ICameraProvider cameraProvider) => 
			_cameraProvider = cameraProvider;

		private void Update() => 
			Follow();

		private void Follow()
		{
			if(_cameraProvider.FollowTarget == null)
				return;

			transform.position = new(
				transform.position.x, 
				transform.position.y,
				_cameraProvider.FollowTarget.position.z - Offset);
		}
	}
}