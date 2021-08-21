using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityTraining.CQRS.PlayLists.Commands
{
    public class PlayListDeleteCommand : IRequest
    {
        public int Id { get; set; }
    }
}
