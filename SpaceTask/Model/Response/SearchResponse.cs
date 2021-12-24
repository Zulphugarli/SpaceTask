using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceTask.Model.Response
{
    public class SearchResponse
    {
        public string SearchType { get; set; }
        public string Expression { get; set; }
        public Result[] Results { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class Result
    {
        public string Id { get; set; }
        public string ResultType { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

}
