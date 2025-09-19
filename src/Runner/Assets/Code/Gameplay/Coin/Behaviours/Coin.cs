using UnityEngine;

namespace Code.Infrastructure.Installers
{
	public class Coin : MonoBehaviour
	{
		[SerializeField] private int _value = 0;

		public int Value => _value;
	}
}