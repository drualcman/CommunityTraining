using CommunityTraining.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CommunityTraining.Entities.Interfaces;

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
        public ILocalRepository FavContext { get; set; }

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
            ListaFavorita = await FavContext.GetAll();
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
            if (IsFavorite(id))
            {
                await FavContext.DeleteVideo(id);
            }
            else 
            {
                await FavContext.AddVideo(ListaReproduccion.Find(v => v.Id == id));
            }           
            await LoadList();
            StateHasChanged();
        }
    }
}
