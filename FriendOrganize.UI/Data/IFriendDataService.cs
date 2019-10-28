using System.Collections.Generic;
using FriendOrganize.Model;

namespace FriendOrganize.UI.Data
{
	public interface IFriendDataService
	{
		IEnumerable<Friend> GetAll();
	}
}