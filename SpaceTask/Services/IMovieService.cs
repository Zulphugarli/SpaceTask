using SpaceTask.Model.Database;
using SpaceTask.Model.Request;
using SpaceTask.Model.Response;
using SpaceTask.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceTask.Services
{
    public interface IMovieService
    {
        Task<ResponseModel> AddUser(AddUserRequest movie);
        Task<ResponseModel> AddMovie(Movies movie);
        Task<ResponseModel> AddWatchList(AddWatchlistRequest watchlist);
        Task<ResponseModel> UpdateIsWatched(UpdateMovieWatchedRequest movie);
        Task<Users> GetUserById(GetUserByIdRequest movie);
        Task<Movies>  GetMovieDetailsById(GetMovieDetailsByIdRequest movie);
        List<GetUnWatchedMoviesJobRespose> GetUnWatchedMoviesList();
    }
}
