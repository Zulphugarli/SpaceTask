using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SpaceTask.Model.Database;
using SpaceTask.Model.Request;
using SpaceTask.Model.Response;
using SpaceTask.Model.ViewModel;
using SpaceTask.Services;
using System;

namespace SpaceTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        IConfiguration _configuration;
        IMovieService _movieService;
        public MovieController(IMovieService service, IConfiguration iConfig)
        {
            _configuration = iConfig;
            _movieService = service;
        }

        [HttpPut, Route("addUser")]
        public IActionResult addUser([FromQuery] AddUserRequest request)
        {
            try
            {
                var addUser = _movieService.AddUser(request);
                if (addUser == null)
                    return NotFound();
                return Ok(addUser);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut, Route("addMovie")]
        public IActionResult addMovie([FromQuery] AddMovieRequest request)
        {
            try
            {

                string url = _configuration.GetValue<string>("ImdbApiSearchUrl");
                //Inception: 4Movie Premiere Special
                Movies movie = new Movies();
                var responseJson = Helper.Request.HttpRequest(url + request.MovieName);
                SearchResponse response = JsonConvert.DeserializeObject<SearchResponse>(responseJson);
                if (response.Results.Length > 0)
                {
                    var resultOfRaiting = Helper.Request.HttpRequest(_configuration.GetValue<string>("ImdbApiRatingsUrl") + response.Results[0].Id);
                    RaitingResponse raitingResponse = JsonConvert.DeserializeObject<RaitingResponse>(resultOfRaiting);
                    movie.FilmRate = Convert.ToDecimal(raitingResponse.imDb);
                }
                movie.ImageUrl = response.Results[0].Image;
                movie.MovieId = response.Results[0].Id;
                movie.FilmName = response.Results[0].Title;
                movie.Description = response.Results[0].Description;
                var saveResponse = _movieService.AddMovie(movie);
                if (response == null)
                    return NotFound();
                return Ok(saveResponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut, Route("addWatchlist")]
        public IActionResult AddWatchlist([FromQuery] AddWatchlistRequest request)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                GetUserByIdRequest user = new GetUserByIdRequest { UserId = request.UserId };
                var getUser = _movieService.GetUserById(user);
                if (getUser == null)
                {
                    response.IsSuccess = false;
                    response.Messsage = "User Not Found";
                    return Ok(response);
                }
                else
                {
                    GetMovieDetailsByIdRequest movie = new GetMovieDetailsByIdRequest { Id = request.MovieId };
                    var getMovie = _movieService.GetMovieDetailsById(movie);
                    if (getMovie == null)
                    {
                        response.IsSuccess = false;
                        response.Messsage = "Movie Not Found";
                        return Ok(response);
                    }
                }
                var addWatchList = _movieService.AddWatchList(request);
                response.IsSuccess = true;
                response.Messsage = "Sucessfully added";
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut, Route("updateMovieWatched")]
        public IActionResult UpdateMovieWatched([FromQuery] UpdateMovieWatchedRequest request)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                GetUserByIdRequest user = new GetUserByIdRequest { UserId = request.UserId };
                var getUser = _movieService.GetUserById(user);
                if (getUser == null)
                {
                    response.IsSuccess = false;
                    response.Messsage = "User Not Found";
                    return Ok(response);
                }
                else
                {
                    GetMovieDetailsByIdRequest movie = new GetMovieDetailsByIdRequest { Id = request.MovieId };
                    var getMovie = _movieService.GetMovieDetailsById(movie);
                    if (getMovie == null)
                    {
                        response.IsSuccess = false;
                        response.Messsage = "Movie Not Found";
                        return Ok(response);
                    }
                }


                var getUserList = _movieService.UpdateIsWatched(request);
                if (getUserList == null)
                    return NotFound();
                return Ok(getUserList);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet, Route("search")]
        public IActionResult Search([FromQuery] SearchRequest request)
        {
            try
            {
                string url = _configuration.GetValue<string>("ImdbApiSearchUrl");
                var responseJson = Helper.Request.HttpRequest(url + request.Name);
                var response = JsonConvert.DeserializeObject<SearchResponse>(responseJson);
                if (response == null)
                    return NotFound();
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }       

        [HttpGet, Route("posters")]
        public IActionResult Posters([FromQuery] PosterRequest request)
        {

            try
            {
                //tt1375666
                string url = _configuration.GetValue<string>("ImdbApiPosterUrl");
                var responseJson = Helper.Request.HttpRequest(url + request.Id);
                var response = JsonConvert.DeserializeObject<PostersResponse>(responseJson);
                if (response == null)
                    return NotFound();
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet, Route("wikipedia")]
        public IActionResult Wikipedia([FromQuery] WikipediaRequest request)
        {
            try
            {
                //tt1375666
                string url = _configuration.GetValue<string>("ImdbApiWikipediarUrl");
                var responseJson = Helper.Request.HttpRequest(url + request.Id);
                var response = JsonConvert.DeserializeObject<WikipediaResponse>(responseJson);
                if (response == null)
                    return NotFound();
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet, Route("title")]
        public IActionResult Title([FromQuery] TitleRequest request)
        {
            try
            {
                //tt1375666
                string url = _configuration.GetValue<string>("ImdbApiTitleUrl");
                var responseJson = Helper.Request.HttpRequest(url + request.Id);
                var response = JsonConvert.DeserializeObject<TitleResponse>(responseJson);
                if (response == null)
                    return NotFound();
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }                    
    }
}

