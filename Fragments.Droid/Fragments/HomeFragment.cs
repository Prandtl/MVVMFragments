using Android.Runtime;
using Fragments.Core.ViewModels;
using MvvmCross.Droid.Shared.Attributes;

namespace Fragments.Droid.Fragments
{
	[MvxFragment(typeof(MainViewModel), Resource.Id.content_frame, true)]
	[Register("fragments.droid.fragments.HomeFragment")]
	public class HomeFragment : BaseFragment<HomeViewModel>
	{
		protected override int FragmentId => Resource.Layout.fragment_home;
	}
}