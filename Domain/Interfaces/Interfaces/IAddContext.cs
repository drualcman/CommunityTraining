using System;
using System.Threading.Tasks;

namespace CommunityTraining.Domain.Common.Interfaces
{
    public interface IAddContext<TEntity>
    {
        Task Add(TEntity entity);
    }
}
