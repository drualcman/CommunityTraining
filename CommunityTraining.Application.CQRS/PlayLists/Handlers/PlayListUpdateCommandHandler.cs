using CommunityTraining.Application.CQRS.PlayLists.Commands;
using CommunityTraining.Entities;
using CommunityTraining.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommunityTraining.Application.CQRS.PlayLists.Handlers
{
    public class PlayListUpdateCommandHandler : IRequestHandler<PlayListUpdateCommand>
    {
        readonly IUpdateContext<PlayList> Context;
        public PlayListUpdateCommandHandler(IUpdateContext<PlayList> context) => Context = context;

        public Task<Unit> Handle(PlayListUpdateCommand command, CancellationToken cancellationToken)
        {
            Context.Update(command);
            return Unit.Task;
        }
    }
}
