using CommunityTraining.Presentation.Blazor.Services;
using CommunityTraining.Presentation.Blazor.Shared;
using CommunityTraining.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorIndexedDb.Models;

namespace CommunityTraining.Presentation.Blazor.Pages
{
    public partial class Gallery
    {
        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        [Inject]
        public HttpClient ApiClient { get; set; }

        [Inject]
        public NavigationManager Navigaton { get; set; }

        [Inject]
        public FavoritesContext FavContext { get; set; }

        public List<PlayList> ListaReproduccion;
        public List<PlayList> ListaFavorita;
        private bool Clicked;

        protected override async Task OnInitializedAsync()
        {
            await LoadList();
        }

        public async Task LoadList()
        {
            ListaReproduccion = await ApiClient.GetFromJsonAsync<List<PlayList>>("playlist");
            ListaFavorita = await FavContext.VideosList.SelectAsync();
        }

        public async Task DeleteVideo(string id)
        {
            if (!Clicked)
            {
                Clicked = true;
                HttpResponseMessage responseMessage = await ApiClient.DeleteAsync($"playlist/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    PlayList video = ListaReproduccion.Where(v => v.Id == id).FirstOrDefault();
                    if (!ListaReproduccion.Remove(video)) await JsRuntime.InvokeVoidAsync("location.reload");
                }
                else await JsRuntime.InvokeVoidAsync("alert", "No se ha podido borrar el video");
                Clicked = false;
            }
        }

        void EditVideo(string id)
        {
            Navigaton.NavigateTo($"video/{id}");
        }

        bool IsFavorite(string id) =>
            (ListaFavorita.Find(v => v.Id == id) is not null);

        async Task SetFav(string id)
        {
            CommandResponse response;
            if (IsFavorite(id))
            {
                response = await FavContext.VideosList.DeleteAsync(id);
            }
            else 
            {
                response = await FavContext.VideosList.AddAsync(ListaReproduccion.Find(v => v.Id == id));
            }
            if (!response.Result)
            {
                string messages = string.Empty;
                foreach (ResponseJsDb item in response.Response)
                {
                    messages += item.Message;
                }
                await JsRuntime.InvokeVoidAsync("alert", $"Error al manejar los favoritos: {messages}");
            }
            await LoadList();
            StateHasChanged();
        }
    }
}
