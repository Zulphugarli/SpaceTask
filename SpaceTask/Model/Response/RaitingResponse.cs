using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceTask.Model.Response
{
    public class RaitingResponse
    {
        public string imDbId { get; set; }
        public string title { get; set; }
        public string fullTitle { get; set; }
        public string type { get; set; }
        public string year { get; set; }
        public string imDb { get; set; }
        public string metacritic { get; set; }
        public string theMovieDb { get; set; }
        public string rottenTomatoes { get; set; }
        public string tV_com { get; set; }
        public string filmAffinity { get; set; }
        public string errorMessage { get; set; }
    }

}
