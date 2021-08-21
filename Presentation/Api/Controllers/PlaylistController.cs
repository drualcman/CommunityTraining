using CommunityTraining.CQRS.PlayLists.Commands;
using CommunityTraining.CQRS.PlayLists.Queries;
using CommunityTraining.Entities;
using CommunityTraining.Interfaces.Context;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityTraining.Api.Controllers
{
    [Route("playlist")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IMediator Mediator;

        public PlaylistController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await Mediator.Send(new PlayListGetAllQuery()));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) =>
            Ok(await Mediator.Send(new PlayListGetQuery() { Id = id }));

        [HttpPost]
        public async Task<IActionResult> Add(PlayList video) =>
            Ok(await Mediator.Send(new PlayListCreateCommand() 
            { 
                Url = video.Url,
                Title = video.Title,
                Description = video.Description,
                Conferencer = video.Conferencer,
                Ownner = video.Ownner
            }));

        [HttpPut]
        public async Task<IActionResult> Update(PlayList video) =>
            Ok(await Mediator.Send(new PlayListUpdateCommand()
            {
                Id = video.Id,
                Url = video.Url,
                Title = video.Title,
                Description = video.Description,
                Conferencer = video.Conferencer,
                Ownner = video.Ownner
            }));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) =>
            Ok(await Mediator.Send(new PlayListDeleteCommand() { Id = id }));

    }
}
