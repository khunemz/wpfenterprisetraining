using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendOrganize.Model;

namespace FriendOrganize.UI.Data
{
	class FriendDataService : IFriendDataService
	{
		public IEnumerable<Friend> GetAll()
		{
			 return new List<Friend>()
			{
				new Friend() {FirstName = "chutipong", LastName = "roobklom", Email = "khunemz@gmail.com"} , 
				new Friend() {FirstName = "anongnat", LastName = "roobklom", Email = "ak@gmail.com"} , 
				new Friend() {FirstName = "bleck", LastName = "mahone", Email = "bmh@gmail.com"} , 
				new Friend() {FirstName = "michaele", LastName = "scofield", Email = "mks@gmail.com"} , 
				new Friend() {FirstName = "test", LastName = "test", Email = "test@gmail.com"}
			};
		}
	}
}
