using CommunityTraining.Application.Ports.VideoPorts;
using CommunityTraining.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityTraining.Interfaces.Presenters.Videos
{
    public class AllVideoPresenter : IPresenter<IEnumerable<PlayList>>, IAllVideoOutputPort
    {
        public IEnumerable<PlayList> Content { get; private set; }

        public Task Handle(IEnumerable<PlayList> videos)
        {
            Content = videos;
            return Task.CompletedTask;
        }
    }
}
