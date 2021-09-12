using CommunityTraining.Application.CQRS.PlayLists.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityTraining.Application.CQRS.PlayLists.Validators
{
    public class PlayListDeleteCommandValidator : AbstractValidator<PlayListDeleteCommand>
    {
        public PlayListDeleteCommandValidator()
        {
            RuleFor(d => d.Id).NotEmpty();
        }

    }
}
