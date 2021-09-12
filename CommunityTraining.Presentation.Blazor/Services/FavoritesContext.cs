using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorIndexedDb.Configuration;
using BlazorIndexedDb.Store;
using CommunityTraining.Entities;
using Microsoft.JSInterop;

namespace CommunityTraining.Presentation.Blazor.Services
{
    public class FavoritesContext : StoreContext
    {
        public StoreSet<PlayList> VideosList { get; set; }

        public FavoritesContext(IJSRuntime js) : base(js, new Settings { DBName = "VideoFav", Version = 1 }) { }

    }
}
