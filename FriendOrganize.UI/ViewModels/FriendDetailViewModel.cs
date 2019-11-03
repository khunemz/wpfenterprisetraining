using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendOrganize.Model;
using FriendOrganize.UI.Data;

namespace FriendOrganize.UI.ViewModels
{
	public interface IFriendDetailViewModel
	{
		Task LoadDataAsync(int friendId);
	}

	class FriendDetailViewModel : ViewModelBase, IFriendDetailViewModel
	{
		private IFriendDataService _dataService;
		private Friend _friend;


		public FriendDetailViewModel(IFriendDataService dataService)
		{
			_dataService = dataService;
		}


		public async Task LoadDataAsync(int friendId)
		{
			Friend = await _dataService.GetByIdAsync(friendId);
		}


		public Friend Friend
		{
			get { return _friend; }
			private set
			{
				_friend = value;
				OnPropertyChanged();
			}
		}
	}
}