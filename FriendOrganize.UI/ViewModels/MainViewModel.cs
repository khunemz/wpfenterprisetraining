using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FriendOrganize.Model;

namespace FriendOrganize.UI.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		private INavigationViewModel _navViewModel;


		public MainViewModel(INavigationViewModel navViewModel )
		{
			_navViewModel = navViewModel;
		}


		public async Task LoadAsync()
		{
			await _navViewModel.LoadAsync();
		}
	}
}