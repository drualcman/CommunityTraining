using System;
using System.Threading.Tasks;

namespace CommunityTraining.Common.Interfaces
{
    public interface IAddContext<TEntity>
    {
        Task Add(TEntity entity);
    }
}
