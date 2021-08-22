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
        public async Task<IActionResult> Get(string id) =>
            Ok(await Mediator.Send(new PlayListGetQuery() { Id = id }));

        [HttpPost]
        public async Task<IActionResult> Add(PlayListCreateCommand video) =>
            Ok(await Mediator.Send(video));

        [HttpPut]
        public async Task<IActionResult> Update(PlayListUpdateCommand video) =>
            Ok(await Mediator.Send(video));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id) =>
            Ok(await Mediator.Send(new PlayListDeleteCommand() { Id = id }));

    }
}
