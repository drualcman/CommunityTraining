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
    public class PlayListCreateCommandHandler : IRequestHandler<PlayListCreateCommand, int>
    {
        readonly IPlayListAddContext<PlayList> Context;
        public PlayListCreateCommandHandler(IPlayListAddContext<Entities.PlayList> context) => Context = context;

        public Task<int> Handle(PlayListCreateCommand command, CancellationToken cancellationToken) =>
            Context.Add(new PlayList 
            { 
                Url = command.Url,
                Title = command.Title,
                Description = command.Description,
                Conferencer = command.Conferencer,
                Ownner = command.Ownner
            });
    }
}
