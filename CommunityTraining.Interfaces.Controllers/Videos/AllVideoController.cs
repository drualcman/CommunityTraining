using CommunityTraining.Application.Ports.VideoPorts;
using CommunityTraining.Entities;
using CommunityTraining.Interfaces.Presenters;
using CommunityTraining.Interfaces.Presenters.Videos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommunityTraining.Interfaces.Controllers.Videos
{
    [ApiController]
    public class AllVideoController
    {
        readonly IAllVideoInputPort InputPort;
        readonly IAllVideoOutputPort OutputPort;
        public AllVideoController(IAllVideoInputPort inputPort, IAllVideoOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpGet("playlist")]
        public async Task<IEnumerable<PlayList>> GetAll()
        {
            await InputPort.Handle();
            IPresenter<IEnumerable<PlayList>> presenter = OutputPort as AllVideoPresenter;
            return presenter.Content;
        }
    }
}
