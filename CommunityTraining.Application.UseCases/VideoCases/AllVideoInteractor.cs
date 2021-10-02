using CommunityTraining.Application.Ports.VideoPorts;
using CommunityTraining.Entities;
using CommunityTraining.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityTraining.Application.UseCases.VideoCases
{
    public class AllVideoInteractor : IAllVideoInputPort
    {
        readonly IGetAllContext<PlayList> Context;
        readonly IAllVideoOutputPort OutputPort;
        public AllVideoInteractor(
            IGetAllContext<PlayList> context,
            IAllVideoOutputPort outputPort) => 
            (Context, OutputPort) = (context, outputPort);

        public async Task Handle()
        {
            await OutputPort.Handle(await Context.GetAll());
        }
    }
}
