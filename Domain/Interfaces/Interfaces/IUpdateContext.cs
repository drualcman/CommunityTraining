using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityTraining.Domain.Common.Interfaces
{
    public interface IUpdateContext<TEntity>
    {
        Task Update(TEntity entity);
    }
}
