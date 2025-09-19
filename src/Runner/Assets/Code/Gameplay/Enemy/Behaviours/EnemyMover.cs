using UnityEngine;

namespace Code.Infrastructure.Installers
{
	public class EnemyMover : MonoBehaviour
	{
		[SerializeField] private Transform _pointA;
		[SerializeField] private Transform _pointB; 
		[SerializeField] private Transform _body; 
		[SerializeField] private float speed = 3f;

		private bool movingToB = true;

		private void Update() => 
			Move();

		private void Move()
		{
			if (_pointA == null || _pointB == null) 
				return;

			Transform targetPoint = movingToB ? _pointB : _pointA;

			_body.transform.position = Vector3.MoveTowards(
				_body.transform.position,
				targetPoint.position,
				speed * Time.deltaTime
			);

			if (Vector3.Distance(_body.transform.position, targetPoint.position) < 0.01f) 
				movingToB = !movingToB;
		}
	}
}