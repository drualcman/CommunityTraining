﻿using CommunityTraining.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace CommunityTraining.Presentation.Blazor.Shared
{
    public partial class YoutubePlayer : IDisposable
    {
        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        [Parameter]
        public string PlayerId { get; set; }

        [Parameter]
        public string VideoId { get; set; }


        private static Action actionApi;
        private static Action actionPlayer;

        bool IsApiLoad = false;
        bool IsPlayerReady = false;

        protected override void OnInitialized()
        {
            actionApi = ApiIsLoaded;
            actionPlayer = PlayerIsReady;
        }

        private void ApiIsLoaded()
        {
            Console.WriteLine("ApiIsLoaded");
            IsApiLoad = true;
        }

        private async void PlayerIsReady()
        {
            if (IsPlayerReady)
            {
                if (VideoId is not null)
                    await JsRuntime.InvokeVoidAsync("youtubeApi.payVideo", VideoId);
            }
            else
            {
                IsPlayerReady = true;
            }
            StateHasChanged();
        }

        [JSInvokable]
        public static void ApiLoaded()
        {
            actionApi.Invoke();
        }

        [JSInvokable]
        public static void PlayerReady()
        {
            actionPlayer.Invoke();
        }

        public Task<PlayList> AddToPlayListAsync(string Video)
        {
            string id;
            string title;
            id = Helpers.Video.ExtraerId(Video);

            title = id;

            PlayList playVideo = new PlayList
            {
                Id = id,
                Title = title,
                Url = Video
            };
            return Task.FromResult(playVideo);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JsRuntime.InvokeVoidAsync("youtubeApi.loadIFramePlayer", typeof(YoutubePlayer).Assembly.GetName().Name);
            }
        }

        public async void PlayVideo()
        {
            await JsRuntime.InvokeVoidAsync("youtubeApi.payVideo", VideoId);
        }

        public async void StopVideo()
        {
            await JsRuntime.InvokeVoidAsync("youtubeApi.stopVideo");
        }

        void IDisposable.Dispose()
        {
            IsApiLoad = false;
            IsPlayerReady = false;
            JsRuntime.InvokeVoidAsync("youtubeApi.dispose");
        }
    }
}
