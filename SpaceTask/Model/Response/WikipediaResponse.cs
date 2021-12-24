using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceTask.Model.Response
{
    public class WikipediaResponse
    {
        public string ImDbId { get; set; }
        public string Title { get; set; }
        public string FullTitle { get; set; }
        public string Type { get; set; }
        public string Year { get; set; }
        public string Language { get; set; }
        public string TitleInLanguage { get; set; }
        public string Url { get; set; }
        public Plotshort PlotShort { get; set; }
        public Plotfull PlotFull { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class Plotshort
    {
        public string PlainText { get; set; }
        public string Html { get; set; }
    }

    public class Plotfull
    {
        public string PlainText { get; set; }
        public string Html { get; set; }
    }

}
