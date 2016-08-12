using System;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Views;
using Fragments.Core.ViewModels;
using Fragments.Droid.Activities;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V4;

namespace Fragments.Droid.Fragments
{
	[MvxFragment(typeof(MainViewModel), Resource.Id.navigation_frame)]
	[Register("fragments.droid.fragments.MenuFragment")]
	public class MenuFragment : MvxFragment<MenuViewModel>, NavigationView.IOnNavigationItemSelectedListener
	{
		private NavigationView _navigationView;
		private IMenuItem _previousMenuItem;

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var ignore = base.OnCreateView(inflater, container, savedInstanceState);

			var view = this.BindingInflate(Resource.Layout.fragment_menu, null);

			_navigationView = view.FindViewById<NavigationView>(Resource.Id.navigation_view);
			_navigationView.SetNavigationItemSelectedListener(this);
			_navigationView.Menu.FindItem(Resource.Id.nav_home).SetChecked(true);

			return view;
		}

		public bool OnNavigationItemSelected(IMenuItem item)
		{
			item.SetCheckable(true);
			item.SetChecked(true);
			_previousMenuItem?.SetChecked(false);
			_previousMenuItem = item;

			Navigate(item.ItemId);

			return true;
		}

		private async Task Navigate(int itemId)
		{
			((MainActivity)Activity).DrawerLayout.CloseDrawers();
			await Task.Delay(TimeSpan.FromMilliseconds(250));

			switch (itemId)
			{
				case Resource.Id.nav_home:
					ViewModel.ShowViewModelAndroid(typeof(HomeViewModel));
					break;
				case Resource.Id.nav_settings:
					ViewModel.ShowViewModelAndroid(typeof(SettingsViewModel));
					break;
			}
		}
	}
}