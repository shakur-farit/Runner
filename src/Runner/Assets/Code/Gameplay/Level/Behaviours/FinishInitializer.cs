using UnityEngine;

namespace Code.Infrastructure.Installers
{
	public class FinishInitializer : MonoBehaviour
	{
		[SerializeField] private Environment _environment;
		[SerializeField] private Transform _finish;

		private void Start()
		{
			_finish.position = new(
				_finish.position.x, _finish.position.y, _environment.FinishZPosition);
		}
	}
}