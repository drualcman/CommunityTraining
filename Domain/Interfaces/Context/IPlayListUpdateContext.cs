using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityTraining.Interfaces.Context
{
    public interface IPlayListUpdateContext<TEntity>
    {
        Task Update(TEntity entity);
    }
}
