using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityTraining.Entities.Interfaces
{
    public interface ILocalRepository
    {
        Task<List<PlayList>> GetAll();
        Task AddVideo(PlayList entity);
        Task UpdateVideo(PlayList entity);
        Task DeleteVideo(string id);
    }
}
