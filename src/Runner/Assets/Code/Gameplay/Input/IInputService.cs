using UnityEngine;

namespace Code.Infrastructure.Installers
{
	public interface IInputService
	{
		float GetVerticalAxis();
		float GetHorizontalAxis();
		bool HasAxisInput();

		bool GetLeftMouseButton();
		bool GetLeftMouseButtonDown();
		Vector2 GetScreenMousePosition();
		Vector2 GetWorldMousePosition();
		bool GetLeftMouseButtonUp();
    bool GetJumpButton();
    bool GetJumpButtonDown();
    bool GetJumpButtonUp();
  }
}