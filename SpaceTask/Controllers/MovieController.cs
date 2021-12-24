using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SpaceTask.Model.Database;
using SpaceTask.Model.Request;
using SpaceTask.Model.Response;
using SpaceTask.Model.ViewModel;
using SpaceTask.Services;
using System;
using System.Threading.Tasks;

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
        public async Task<ActionResult<ResponseModel>> AddUser([FromQuery] AddUserRequest request)
        {
            try
            {
                var addUser = await _movieService.AddUser(request);
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
        public async Task<ActionResult<ResponseModel>> addMovie([FromQuery] AddMovieRequest request)
        {
            try
            {
                string url = _configuration.GetValue<string>("ImdbApiSearchUrl");
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
                var saveResponse =await _movieService.AddMovie(movie);
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
        public async Task<ActionResult<ResponseModel>> AddWatchlist([FromQuery] AddWatchlistRequest request)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                GetUserByIdRequest user = new GetUserByIdRequest { UserId = request.UserId };
                var getUser = await _movieService.GetUserById(user);
                if (getUser == null)
                {
                    response.IsSuccess = false;
                    response.Messsage = "User Not Found";
                    return Ok(response);
                }
                else
                {
                    GetMovieDetailsByIdRequest movie = new GetMovieDetailsByIdRequest { Id = request.MovieId };
                    var getMovie = await _movieService.GetMovieDetailsById(movie);
                    if (getMovie == null)
                    {
                        response.IsSuccess = false;
                        response.Messsage = "Movie Not Found";
                        return Ok(response);
                    }
                }
                var addWatchList = await _movieService.AddWatchList(request);
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
        public async Task<ActionResult<ResponseModel>> UpdateMovieWatched([FromQuery] UpdateMovieWatchedRequest request)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                GetUserByIdRequest user = new GetUserByIdRequest { UserId = request.UserId };
                var getUser =await _movieService.GetUserById(user);
                if (getUser == null)
                {
                    response.IsSuccess = false;
                    response.Messsage = "User Not Found";
                    return Ok(response);
                }
                else
                {
                    GetMovieDetailsByIdRequest movie = new GetMovieDetailsByIdRequest { Id = request.MovieId };
                    var getMovie =await _movieService.GetMovieDetailsById(movie);
                    if (getMovie == null)
                    {
                        response.IsSuccess = false;
                        response.Messsage = "Movie Not Found";
                        return Ok(response);
                    }
                }


                var responseUpdate =await _movieService.UpdateIsWatched(request);
                if (responseUpdate == null)
                    return NotFound();
                return Ok(responseUpdate);
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

