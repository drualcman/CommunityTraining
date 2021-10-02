using CommunityTraining.Application.Ports.VideoPorts;
using CommunityTraining.Application.UseCases.Validators;
using CommunityTraining.Entities;
using CommunityTraining.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityTraining.Application.UseCases.VideoCases
{
    public class AddVideoInteractor : IAddVideoInputPort
    {
        readonly IAddContext<PlayList> Context;
        readonly IEditVideoOutputPort OutputPort;
        readonly IEnumerable<IValidator<PlayList>> Validators;
        public AddVideoInteractor(
            IAddContext<PlayList> context, 
            IEditVideoOutputPort outputPort,
            IEnumerable<IValidator<PlayList>> validators) => 
            (Context, OutputPort, Validators) = (context, outputPort, validators);

        public async Task Handle(PlayList video)
        {
            await Validator<PlayList>.Validate(video, Validators);
            await Context.Add(video);
            await OutputPort.Handle(video);
        }
    }
}
