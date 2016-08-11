using System;
using MvvmCross.Core.ViewModels;

namespace Fragments.Core.ViewModels
{
	public class MenuViewModel
	: MvxViewModel
	{
		public MenuViewModel()
		{
		}

		public void ShowViewModelAndroid(Type viewModel)
		{
			ShowViewModel(viewModel);
		}
	}
}