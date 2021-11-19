using BlazorIndexedDb.Configuration;
using BlazorIndexedDb.Store;
using CommunityTraining.Entities;
using Microsoft.JSInterop;
using System;

namespace CommunityTraining.IndexedDb
{
    public class FavoritesContext : StoreContext
    {
        public StoreSet<PlayList> VideosList { get; set; }

        public FavoritesContext(IJSRuntime js) : base(js, new Settings { DBName = "VideoFav", Version = 1 }) { }

    }
}
