using UnityEngine;

namespace Code.Infrastructure.Installers
{
	public class Environment : MonoBehaviour
	{
		public Vector3 StartPosition { get; private set; }

		public void SetStartPosition(Vector3 startPosition) => 
			StartPosition = startPosition;
	}
}