using CommunityTraining.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityTraining.Application.CQRS.PlayLists.Commands
{
    public class PlayListUpdateCommand : PlayList, IRequest { }
}
