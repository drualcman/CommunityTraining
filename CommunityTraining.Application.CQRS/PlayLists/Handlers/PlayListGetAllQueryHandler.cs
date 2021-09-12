using CommunityTraining.Application.CQRS.PlayLists.Queries;
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
    public class PlayListGetAllQueryHandler : IRequestHandler<PlayListGetAllQuery, IEnumerable<PlayList>>
    {
        readonly IGetAllContext<PlayList> Context;
        public PlayListGetAllQueryHandler(IGetAllContext<PlayList> context) => Context = context;
        public Task<IEnumerable<PlayList>> Handle(PlayListGetAllQuery command, CancellationToken cancellationToken) =>
            Context.GetAll();
    }
}
