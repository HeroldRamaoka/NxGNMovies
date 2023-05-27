using AutoMapper;
using Microsoft.Extensions.Logging;
using NxGNMovie.Application.Contracts.Interfaces;
using NxGNMovie.Application.Models.Request;
using NxGNMovie.Application.Models.Response;
using NxGNMovie.Application.Models.Results;

namespace NxGNMovie.Application.Movie.RequestHandlers
{
    public class DeleteMovieHandler : RequestHandler<DeleteMovieRequest, ServiceResult<DeleteMovieResponse>>
    {
        private readonly IMovieRepository _movieRepository;

        public DeleteMovieHandler(ILogger<DeleteMovieRequest> logger, IMapper mapper, IMovieRepository movieRepository) : base(logger, mapper)
        {
            _movieRepository = movieRepository;
        }

        protected override async Task<ServiceResult<DeleteMovieResponse>> HandleRequest(DeleteMovieRequest request, ServiceResult<DeleteMovieResponse> result, CancellationToken cancellationToken)
        {
            result.Result = new DeleteMovieResponse() { Success = true };

            var existingMovie = await _movieRepository.GetById(request.Id).ConfigureAwait(false);

            if (existingMovie == null)
            {
                result.Result.ErrorMessage = "No movie found";
                result.Result.Success = false;
                return result;
            }

            await _movieRepository.Delete(existingMovie.Id);
            return result;
        }
    }
}
