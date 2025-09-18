namespace Code.Meta.Ui.Windows.Factory
{
	public interface IWindowService
	{
		void Open(WindowId windowId);
		void Close(WindowId windowId);
	}
}