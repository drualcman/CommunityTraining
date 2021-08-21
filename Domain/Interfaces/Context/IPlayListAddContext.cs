using System;
using System.Threading.Tasks;

namespace CommunityTraining.Interfaces.Context
{
    public interface IPlayListAddContext<TEntity>
    {
        Task Add(TEntity entity);
    }
}
