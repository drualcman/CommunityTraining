using CommunityTraining.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using CommunityTraining.Entities.Interfaces;

namespace CommunityTraining.Presentation.Blazor.Pages
{
    public partial class Favorites
    {
        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        [Inject]
        public ILocalRepository FavContext { get; set; }

        [Inject]
        public NavigationManager Navigaton { get; set; }

        public List<PlayList> ListaFavorita;
        bool IsShowingDetail;
        PlayList VideoEdit;

        protected override async Task OnInitializedAsync()
        {
            ListaFavorita = await FavContext.GetAll();
        }

        void EditVideo(string id)
        {
            VideoEdit = ListaFavorita.Find(v => v.Id == id);
            IsShowingDetail = true;
        }

        public async Task DeleteVideo(string id)
        {
            await FavContext.DeleteVideo(id);
            ListaFavorita = await FavContext.GetAll();
            //StateHasChanged();
        }

        async Task Guardar()
        {
            await FavContext.UpdateVideo(VideoEdit);
            IsShowingDetail = false;
            //StateHasChanged();
        }
    }
}
