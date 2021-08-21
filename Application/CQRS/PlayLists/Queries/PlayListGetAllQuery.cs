using CommunityTraining.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityTraining.CQRS.PlayLists.Queries
{
    public class PlayListGetAllQuery : IRequest<IEnumerable<PlayList>>
    {
    }
}
