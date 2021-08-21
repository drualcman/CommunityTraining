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
    public class PlayListDeleteCommandHandler : IRequestHandler<PlayListDeleteCommand, bool>
    {
        readonly IPlayListDeleteContext Context;
        public PlayListDeleteCommandHandler(IPlayListDeleteContext context) => Context = context;
        public Task<bool> Handle(PlayListDeleteCommand command, CancellationToken cancellationToken) =>
            Context.Delete(command.Id);
    }
}
