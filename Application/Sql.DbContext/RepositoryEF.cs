using CommunityTraining.Entities;
using CommunityTraining.Interfaces.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityTraining.Sql.EF
{
    public class RepositoryEF<TEntity>  : 
            IPlayListAddContext<TEntity> , 
            IPlayListUpdateContext<TEntity>, 
            IPlayListDeleteContext,
            IPlayListGetAllContext<TEntity>, 
            IPlayListGetContext<TEntity> 
        where TEntity : class
    {
        private readonly PlayListDbContext Context;
        public RepositoryEF(PlayListDbContext context)
        {
            Context = context;
        }

        public Task<int> Add(TEntity entity)
        {
            return Task.FromResult(0);
        }

        public Task<bool> Delete(int id)
        {
            return Task.FromResult(false);
        }

        public Task<TEntity> Get(int id)
        {
            TEntity data = default;
            return Task.FromResult(data);
        }

        public Task<IEnumerable<TEntity>> GetAll()
        {
            List<TEntity> result = new List<TEntity>();
            return Task.FromResult(result.AsEnumerable());
        }

        public Task<bool> Update(TEntity entity)
        {
            return Task.FromResult(false);
        }
    }
}
