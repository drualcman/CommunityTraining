using CommunityTraining.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CommunityTraining.Blazor.Shared
{
    public partial class VideoEditor
    {
        [Parameter]
        public PlayList VideoEdit { get; set; }
    }
}
