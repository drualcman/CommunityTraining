using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityTraining.CQRS.PlayLists.Commands
{
    public class PlayListCreateCommand : IRequest<int>
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Conferencer { get; set; }
        public string Ownner { get; set; }
    }
}
