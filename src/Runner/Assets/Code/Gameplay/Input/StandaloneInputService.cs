using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Code.Gameplay.Input
{
	public class StandaloneInputService : IInputService
	{
		private UnityEngine.Camera _mainCamera;
		private Vector3 _screenPosition;

		public UnityEngine.Camera CameraMain
		{
			get
			{
				if (_mainCamera == null && UnityEngine.Camera.main != null)
					_mainCamera = UnityEngine.Camera.main;

				return _mainCamera;
			}
		}

		public Vector2 GetScreenMousePosition() =>
			CameraMain ? UnityEngine.Input.mousePosition : new Vector2();

		public Vector2 GetWorldMousePosition()
		{
			if (CameraMain == null)
				return Vector2.zero;

			_screenPosition.x = UnityEngine.Input.mousePosition.x;
			_screenPosition.y = UnityEngine.Input.mousePosition.y;
			return CameraMain.ScreenToWorldPoint(_screenPosition);
		}

		public bool HasAxisInput() => GetHorizontalAxis() != 0 || GetVerticalAxis() != 0;

		public float GetVerticalAxis() => UnityEngine.Input.GetAxisRaw("Vertical");
		public float GetHorizontalAxis() => UnityEngine.Input.GetAxisRaw("Horizontal");


		public bool GetLeftMouseButton() =>
			UnityEngine.Input.GetMouseButton(0) /*&& !EventSystem.current.IsPointerOverGameObject()*/;

		public bool GetLeftMouseButtonDown() =>
			UnityEngine.Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject();

		public bool GetLeftMouseButtonUp() =>
      UnityEngine.Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject();

    public bool GetJumpButton() =>
      UnityEngine.Input.GetKey(KeyCode.Space);

    public bool GetJumpButtonDown() =>
      UnityEngine.Input.GetKeyDown(KeyCode.Space);

    public bool GetJumpButtonUp() =>
      UnityEngine.Input.GetKeyUp(KeyCode.Space);
  }
}