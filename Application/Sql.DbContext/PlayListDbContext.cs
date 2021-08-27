using CommunityTraining.Domain.Entities;
using CommunityTraining.Domain.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityTraining.Applicatoin.SqlEF
{
    public  class PlayListDbContext : DbContext
    {
        public DbSet<PlayList> PlayLists { get; set; }

        public PlayListDbContext(DbContextOptions<PlayListDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //invoice OnModelCreating from the base class
            base.OnModelCreating(modelBuilder);
        }
    }
}
