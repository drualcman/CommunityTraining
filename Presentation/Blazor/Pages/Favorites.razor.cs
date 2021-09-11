using BlazorIndexedDb.Models;
using CommunityTraining.Presentation.Blazor.Services;
using CommunityTraining.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace CommunityTraining.Presentation.Blazor.Pages
{
    public partial class Favorites
    {
        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        [Inject]
        public FavoritesContext FavContext { get; set; }

        [Inject]
        public NavigationManager Navigaton { get; set; }

        public List<PlayList> ListaFavorita;
        bool IsShowingDetail;
        PlayList VideoEdit;

        protected override async Task OnInitializedAsync()
        {
            ListaFavorita = await FavContext.VideosList.SelectAsync();
        }

        void EditVideo(string id)
        {
            VideoEdit = ListaFavorita.Find(v => v.Id == id);
            IsShowingDetail = true;
        }

        public async Task DeleteVideo(string id)
        {
            CommandResponse response = await FavContext.VideosList.DeleteAsync(id);
            if (!response.Result)
            {
                string messages = response.Message;
                foreach (ResponseJsDb item in response.Response)
                {
                    messages += item.Message;
                }
                await JsRuntime.InvokeVoidAsync("alert", $"Error eliminar de favoritos: {messages}");
            }
            ListaFavorita = await FavContext.VideosList.SelectAsync();
            //StateHasChanged();
        }

        async Task Guardar()
        {
            CommandResponse response = await FavContext.VideosList.UpdateAsync(VideoEdit);
            if (!response.Result)
            {
                string messages = string.Empty;
                foreach (ResponseJsDb item in response.Response)
                {
                    messages += item.Message;
                }
                await JsRuntime.InvokeVoidAsync("alert", $"Error al manejar los favoritos: {messages}");
            }
            IsShowingDetail = false;
            //StateHasChanged();
        }
    }
}
