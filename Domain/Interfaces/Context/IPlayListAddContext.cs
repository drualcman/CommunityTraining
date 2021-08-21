using System;
using System.Threading.Tasks;

namespace CommunityTraining.Interfaces.Context
{
    public interface IPlayListAddContext<TEntity>
    {
        Task<int> Add(TEntity entity);
    }
}
