using CommunityTraining.Presentation.Blazor.Shared;
using CommunityTraining.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CommunityTraining.Presentation.Blazor.Pages
{
    public partial class PlayVideo
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        public HttpClient ApiClient { get; set; }

        [Inject]
        public NavigationManager Navigaton { get; set; }


        protected YoutubePlayer Reproductor = new YoutubePlayer();
        PlayList Playing;

        protected override async Task OnParametersSetAsync()
        {
            Playing = await ApiClient.GetFromJsonAsync<PlayList>($"playlist/{Id}");
        }

        void Cerrar()
        {
            Reproductor.StopVideo();
            Navigaton.NavigateTo("gallery");
        }
    }
}
