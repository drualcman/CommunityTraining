using CommunityTraining.Application.CQRS.PlayLists.Queries;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityTraining.Application.CQRS.PlayLists.Validators
{
    public class PlayListGetQueryValidator : AbstractValidator<PlayListGetQuery>
    {
        public PlayListGetQueryValidator()
        {
            RuleFor(d => d.Id).NotEmpty();
        }
    }
}
