﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FriendOrganize.Model;
using FriendOrganize.UI.Data;
using FriendOrganize.UI.Event;
using Prism.Events;

namespace FriendOrganize.UI.ViewModels
{
	public interface INavigationViewModel
	{
		Task LoadAsync();
	}

	public class NavigationViewModel : ViewModelBase, INavigationViewModel
	{
		private IFriendLookUpDataService _friendLookupService;
		private IEventAggregator _eventAgg;

		public NavigationViewModel(IFriendLookUpDataService friendLookupDataService , 
			IEventAggregator eventAggregator)
		{
			_friendLookupService = friendLookupDataService;
			_eventAgg = eventAggregator;
			Friends = new ObservableCollection<LookupItem>();
		}

		public async Task LoadAsync()
		{
			var lookup = await _friendLookupService.GetFriendLookupAsync();
			Friends.Clear();
			foreach (var item in lookup)
			{
				Friends.Add(item);
			}
		}

		private LookupItem _selectedFriend;

		public ObservableCollection<LookupItem> Friends { get; set; }

		public LookupItem SelectedFriend
		{
			get { return _selectedFriend; }
			set
			{
				_selectedFriend = value; OnPropertyChanged();

				if (_selectedFriend != null)
				{
					_eventAgg.GetEvent<OpenFriendDetailViewEvent>().Publish(_selectedFriend.Id);
				}
			}
		}
	}
}