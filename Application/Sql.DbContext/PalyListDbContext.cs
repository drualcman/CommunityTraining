using CommunityTraining.Entities;
using CommunityTraining.Interfaces.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityTraining.Sql.DbContext
{
    public class PalyListDbContext : IPlayListAddContext<PlayList>, IPlayListUpdateContext<PlayList>, IPlayListDeleteContext, 
                                     IPlayListGetAllContext<PlayList>, IPlayListGetContext<PlayList>
    {
        public Task<int> Add(PlayList entity)
        {
            return Task.FromResult(0);
        }

        public Task<bool> Delete(int id)
        {
            return Task.FromResult(false);
        }

        public Task<PlayList> Get(int id)
        {
            return Task.FromResult(new PlayList());
        }

        public Task<IEnumerable<PlayList>> GetAll()
        {
            List<PlayList> result = new List<PlayList>();
            return Task.FromResult(result.AsEnumerable());
        }

        public Task<bool> Update(PlayList entity)
        {
            return Task.FromResult(false);
        }
    }
}
