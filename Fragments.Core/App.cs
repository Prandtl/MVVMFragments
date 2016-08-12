using Acr.UserDialogs;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace Fragments.Core
{
	public class App : MvvmCross.Core.ViewModels.MvxApplication
	{
		public override void Initialize()
		{
			CreatableTypes()
				.EndingWith("Service")
				.AsInterfaces()
				.RegisterAsLazySingleton();

			Mvx.RegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);

			RegisterAppStart(new AppStart());
		}
	}
}
