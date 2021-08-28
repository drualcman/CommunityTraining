using CommunityTraining.Domain.Common.Exceptions;
using CommunityTraining.Domain.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CommunityTraining.Presentation.Blazor.Pages
{
    public partial class Video
    {
        [Inject]
        public HttpClient ApiClient { get; set; }

        [Inject]
        public NavigationManager Navigaton { get; set; }

        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        [Parameter]
        public string Id { get; set; }

        PlayList VideoEdit;

        protected override async Task OnParametersSetAsync()
        {
            if (string.IsNullOrEmpty(Id))
            {
                VideoEdit = new PlayList();
            }
            else
            {
                VideoEdit = await ApiClient.GetFromJsonAsync<PlayList>($"playlist/{Id}");
            }
        }

        async void Guardar()
        {
            HttpResponseMessage responseMessage;
            VideoEdit.Ownner = "Guest";
            if (string.IsNullOrEmpty(Id))
            {
                VideoEdit.Id = Helpers.Video.ExtraerId(VideoEdit.Url);
                responseMessage = await ApiClient.PostAsJsonAsync("playlist", VideoEdit);
            }
            else
            {
                responseMessage = await ApiClient.PutAsJsonAsync("playlist", VideoEdit);
            }
            if (responseMessage.IsSuccessStatusCode) Navigaton.NavigateTo("gallery");
            else
            {
                try
                {
                    ProblemDetails details = await responseMessage.Content.ReadFromJsonAsync<ProblemDetails>();
                    await JsRuntime.InvokeVoidAsync("alert", details.ToString());
                }
                catch (Exception ex)
                {
                    await JsRuntime.InvokeVoidAsync("alert", ex.Message);
                }
            }
        }

        void Cancel()
        {
            Navigaton.NavigateTo("gallery");
        }
    }
}
