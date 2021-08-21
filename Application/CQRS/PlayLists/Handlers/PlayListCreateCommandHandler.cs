using CommunityTraining.CQRS.PlayLists.Commands;
using CommunityTraining.Interfaces.Context;
using CommunityTraining.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommunityTraining.CQRS.PlayLists.Handlers
{
    public class PlayListCreateCommandHandler : IRequestHandler<PlayListCreateCommand>
    {
        readonly IAddContext<PlayList> Context;
        public PlayListCreateCommandHandler(IAddContext<Entities.PlayList> context) => Context = context;

        public Task<Unit> Handle(PlayListCreateCommand command, CancellationToken cancellationToken)
        {
            Context.Add(new PlayList
            {
                Url = command.Url,
                Title = command.Title,
                Description = command.Description,
                Conferencer = command.Conferencer,
                Ownner = command.Ownner
            });
            return Unit.Task;
        }
    }
}
