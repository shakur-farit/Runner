using Code.Meta.Ui.Windows.Behaviours;
using UnityEngine;

namespace Code.Meta.Ui.Windows.Factory
{
	public interface IWindowFactory
	{
		void SetUIRoot(RectTransform uiRoot);
		BaseWindow CreateWindow(WindowId windowId);
	}
}