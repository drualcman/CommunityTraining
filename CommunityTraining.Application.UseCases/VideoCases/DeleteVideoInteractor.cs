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
    public class DeleteVideoInteractor : IDeleteVideoInputPort
    {
        readonly IDeleteContext<PlayList> Context;
        readonly IDeleteVideoOutputPort OutputPort;
        public DeleteVideoInteractor(
            IDeleteContext<PlayList> context,
            IDeleteVideoOutputPort outputPort) => 
            (Context, OutputPort) = (context, outputPort);

        public async Task Handle(string id)
        {
            IdVideoSpecification delete = new();
            bool result;
            if (delete.IsSatisfy(id))
            {
                await Context.Delete(id);
                result = true;
            }
            else result = false;
            await OutputPort.Handle(result);
        }
    }
}
