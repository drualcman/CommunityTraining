using CommunityTraining.Application.CQRS.PlayLists.Commands;
using CommunityTraining.Common.Interfaces;
using CommunityTraining.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommunityTraining.Application.CQRS.PlayLists.Handlers
{
    public class PlayListCreateCommandHandler : IRequestHandler<PlayListCreateCommand>
    {
        readonly IAddContext<PlayList> Context;
        public PlayListCreateCommandHandler(IAddContext<PlayList> context) => Context = context;

        public Task<Unit> Handle(PlayListCreateCommand command, CancellationToken cancellationToken)
        {
            Context.Add(command);
            return Unit.Task;
        }
    }
}
