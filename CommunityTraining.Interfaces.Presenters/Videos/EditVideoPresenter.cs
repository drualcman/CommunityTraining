using CommunityTraining.Application.Ports.VideoPorts;
using CommunityTraining.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityTraining.Interfaces.Presenters.Videos
{
    public class EditVideoPresenter : IPresenter<PlayList>, IEditVideoOutputPort
    {
        public PlayList Content { get; private set; }

        public Task Handle(PlayList video)
        {
            Content = video;
            return Task.CompletedTask;
        }
    }
}
