using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.Infrastructure.Installers
{
	public class StandaloneInputService : IInputService
	{
		private Camera _mainCamera;
		private Vector3 _screenPosition;

		public Camera CameraMain
		{
			get
			{
				if (_mainCamera == null && Camera.main != null)
					_mainCamera = Camera.main;

				return _mainCamera;
			}
		}

		public Vector2 GetScreenMousePosition() =>
			CameraMain ? Input.mousePosition : new Vector2();

		public Vector2 GetWorldMousePosition()
		{
			if (CameraMain == null)
				return Vector2.zero;

			_screenPosition.x = Input.mousePosition.x;
			_screenPosition.y = Input.mousePosition.y;
			return CameraMain.ScreenToWorldPoint(_screenPosition);
		}

		public bool HasAxisInput() => GetHorizontalAxis() != 0 || GetVerticalAxis() != 0;

		public float GetVerticalAxis() => Input.GetAxisRaw("Vertical");
		public float GetHorizontalAxis() => Input.GetAxisRaw("Horizontal");


		public bool GetLeftMouseButton() =>
			Input.GetMouseButton(0) /*&& !EventSystem.current.IsPointerOverGameObject()*/;

		public bool GetLeftMouseButtonDown() =>
			Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject();

		public bool GetLeftMouseButtonUp() =>
      Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject();

    public bool GetJumpButton() =>
      Input.GetKey(KeyCode.Space);

    public bool GetJumpButtonDown() =>
      Input.GetKeyDown(KeyCode.Space);

    public bool GetJumpButtonUp() =>
      Input.GetKeyUp(KeyCode.Space);
  }
}