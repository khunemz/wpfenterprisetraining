using System.Collections.Generic;
using System.Threading.Tasks;
using FriendOrganize.Model;

namespace FriendOrganize.UI.Data
{
    public interface ILookUpDataService
    {
        Task<IEnumerable<LookupItem>> GetFriendLookupAsync();
    }
}