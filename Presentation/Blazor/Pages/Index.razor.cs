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
    public partial class Index
    {
        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        [Inject]
        public HttpClient ApiClient { get; set; }

        protected YoutubePlayer Reproductor;
        public List<PlayList> ListaReproduccion;
        public string UserName = "Gest";
        public string Video;
        private bool Clicked;

        protected override async Task OnInitializedAsync()
        {
            await LoadList();
        }

        public async Task LoadList()
        {
            ListaReproduccion = await ApiClient.GetFromJsonAsync<List<PlayList>>("playlist");            
        }

        public async Task AddVideo()
        {
            if (!Clicked)
            {
                Clicked = true;
                PlayList video = await Reproductor.AddToPlayListAsync(Video);
                video.Ownner = UserName;
                HttpResponseMessage responseMessage = await ApiClient.PostAsJsonAsync("playlist", video);
                if (responseMessage.IsSuccessStatusCode) ListaReproduccion.Add(video);
                else await JsRuntime.InvokeVoidAsync("alert", "No se ha podido agregar el video");
                Clicked = false;
            }
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

        void PlayVideo()
        {
            Playing = Helpers.Video.ExtraerId(Video);
        }
    }
}
