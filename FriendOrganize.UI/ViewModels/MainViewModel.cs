using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FriendOrganize.Model;
using FriendOrganize.UI.Data;

namespace FriendOrganize.UI.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		private readonly IFriendDataService _friendDataService;

		private Friend _selectedFriend;

		public MainViewModel(IFriendDataService friendDataService)
		{
			Friends = new ObservableCollection<Friend>();

			_friendDataService = friendDataService;
		}

		public ObservableCollection<Friend> Friends { get; set; }


		public Friend SelectedFriend
		{
			get { return _selectedFriend; }
			set
			{
				_selectedFriend = value;
				OnPropertyChanged(nameof(SelectedFriend));
			}
		}

		public async Task LoadAsync()
		{
			var friends = await _friendDataService.GetAllAsync();

			Friends.Clear();
			foreach (var friend in friends) Friends.Add(friend);
		}
	}
}