using UnityEngine;

namespace Code.Meta.Ui.Windows.Behaviours
{
	[CreateAssetMenu(menuName = "Runner/Window Config", fileName = "WindowConfig")]
	public class WindowConfig : ScriptableObject
	{
		public WindowId TypeId;
		public GameObject ViewPrefab;
	}
}