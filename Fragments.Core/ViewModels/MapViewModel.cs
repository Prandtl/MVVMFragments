using System;
using System.Collections.Generic;
using System.Windows.Input;
using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;

namespace Fragments.Core.ViewModels
{
	class MapViewModel:MvxViewModel
	{
		private IUserDialogs _userDialogs;

		public MapViewModel(IUserDialogs userDialogs)
		{
			_userDialogs = userDialogs;
		}
		public List<Tuple<double, double>> Coordinates => new List<Tuple<double, double>>
		{
			Tuple.Create(1d,1d),
			Tuple.Create(2d,7d),
			Tuple.Create(3d,1d),
			Tuple.Create(5d,4d),
		};

		public ICommand ShowAlertCommand
		{
			get
			{
				return new MvxCommand(()=>_userDialogs.Alert("this works too"));
			}
		}
	}
}
