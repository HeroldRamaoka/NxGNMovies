using AutoMapper;
using Microsoft.Extensions.Logging;
using NxGNMovie.Application.Constant;
using NxGNMovie.Application.Contracts.Interfaces;
using NxGNMovie.Application.Models.Request;
using NxGNMovie.Application.Models.Response;
using NxGNMovie.Application.Models.Results;
using NxGNMovie.Domain.Common;

namespace NxGNMovie.Application.Movie.RequestHandlers
{
    public class EditMovieHandler : RequestHandler<EditMovieRequest, ServiceResult<EditMovieResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;

        public EditMovieHandler(ILogger<EditMovieRequest> logger, IMapper mapper, IMovieRepository movieRepository) : base(logger, mapper)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        protected override async Task<ServiceResult<EditMovieResponse>> HandleRequest(EditMovieRequest request, ServiceResult<EditMovieResponse> result, CancellationToken cancellationToken)
        {
            result.Result = new EditMovieResponse() { Success = true };

            var existingMovie = await _movieRepository.GetById(request.Id).ConfigureAwait(false);

            if (existingMovie == null)
            {
                result.Result.ErrorMessage = "No movie found";
                result.Result.Success = false;
                return result;
            }

            var entity = new Domain.Entities.Movie
            {
                Id = existingMovie.Id,
                Name = request.Name,
                Rating = request.Rating,
                Category = request.Category,
                Modified = new Domain.ValueObjects.Modified(Constants.AdminUser),
            };

            await _movieRepository.Update(entity);

            return result;
        }
    }
}
