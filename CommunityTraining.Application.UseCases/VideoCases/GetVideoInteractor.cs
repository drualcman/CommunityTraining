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
    public class GetVideoInteractor : IGetVideoInputPort
    {
        readonly IGetContext<PlayList> Context;
        readonly IEditVideoOutputPort OutputPort;
        public GetVideoInteractor(
            IGetContext<PlayList> context,
            IEditVideoOutputPort outputPort) => 
            (Context, OutputPort) = (context, outputPort);

        public async Task Handle(string id)
        {
            IdVideoSpecification delete = new();
            if (delete.IsSatisfy(id))
            {
                await OutputPort.Handle(await Context.Get(id));
            }
            else throw new KeyNotFoundException("Id can't be empty");
        }
    }
}
