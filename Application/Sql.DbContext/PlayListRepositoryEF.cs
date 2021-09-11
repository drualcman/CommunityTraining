using CommunityTraining.Domain.Entities;
using CommunityTraining.Domain.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityTraining.Applicatoin.SqlEF
{
    public class PlayListRepositoryEF  : 
            IAddContext<PlayList> , 
            IUpdateContext<PlayList>, 
            IDeleteContext<PlayList>,
            IGetAllContext<PlayList>, 
            IGetContext<PlayList> 
    {
        private readonly PlayListDbContext Context;
        public PlayListRepositoryEF(PlayListDbContext context)
        {
            Context = context;
        }

        public async Task Add(PlayList entity)
        {
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            PlayList data = await Context.Set<PlayList>().FindAsync(id);
            Context.Set<PlayList>().Remove(data);
            await Context.SaveChangesAsync();
        }

        public async Task<PlayList> Get(string id) => 
            await Context.Set<PlayList>().FindAsync(id);

        public async Task<IEnumerable<PlayList>> GetAll() =>
            await Context.Set<PlayList>().Select(a=>a).ToListAsync();

        public async Task Update(PlayList data)
        {
            Context.Attach(data);
            Context.Entry(data).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }
    }
}
