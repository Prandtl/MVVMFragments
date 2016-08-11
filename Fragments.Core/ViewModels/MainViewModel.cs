using MvvmCross.Core.ViewModels;

namespace Fragments.Core.ViewModels
{
	public class MainViewModel
		: MvxViewModel
	{
		public MainViewModel()
		{
		}

		public void ShowMenu()
		{
			ShowViewModel<MenuViewModel>();
		}
	}
}