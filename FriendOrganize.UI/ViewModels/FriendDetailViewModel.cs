using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FriendOrganize.Model;
using FriendOrganize.UI.Data;
using FriendOrganize.UI.Event;
using Prism.Commands;
using Prism.Events;

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
		private IEventAggregator _evenAggregator;


		public FriendDetailViewModel(IFriendDataService dataService, IEventAggregator eventAggregator)
		{
			_dataService = dataService;
			_evenAggregator = eventAggregator;
			_evenAggregator.GetEvent<OpenFriendDetailViewEvent>().Subscribe(OnOpenFriendDetailView);


			SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
		}

		private async void OnSaveExecute()
		{
			await _dataService.SaveAsync(_friend);
		}

		private bool OnSaveCanExecute()
		{
			throw new NotImplementedException();
		}

		private async void OnOpenFriendDetailView(int friendId)
		{
			await _dataService.GetByIdAsync(friendId);
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

		public ICommand SaveCommand { get; set; }
	}
}