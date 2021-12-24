using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceTask.Model.Response
{
    public class TitleResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        public string FullTitle { get; set; }
        public string Type { get; set; }
        public string Year { get; set; }
        public string Image { get; set; }
        public string ReleaseDate { get; set; }
        public string RuntimeMins { get; set; }
        public string RuntimeStr { get; set; }
        public string Plot { get; set; }
        public string PlotLocal { get; set; }
        public bool PlotLocalIsRtl { get; set; }
        public string Awards { get; set; }
        public string Directors { get; set; }
        public Directorlist[] DirectorList { get; set; }
        public string Writers { get; set; }
        public Writerlist[] WriterList { get; set; }
        public string Stars { get; set; }
        public Starlist[] StarList { get; set; }
        public Actorlist[] ActorList { get; set; }
        public object FullCast { get; set; }
        public string Genres { get; set; }
        public Genrelist[] GenreList { get; set; }
        public string Companies { get; set; }
        public Companylist[] CompanyList { get; set; }
        public string Countries { get; set; }
        public Countrylist[] CountryList { get; set; }
        public string Languages { get; set; }
        public Languagelist[] LanguageList { get; set; }
        public string ContentRating { get; set; }
        public string ImDbRating { get; set; }
        public string ImDbRatingVotes { get; set; }
        public string MetacriticRating { get; set; }
        public object Ratings { get; set; }
        public object Wikipedia { get; set; }
        public object Posters { get; set; }
        public object Images { get; set; }
        public object Trailer { get; set; }
        public Boxoffice BoxOffice { get; set; }
        public string Tagline { get; set; }
        public string Keywords { get; set; }
        public string[] KeywordList { get; set; }
        public Similar[] Similars { get; set; }
        public object TvSeriesInfo { get; set; }
        public object TvEpisodeInfo { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class Boxoffice
    {
        public string Budget { get; set; }
        public string OpeningWeekendUSA { get; set; }
        public string GrossUSA { get; set; }
        public string CumulativeWorldwideGross { get; set; }
    }

    public class Directorlist
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Writerlist
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Starlist
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Actorlist
    {
        public string Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string IsCharacter { get; set; }
    }

    public class Genrelist
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class Companylist
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Countrylist
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class Languagelist
    {
        public string key { get; set; }
        public string value { get; set; }
    }

    public class Similar
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string FullTitle { get; set; }
        public string Year { get; set; }
        public string Image { get; set; }
        public string Plot { get; set; }
        public string Directors { get; set; }
        public string Stars { get; set; }
        public string Genres { get; set; }
        public string ImDbRating { get; set; }
    }

}
