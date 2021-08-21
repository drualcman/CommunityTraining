﻿using CommunityTraining.CQRS.PlayLists.Queries;
using CommunityTraining.Entities;
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
    public class PlayListGetAllQueryHandler : IRequestHandler<PlayListGetAllQuery, IEnumerable<PlayList>>
    {
        readonly IPlayListGetAllContext<PlayList> Context;
        public PlayListGetAllQueryHandler(IPlayListGetAllContext<PlayList> context) => Context = context;
        public Task<IEnumerable<PlayList>> Handle(PlayListGetAllQuery command, CancellationToken cancellationToken) =>
            Context.GetAll();
    }
}
