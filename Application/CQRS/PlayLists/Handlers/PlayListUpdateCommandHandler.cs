using CommunityTraining.CQRS.PlayLists.Commands;
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
    public class PlayListUpdateCommandHandler : IRequestHandler<PlayListUpdateCommand>
    {
        readonly IPlayListUpdateContext<PlayListUpdateCommand> Context;
        public PlayListUpdateCommandHandler(IPlayListUpdateContext<PlayListUpdateCommand> context) => Context = context;

        public Task<Unit> Handle(PlayListUpdateCommand command, CancellationToken cancellationToken)
        {
            Context.Update(command);
            return Unit.Task;
        }
    }
}
