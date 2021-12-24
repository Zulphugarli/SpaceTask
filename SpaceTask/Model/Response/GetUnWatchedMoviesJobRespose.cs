using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceTask.Model.Response
{
    public class GetUnWatchedMoviesJobRespose
    {
        public string FilmName { get; set; }
        public string Description { get; set; }
        public decimal FilmRate { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
    public class Moviess
    {
        private string _FilmName;
        private string _Description;
        private decimal _FilmRate;
        private string _Username;
        private string _Email;
        //public Movies(
        //    string AFilmName, string ADescription, decimal AFilmRate,
        //    string AUsername, string AEmail)
        //{
        //    _FilmName = AFilmName;
        //    _Description = ADescription;
        //    _FilmRate = AFilmRate;
        //    _Username = AUsername;
        //    _Email = AEmail;
        //}
        public string FilmName { get { return _FilmName; } }
        public string Description { get { return _Description; } }
        public decimal FilmRate { get { return _FilmRate; } }
        public string Username { get { return _Username; } }
        public string Email { get { return _Email; } }
    }
}
