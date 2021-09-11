using CommunityTraining.Application.CQRS.PlayLists.Queries;
using CommunityTraining.Entities;
using CommunityTraining.Common.Interfaces;
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
        public async Task<PlayList> Handle(PlayListGetQuery command, CancellationToken cancellationToken)
        {
            PlayList result =  await Context.Get(command.Id);
            if (result is not null)
            {
                return result;
            }
            else
            {
                throw new Exception($"{nameof(command.Id)} Not found");
            }
        }
    }
}
