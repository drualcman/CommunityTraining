using CommunityTraining.Blazor.Shared;
using CommunityTraining.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CommunityTraining.Blazor.Pages
{
    public partial class Gallery
    {
        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        [Inject]
        public HttpClient ApiClient { get; set; }

        [Inject]
        public NavigationManager Navigaton { get; set; }

        protected YoutubePlayer Reproductor = new YoutubePlayer();
        public List<PlayList> ListaReproduccion;
        private bool Clicked;

        protected override async Task OnInitializedAsync()
        {
            await LoadList();
        }

        public async Task LoadList()
        {
            ListaReproduccion = await ApiClient.GetFromJsonAsync<List<PlayList>>("playlist");
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

        string Playing = "qeMFqkcPYcg";
        bool ShowVideo;
        void PlayVideo(string Video)
        {
            Playing = Helpers.Video.ExtraerId(Video);
            Reproductor.PlayVideo();
            ShowVideo = true;
        }
        void EditVideo(string id)
        {
            Navigaton.NavigateTo($"video/{id}");
        }

        void Cerrar()
        {
            ShowVideo = false;
            Reproductor.StopVideo();
        }
    }
}
