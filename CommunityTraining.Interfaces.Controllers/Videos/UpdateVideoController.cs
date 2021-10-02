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
    public class UpdateVideoController
    {
        readonly IUpdateVideoInputPort InputPort;
        readonly IEditVideoOutputPort OutputPort;
        public UpdateVideoController(IUpdateVideoInputPort inputPort, IEditVideoOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpPut("playlist")]
        public async Task<PlayList> Update(PlayList video)
        {
            await InputPort.Handle(video);
            IPresenter<PlayList> presenter = OutputPort as EditVideoPresenter;
            return presenter.Content;
        }
    }
}
