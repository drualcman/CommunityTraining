using CommunityTraining.Application.Ports.VideoPorts;
using CommunityTraining.Entities;
using CommunityTraining.Interfaces.Presenters;
using CommunityTraining.Interfaces.Presenters.Videos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CommunityTraining.Interfaces.Controllers.Videos
{
    [ApiController]
    public class DeleteVideoController
    {
        readonly IDeleteVideoInputPort InputPort;
        readonly IDeleteVideoOutputPort OutputPort;
        public DeleteVideoController(IDeleteVideoInputPort inputPort, IDeleteVideoOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpDelete("playlist/{id}")]
        public async Task<bool> Delete(string id)
        {
            await InputPort.Handle(id);
            IPresenter<bool> presenter = OutputPort as DeleteVideoPresenter;
            return presenter.Content;
        }
    }
}
