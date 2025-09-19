using System;
using UnityEngine;

namespace Code.Infrastructure.Installers
{
	public class Environment : MonoBehaviour
	{
		public Vector3 StartPosition { get; private set; }
		public float RoadLength { get; private set; }
		public float RoadWidth { get; private set; }
		public float FinishZPosition { get; private set; }

		public void Setup(Vector3 startPosition, float length, float width, float finishXPosition)
		{
			StartPosition = startPosition;
			RoadLength = length;
			RoadWidth = width;
			FinishZPosition = finishXPosition;
		}
	}
}