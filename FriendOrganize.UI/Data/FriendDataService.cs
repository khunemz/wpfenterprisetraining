using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendOrganize.DataAccess;
using FriendOrganize.Model;

namespace FriendOrganize.UI.Data
{
	class FriendDataService : IFriendDataService
	{
        private Func<FriendOrganizeDbContext> _ctx;

        public FriendDataService(Func<FriendOrganizeDbContext> contextCreator)
        {
            _ctx = contextCreator;
        }
		public IEnumerable<Friend> GetAll()
		{
            // return new List<Friend>()
            //{
            //	new Friend() {FirstName = "chutipong", LastName = "roobklom", Email = "khunemz@gmail.com"} , 
            //	new Friend() {FirstName = "anongnat", LastName = "roobklom", Email = "ak@gmail.com"} , 
            //	new Friend() {FirstName = "bleck", LastName = "mahone", Email = "bmh@gmail.com"} , 
            //	new Friend() {FirstName = "michaele", LastName = "scofield", Email = "mks@gmail.com"} , 
            //	new Friend() {FirstName = "test", LastName = "test", Email = "test@gmail.com"}
            //};



            using (var ctx = _ctx())
            {
                return ctx.Friends.ToList();
            }
           
        }
	}
}
