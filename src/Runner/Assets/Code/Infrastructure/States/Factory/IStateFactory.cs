using Code.Infrastructure.States.Infrastructure;

namespace Code.Infrastructure.States.Factory
{
	public interface IStateFactory
	{
		T GetState<T>() where T : class, IExitableState;
	}
}