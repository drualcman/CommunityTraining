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
    public class GetVideoController
    {
        readonly IGetVideoInputPort InputPort;
        readonly IEditVideoOutputPort OutputPort;
        public GetVideoController(IGetVideoInputPort inputPort, IEditVideoOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpGet("playlist/{id}")]
        public async Task<PlayList> Get(string id)
        {
            await InputPort.Handle(id);
            IPresenter<PlayList> presenter = OutputPort as EditVideoPresenter;
            return presenter.Content;
        }
    }
}
