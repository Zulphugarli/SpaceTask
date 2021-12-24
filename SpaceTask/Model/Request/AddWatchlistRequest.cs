using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceTask.Model.Request
{
    public class AddWatchlistRequest
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public bool IsWatched { get; set; }
    }
}
