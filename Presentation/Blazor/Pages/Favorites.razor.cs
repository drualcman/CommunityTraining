using BlazorIndexedDb.Models;
using CommunityTraining.Presentation.Blazor.Services;
using CommunityTraining.Domain.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityTraining.Presentation.Blazor.Pages
{
    public partial class Favorites
    {
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
            await FavContext.VideosList.DeleteAsync(id);
            ListaFavorita = await FavContext.VideosList.SelectAsync();
            StateHasChanged();
        }

        async Task Guardar()
        {
            try
            {
                await FavContext.VideosList.UpdateAsync(VideoEdit);
            }
            catch 
            {

            }
           
            IsShowingDetail = false;
            StateHasChanged();
        }
    }
}
