using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SpaceTask.Model.Database;
using SpaceTask.Model.Request;
using SpaceTask.Model.Response;
using SpaceTask.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SpaceTask.Services
{
    public class MovieRepository : IMovieService
    {
        private IConfiguration _configuration;


        private readonly MovieContext _context;

        public MovieRepository(IConfiguration iConfig)
        {
            _configuration = iConfig;
            _context = new MovieContext(iConfig);
        }
        public async Task<ResponseModel> AddUser(AddUserRequest userRequest)
        {
            Users user = new Users();
            ResponseModel model = new ResponseModel();
            try
            {
                user.Email = userRequest.Email;
                user.MobilePhone = userRequest.MobilePhone;
                user.Username = userRequest.Username;
                await _context.AddAsync<Users>(user);
                model.Messsage = "User Inserted Successfully";
                await _context.SaveChangesAsync();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }
        public async Task<ResponseModel> AddWatchList(AddWatchlistRequest watchListRequest)
        {
            Watchlists watchlists = new Watchlists();
            ResponseModel model = new ResponseModel();
            try
            {
                watchlists.MovieId = watchListRequest.MovieId;
                watchlists.UserId = watchListRequest.UserId;
                watchlists.IsWatched = watchListRequest.IsWatched;
                await _context.AddAsync<Watchlists>(watchlists);
                model.Messsage = "Watchlists Inserted Successfully";
                await _context.SaveChangesAsync();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }
        public async Task<ResponseModel> AddMovie(Movies movie)
        {    
            ResponseModel model = new ResponseModel();
            try
            {
                await _context.AddAsync<Movies>(movie);
                model.Messsage = "Movie Inserted Successfully";
                await _context.SaveChangesAsync();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.InnerException;
            }
            return model;
        }
        public async Task<ResponseModel> UpdateIsWatched(UpdateMovieWatchedRequest request)
        {
            ResponseModel model = new ResponseModel();

            try
            {
                Watchlists c = (from x in _context.Watchlists
                                where x.MovieId == request.MovieId && x.UserId == request.UserId
                                select x).First();
                c.IsWatched = request.IsWatched;
                await _context.SaveChangesAsync();
                model.IsSuccess = true;
                model.Messsage = "WatchList Update Successfully";
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }
        public async Task<Users>  GetUserById(GetUserByIdRequest request)
        {
            Users user = new Users();
            try
            {
                user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);
            }
            catch (Exception ex)
            {

            }
            return user;

        }     
        public async Task<Movies> GetMovieDetailsById(GetMovieDetailsByIdRequest request)
        {
            Movies movie = new Movies();
            try
            {
                movie =await _context.Movies.FirstOrDefaultAsync(x => x.Id == request.Id );
            }
            catch (Exception)
            {

            }
            return movie;
        }

        public List<GetUnWatchedMoviesJobRespose> GetUnWatchedMoviesList()
        {
            List<GetUnWatchedMoviesJobRespose> movies = new List<GetUnWatchedMoviesJobRespose>();
            try
            {
                var getUnwatchedMovies =
            from m in _context.Movies
            join w in _context.Watchlists on new { MovieId = m.Id } equals new { MovieId = w.MovieId } into w_join
            from w in w_join.DefaultIfEmpty()
            join u in _context.Users on new { UserId = w.UserId } equals new { UserId = u.Id } into u_join
            from u in u_join.DefaultIfEmpty()
            where
              w.IsWatched == false &&
              m.FilmRate ==
                (from movie in (
                    (from w0 in _context.Watchlists
                     join m1 in _context.Movies on new { MovieId = w0.MovieId } equals new { MovieId = m1.Id } into m1_join
                     from m1 in m1_join.DefaultIfEmpty()
                     join u2 in _context.Users on new { UserId = w0.UserId } equals new { UserId = u2.Id } into u2_join
                     from u2 in u2_join.DefaultIfEmpty()
                     where
                       w0.IsWatched == false
                     group new { w0, m1 } by new
                     {
                         w0.MovieId,
                         Column1 = m1.MovieId,
                         m1.FilmName,
                         m1.Description,
                         m1.FilmRate
                     } into g
                     where g.Count(p => p.w0.UserId != null) > 3
                     select new
                     {
                         Count = g.Count(p => p.w0.UserId != null),
                         MovieId = g.Key.Column1,
                         FilmName = g.Key.FilmName,
                         Description = g.Key.Description,
                         FilmRate = g.Key.FilmRate
                     }))
                 select new
                 {
                     movie.FilmRate
                 }).Max(p => p.FilmRate)
            select new
            {
                m.FilmName,
                m.Description,
                m.FilmRate,
                Username = u.Username,
                Email = u.Email
            };
                foreach (var movie in getUnwatchedMovies)
                {
                    movies.Add(new GetUnWatchedMoviesJobRespose { Description = movie.Description, Email = movie.Email, FilmName = movie.FilmName, FilmRate = movie.FilmRate, Username = movie.Username });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return movies;
        }
    }
}
