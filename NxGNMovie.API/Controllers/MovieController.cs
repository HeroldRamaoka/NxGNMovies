using Microsoft.AspNetCore.Mvc;
using NxGNMovie.Application.Models.Request;
using NxGNMovie.Application.Models.Response;
using NxGNMovie.Application.Models.Results;
using NxGNMovie.Application.Movie.QueryHandlers;

namespace NxGNMovie.API.Controllers
{
    [Route("api/[controller]")]
    public class MovieController : ApiControllerBase
    {
        [HttpGet]
        [Route("get/movie")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ServiceResult<GetMovieResponse>>> GetMovie(long id)
        {
            return await Mediator.Send(new GetMovieRequest() { Id = id }).ConfigureAwait(false);
        }

        [HttpGet]
        [Route("get/movies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ServiceResult<GetMoviesResponse>>> GetMovies()
        {
            return await Mediator.Send(new GetMoviesRequest()).ConfigureAwait(false);
        }

        [HttpPost]
        [Route("add/movie")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ServiceResult<CreateMovieResponse>>> AddCustomer(CreateMovieRequest request)
        {
            return await Mediator.Send(request).ConfigureAwait(false);
        }

        [HttpPut]
        [Route("edit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ServiceResult<EditMovieResponse>>> Edit(EditMovieRequest request)
        {
            return await Mediator.Send(request).ConfigureAwait(false);
        }

        [HttpDelete]
        [Route("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ServiceResult<DeleteMovieResponse>>> Detele(DeleteMovieRequest request)
        {
            return await Mediator.Send(new DeleteMovieRequest() { Id = request.Id }).ConfigureAwait(false);
        }
    }
}
