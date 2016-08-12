using System.Windows.Input;
using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;

namespace Fragments.Core.ViewModels
{
	public class SettingsViewModel
	: MvxViewModel
	{
		private IUserDialogs _userDialogs;

		public SettingsViewModel(IUserDialogs userDialogs)
		{
			_userDialogs = userDialogs;
		}

		public ICommand ShowAlertCommand
		{
			get { return new MvxCommand(() => _userDialogs.Alert("ALEЯT!")); }
		}
	}
}