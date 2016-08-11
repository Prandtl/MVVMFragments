using Android.Content.Res;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Fragments.Droid.Activities;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace Fragments.Droid.Fragments
{
	public abstract class BaseFragment : MvxFragment
	{
		public MvxCachingFragmentCompatActivity ParentActivity => (MvxCachingFragmentCompatActivity)Activity;

		protected BaseFragment()
		{
			RetainInstance = true;
		}
		protected abstract int FragmentId { get; }

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var ignore = base.OnCreateView(inflater, container, savedInstanceState);
			var view = this.BindingInflate(FragmentId, null);
			_toolbar = view.FindViewById<Toolbar>(Resource.Id.toolbar);
			if (_toolbar != null)
			{
				ParentActivity.SetSupportActionBar(_toolbar);
				ParentActivity.SupportActionBar.SetDisplayHomeAsUpEnabled(true);

				_drawerToggle = new MvxActionBarDrawerToggle(
					Activity,                               // host Activity
					(ParentActivity as INavigationActivity)?.DrawerLayout,  // DrawerLayout object
					_toolbar,                               // nav drawer icon to replace 'Up' caret
					Resource.String.drawer_open,            // "open drawer" description
					Resource.String.drawer_close            // "close drawer" description
				);
				_drawerToggle.DrawerOpened += (sender, e) => ((MainActivity)Activity).HideSoftKeyboard();
				(ParentActivity as INavigationActivity)?.DrawerLayout.AddDrawerListener(_drawerToggle);
			}
			return view;
		}

		public override void OnConfigurationChanged(Configuration newConfig)
		{
			base.OnConfigurationChanged(newConfig);
			if (_toolbar != null)
				_drawerToggle.OnConfigurationChanged(newConfig);
		}

		public override void OnActivityCreated(Bundle savedInstanceState)
		{
			base.OnActivityCreated(savedInstanceState);
			if (_toolbar != null)
				_drawerToggle.SyncState();
		}

		private Toolbar _toolbar;
		private MvxActionBarDrawerToggle _drawerToggle;
	}

	public abstract class BaseFragment<TViewModel> : BaseFragment where TViewModel : class, IMvxViewModel
	{
		public new TViewModel ViewModel
		{
			get { return (TViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}
	}
}