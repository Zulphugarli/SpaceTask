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
        ResponseModel AddUser(AddUserRequest movie);
        ResponseModel AddMovie(Movies movie);
        ResponseModel AddWatchList(AddWatchlistRequest watchlist);
        ResponseModel UpdateIsWatched(UpdateMovieWatchedRequest movie);
        Users GetUserById(GetUserByIdRequest movie);
        Movies GetMovieDetailsById(GetMovieDetailsByIdRequest movie);
        List<GetUnWatchedMoviesJobRespose> GetUnWatchedMoviesList();
    }
}
