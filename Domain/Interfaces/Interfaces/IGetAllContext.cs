using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityTraining.Domain.Common.Interfaces
{
    public interface IGetAllContext<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
    }
}
