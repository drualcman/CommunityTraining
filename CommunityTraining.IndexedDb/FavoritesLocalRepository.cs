using BlazorIndexedDb.Models;
using CommunityTraining.Entities;
using CommunityTraining.Entities.Interfaces;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityTraining.IndexedDb
{
    public class FavoritesLocalRepository : ILocalRepository
    {
        readonly FavoritesContext Context;
        readonly IJSRuntime JsRuntime;
        public FavoritesLocalRepository(IJSRuntime js) 
        {
            JsRuntime = js;
            Context = new FavoritesContext(js);
        }

        public Task<List<PlayList>> GetAll() => 
            Context.VideosList.SelectAsync();

        public async Task AddVideo(PlayList entity)
        {
            CommandResponse response = await Context.VideosList.AddAsync(entity);
            await ManageResponse(response, "agregar");
        }

        public async Task UpdateVideo(PlayList entity)
        {
            CommandResponse response = await Context.VideosList.UpdateAsync(entity);
            await ManageResponse(response, "actualizar");
        }

        public async Task DeleteVideo(string id)
        {
            CommandResponse response = await Context.VideosList.DeleteAsync(id);
            await ManageResponse(response, "eliminar");
        }

        private async Task ManageResponse(CommandResponse response, string action)
        {
            if (!response.Result)
            {
                string messages = response.Message;
                foreach (ResponseJsDb item in response.Response)
                {
                    messages += item.Message;
                }
                await JsRuntime.InvokeVoidAsync("alert", $"Error al {action} de favoritos: {messages}");
            }
        }

    }
}
