using UnityEngine;

namespace Code.Infrastructure.Installers
{
	public class Hero : MonoBehaviour
	{
		public void SetStartPosition(Vector3 startPosition) => 
			gameObject.transform.position = startPosition;
	}
}