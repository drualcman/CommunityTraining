using CommunityTraining.Application.CQRS.PlayLists.Queries;
using CommunityTraining.Domain.Entities;
using CommunityTraining.Domain.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommunityTraining.Application.CQRS.PlayLists.Handlers
{
    public class PlayListGetQueryHandler : IRequestHandler<PlayListGetQuery, PlayList>
    {
        readonly IGetContext<PlayList> Context;
        public PlayListGetQueryHandler(IGetContext<PlayList> context) => Context = context;
        public Task<PlayList> Handle(PlayListGetQuery command, CancellationToken cancellationToken) =>
            Context.Get(command.Id);
    }
}
