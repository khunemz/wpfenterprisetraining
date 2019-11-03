using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendOrganize.DataAccess;
using FriendOrganize.Model;

namespace FriendOrganize.UI.Data
{
    public class LookUpDataService : IFriendLookUpDataService
    {
        private Func<FriendOrganizeDbContext> _ctx;

        public LookUpDataService(Func<FriendOrganizeDbContext> contextCreator)
        {
            _ctx = contextCreator;
        }

        public async Task<IEnumerable<LookupItem>> GetFriendLookupAsync()
        {
            using (var ctx = _ctx())
            {
               return  await ctx.Friends.AsNoTracking()
                    .Select(f => new LookupItem()
                    {
                        Id = f.Id, DisplayMember = f.FirstName + " " + f.LastName
                    }).ToListAsync();
            }
        }
    }
}
