using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CommunityTraining.Presentation.Blazor.Helpers
{
    public class Video
    {
        public static string Preview(string id) => $"https://img.youtube.com/vi/{id}/maxresdefault.jpg";

        //https://newbedev.com/how-do-i-get-a-youtube-video-thumbnail-from-the-youtube-api
        public static List<string> Images(string id)
        {
            return new List<string>
                {
                    $"https://img.youtube.com/vi/{id}/0.jpg",
                    $"https://img.youtube.com/vi/{id}/1.jpg",
                    $"https://img.youtube.com/vi/{id}/2.jpg",
                    $"https://img.youtube.com/vi/{id}/3.jpg",
                    $"https://img.youtube.com/vi/{id}/default.jpg",
                    $"https://img.youtube.com/vi/{id}/hqdefault.jpg",
                    $"https://img.youtube.com/vi/{id}/mqdefault.jpg",
                    $"https://img.youtube.com/vi/{id}/sddefault.jpg",
                    $"https://img.youtube.com/vi/{id}/maxresdefault.jpg",
                };
        
        }
    

        public static string ExtraerId(string Video)
        {
            string id;
            if (Video.ToLower().Contains("http") || Video.ToLower().Contains("youtu"))
            {
                try
                {
                    Uri uri = new Uri(Video);
                    id = ExtraerId(uri);
                }
                catch
                {
                    id = Video;
                }
            }
            else id = Video;
            return id;
        }

        public static string ExtraerId(Uri uri)
        {
            NameValueCollection query = HttpUtility.ParseQueryString(uri.Query);
            return query["v"];
        }
    }
}
