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
    public class PlayListDeleteCommandHandler : IRequestHandler<PlayListDeleteCommand>
    {
        readonly IDeleteContext<PlayList> Context;
        public PlayListDeleteCommandHandler(IDeleteContext<PlayList> context) => Context = context;

        public Task<Unit> Handle(PlayListDeleteCommand command, CancellationToken cancellationToken)
        {
            Context.Delete(command.Id);
            return Unit.Task;
        }
    }
}
