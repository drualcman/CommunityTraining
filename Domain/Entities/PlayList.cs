using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityTraining.Domain.Entities
{
    public class PlayList
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Conferencer { get; set; }
        public string Ownner { get; set; }
        public string Preview => Images[4];
        public List<string> Images 
        { 
            get
            {
                //https://newbedev.com/how-do-i-get-a-youtube-video-thumbnail-from-the-youtube-api
                return new List<string>
                {
                    $"https://img.youtube.com/vi/{this.Id}/0.jpg",
                    $"https://img.youtube.com/vi/{this.Id}/1.jpg",
                    $"https://img.youtube.com/vi/{this.Id}/2.jpg",
                    $"https://img.youtube.com/vi/{this.Id}/3.jpg",
                    $"https://img.youtube.com/vi/{this.Id}/default.jpg",
                    $"https://img.youtube.com/vi/{this.Id}/hqdefault.jpg",
                    $"https://img.youtube.com/vi/{this.Id}/mqdefault.jpg",
                    $"https://img.youtube.com/vi/{this.Id}/sddefault.jpg",
                    $"https://img.youtube.com/vi/{this.Id}/maxresdefault.jpg",
                };
            }
        }
    }
}
