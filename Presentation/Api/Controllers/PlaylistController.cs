using CommunityTraining.Entities;
using CommunityTraining.Interfaces.Context;
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
        private readonly IPlayListAddContext<PlayList> AddContext;
        private readonly IPlayListUpdateContext<PlayList> UpdateContext;
        private readonly IPlayListDeleteContext DeleteContext;
        private readonly IPlayListGetAllContext<PlayList> GetAllContext;
        private readonly IPlayListGetContext<PlayList> GetContext;

        public PlaylistController(
            IPlayListAddContext<PlayList> addContext,
            IPlayListUpdateContext<PlayList> updateContext,
            IPlayListDeleteContext deleteContext,
            IPlayListGetAllContext<PlayList> getAllContext,
            IPlayListGetContext<PlayList> getContext)
        {
            AddContext = addContext;
            UpdateContext = updateContext;
            DeleteContext = deleteContext;
            GetAllContext = getAllContext;
            GetContext = getContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await GetAllContext.GetAll());


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) =>
            Ok(await GetContext.Get(id));


        [HttpPost]
        public async Task<IActionResult> Add(PlayList video) =>
            Ok(await AddContext.Add(video));

        [HttpPut]
        public async Task<IActionResult> Update(PlayList video) =>
            Ok(await UpdateContext.Update(video));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) =>
            Ok(await DeleteContext.Delete(id));

    }
}
