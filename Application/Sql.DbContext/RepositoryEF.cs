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
            IAddContext<TEntity> , 
            IUpdateContext<TEntity>, 
            IDeleteContext<TEntity>,
            IGetAllContext<TEntity>, 
            IGetContext<TEntity> 
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

        public async Task Delete(string id)
        {
            TEntity data = await Context.Set<TEntity>().FindAsync(id);
            Context.Set<TEntity>().Remove(data);
            await Context.SaveChangesAsync();
        }

        public async Task<TEntity> Get(string id) => 
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
