using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FriendOrganize.Model;
using FriendOrganize.UI.Data;

namespace FriendOrganize.UI.ViewModels
{
    public interface INavigationViewModel
    {
        Task LoadAsync();
    }

    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private ILookUpDataService _friendLookupService;

        public NavigationViewModel(ILookUpDataService friendLookupDataService)
        {
            _friendLookupService = friendLookupDataService;
            Friends = new ObservableCollection<LookupItem>();
        }

        public ObservableCollection<LookupItem> Friends { get; set; }


        public async Task LoadAsync()
        {
            var lookup = await _friendLookupService.GetFriendLookupAsync();

            foreach (var item in lookup)
            {
                Friends.Add(item);
            }
        }
    }
}