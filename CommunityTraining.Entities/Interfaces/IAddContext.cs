using System;
using System.Threading.Tasks;

namespace CommunityTraining.Interfaces
{
    public interface IAddContext<TEntity>
    {
        Task Add(TEntity entity);
    }
}
