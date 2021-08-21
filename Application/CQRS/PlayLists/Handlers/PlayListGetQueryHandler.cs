using CommunityTraining.CQRS.PlayLists.Queries;
using CommunityTraining.Entities;
using CommunityTraining.Interfaces.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommunityTraining.CQRS.PlayLists.Handlers
{
    public class PlayListGetQueryHandler : IRequestHandler<PlayListGetQuery, PlayList>
    {
        readonly IPlayListGetContext<PlayList> Context;
        public PlayListGetQueryHandler(IPlayListGetContext<PlayList> context) => Context = context;
        public Task<PlayList> Handle(PlayListGetQuery command, CancellationToken cancellationToken) =>
            Context.Get(command.Id);
    }
}
