using System.Collections.Generic;
using System.Threading.Tasks;
using FriendOrganize.Model;

namespace FriendOrganize.UI.Data
{
	public interface IFriendDataService
	{
		Task<List<Friend>> GetAllAsync();
		Task<Friend> GetByIdAsync(int friendId);
	}
}