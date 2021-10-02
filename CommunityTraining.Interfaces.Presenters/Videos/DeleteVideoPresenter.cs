using CommunityTraining.Application.Ports.VideoPorts;
using CommunityTraining.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityTraining.Interfaces.Presenters.Videos
{
    public class DeleteVideoPresenter : IPresenter<bool>, IDeleteVideoOutputPort
    {
        public bool Content { get; private set; }

        public Task Handle(bool result)
        {
            Content = result;
            return Task.CompletedTask;
        }
    }
}
