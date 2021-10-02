using CommunityTraining.Application.UseCases.Validators;
using CommunityTraining.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityTraining.Application.UseCases.Validators
{
    public class VideoValidator : AbstractValidator<PlayList>
    {
        public VideoValidator()
        {
            RuleFor(p => p.Id).NotEmpty().WithMessage("Not found.")
                .Must((p, o) => CheckId(p.Url, o)).WithMessage("Not found.");
            RuleFor(u => u.Url).Must((p) => CheckId(p, "https")).WithMessage("HTTPS is required.");
        }

        bool CheckId(string a, string b) =>
            a.Contains(b);

    }
}
