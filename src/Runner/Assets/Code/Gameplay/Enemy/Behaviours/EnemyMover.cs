using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Code.Gameplay.Enemy.Behaviours
{
	public class EnemyMover : MonoBehaviour
  {
    private const float MinMovementSpeed = 0.5f;

		[SerializeField] private Enemy _enemy;
		[SerializeField] private Transform _pointA;
		[SerializeField] private Transform _pointB; 
		[SerializeField] private Transform _body;

    private float _movementSpeed;

		private bool movingToB = true;

    private void Start() => 
      _movementSpeed = Random.Range(MinMovementSpeed, _enemy.MaxMovementSpeed);

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
				_movementSpeed * Time.deltaTime
			);

			if (Vector3.Distance(_body.transform.position, targetPoint.position) < 0.01f) 
				movingToB = !movingToB;
		}
	}
}