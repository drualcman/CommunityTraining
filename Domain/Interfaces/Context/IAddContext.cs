using System;
using System.Threading.Tasks;

namespace CommunityTraining.Interfaces.Context
{
    public interface IAddContext<TEntity>
    {
        Task Add(TEntity entity);
    }
}
