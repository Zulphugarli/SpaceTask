using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceTask.Model.Response
{
    public class PostersResponse
    {
        public string ImDbId { get; set; }
        public string Title { get; set; }
        public string FullTitle { get; set; }
        public string Type { get; set; }
        public string Year { get; set; }
        public Poster[] Posters { get; set; }
        public Backdrop[] Backdrops { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class Poster
    {
        public string Id { get; set; }
        public string Link { get; set; }
        public float AspectRatio { get; set; }
        public string Language { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class Backdrop
    {
        public string Id { get; set; }
        public string Link { get; set; }
        public float AspectRatio { get; set; }
        public string Language { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

}
