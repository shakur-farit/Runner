using System;
using UnityEngine;
using Zenject.Asteroids;

namespace Code.Infrastructure.Installers
{
	public class CameraProvider : ICameraProvider
	{
		public Camera MainCamera { get; private set; }
		public Transform FollowTarget { get; private set; }

		public void SetMainCamera(Camera mainCamera) => 
			MainCamera = mainCamera;

		public void SetFollowTarget(Transform followTarget) => 
			FollowTarget = followTarget;
	}
}