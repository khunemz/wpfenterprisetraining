using System;
using System.Threading.Tasks;
using System.Windows.Input;
using FriendOrganize.Model;
using FriendOrganize.UI.Data;
using FriendOrganize.UI.Event;
using FriendOrganize.UI.Wrapper;
using Prism.Commands;
using Prism.Events;

namespace FriendOrganize.UI.ViewModels
{
	public interface IFriendDetailViewModel
	{
		Task LoadDataAsync(int friendId);
	}

	internal class FriendDetailViewModel : ViewModelBase, IFriendDetailViewModel
	{
		private readonly IFriendDataService _dataService;
		private readonly IEventAggregator _evenAggregator;
		private FriendWrapper Friend;


		public FriendDetailViewModel(IFriendDataService dataService, IEventAggregator eventAggregator)
		{
			_dataService = dataService;
			_evenAggregator = eventAggregator;
			_evenAggregator.GetEvent<OpenFriendDetailViewEvent>().Subscribe(OnOpenFriendDetailView);


			SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
		}

		public ICommand SaveCommand { get; set; }

		public async Task LoadDataAsync(int friendId)
		{
			var friend = await _dataService.GetByIdAsync(friendId);
			Friend = new FriendWrapper(friend);
		}

		private async void OnSaveExecute()
		{
			await _dataService.SaveAsync(Friend.Model);
			_evenAggregator.GetEvent<AfterFriendSaveEvent>().Publish(
				new AfterFriendSaveEventArg
				{
					Id = Friend.Id,
					DisplayMember = string.Format("{0} {1}", Friend.FirstName, Friend.LastName)
				});
		}

		private bool OnSaveCanExecute()
		{
			throw new NotImplementedException();
		}

		private async void OnOpenFriendDetailView(int friendId)
		{
			await _dataService.GetByIdAsync(friendId);
		}
	}
}