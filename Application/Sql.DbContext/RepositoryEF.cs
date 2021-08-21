using CommunityTraining.Entities;
using CommunityTraining.Interfaces.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityTraining.Sql.EF
{
    public class RepositoryEF<TEntity>  : 
            IPlayListAddContext<TEntity> , 
            IPlayListUpdateContext<TEntity>, 
            IPlayListDeleteContext<TEntity>,
            IPlayListGetAllContext<TEntity>, 
            IPlayListGetContext<TEntity> 
        where TEntity : class
    {
        private readonly PlayListDbContext Context;
        public RepositoryEF(PlayListDbContext context)
        {
            Context = context;
        }

        public async Task Add(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            TEntity data = await Context.Set<TEntity>().FindAsync(id);
            Context.Set<TEntity>().Remove(data);
            await Context.SaveChangesAsync();
        }

        public async Task<TEntity> Get(int id) => 
            await Context.Set<TEntity>().FindAsync(id);

        public async Task<IEnumerable<TEntity>> GetAll() =>
            await Context.Set<TEntity>().Select(a=>a).ToListAsync();

        public async Task Update(TEntity data)
        {
            Context.Attach(data);
            Context.Entry(data).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }
    }
}
