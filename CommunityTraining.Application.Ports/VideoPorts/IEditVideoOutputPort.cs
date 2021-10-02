using CommunityTraining.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityTraining.Application.Ports.VideoPorts
{
    public interface IEditVideoOutputPort
    {
        Task Handle(PlayList video);
    }
}
