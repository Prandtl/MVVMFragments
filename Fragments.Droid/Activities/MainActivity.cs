﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Views.InputMethods;
using Fragments.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace Fragments.Droid.Activities
{
	[Activity(Label = "Fragments",
		LaunchMode = LaunchMode.SingleTop,
		Name = "fragments.droid.activities.MainActivity"
		)]
	class MainActivity : MvxCachingFragmentCompatActivity<MainViewModel>, INavigationActivity
	{
		public DrawerLayout DrawerLayout { get; set; }

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.activity_main);

			DrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

			if (bundle == null)
				ViewModel.ShowMenu();
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
				case Android.Resource.Id.Home:
					DrawerLayout.OpenDrawer(GravityCompat.Start);
					return true;
			}
			return base.OnOptionsItemSelected(item);
		}

		public override void OnBackPressed()
		{
			if (DrawerLayout != null && DrawerLayout.IsDrawerOpen(GravityCompat.Start))
				DrawerLayout.CloseDrawers();
			else
				base.OnBackPressed();
		}

		public void HideSoftKeyboard()
		{
			if (CurrentFocus == null) return;

			var inputMethodManager = (InputMethodManager)GetSystemService(InputMethodService);
			inputMethodManager.HideSoftInputFromWindow(CurrentFocus.WindowToken, 0);

			CurrentFocus.ClearFocus();
		}
	}
}