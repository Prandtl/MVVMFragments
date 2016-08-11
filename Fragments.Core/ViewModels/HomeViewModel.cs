using MvvmCross.Core.ViewModels;

namespace Fragments.Core.ViewModels
{
	public class HomeViewModel
		: MvxViewModel
	{
		public HomeViewModel()
		{
		}

		private MvxCommand closeViewCommand;

		public IMvxCommand CloseViewCommand
		{
			get
			{
				return closeViewCommand = closeViewCommand ?? new MvxCommand(() => Close(this));
			}
		}
	}
}
