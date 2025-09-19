using System;
using UnityEngine;

namespace Code.Infrastructure.Installers
{
	public class Coin : MonoBehaviour
	{
		[SerializeField] private int _value = 0;

		public event Action Pickedup;

		public int Value => _value;

		public void CallPickedup() => 
			Pickedup?.Invoke();
	}
}