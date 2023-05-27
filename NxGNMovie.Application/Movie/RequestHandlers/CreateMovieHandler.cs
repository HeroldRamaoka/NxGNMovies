using AutoMapper;
using Microsoft.Extensions.Logging;
using NxGNMovie.Application.Contracts.Interfaces;
using NxGNMovie.Application.Models.Request;
using NxGNMovie.Application.Models.Response;
using NxGNMovie.Application.Models.Results;
using NxGNMovie.Application.Constant;

namespace NxGNMovie.Application.Movie.RequestHandlers
{
    public class CreateMovieHandler : RequestHandler<CreateMovieRequest, ServiceResult<CreateMovieResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;

        public CreateMovieHandler(ILogger<CreateMovieRequest> logger, IMapper mapper, IMovieRepository movieRepository) : base(logger, mapper)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        protected override async Task<ServiceResult<CreateMovieResponse>> HandleRequest(CreateMovieRequest request, ServiceResult<CreateMovieResponse> result, CancellationToken cancellationToken)
        {
            result.Result = new CreateMovieResponse() { Success = true };
            var existingMovie = await _movieRepository.GetByName(request.Name).ConfigureAwait(false);

            if (existingMovie != null)
            {
                result.Result.ErrorMessage = $"Movie named {request.Name} already exist";
                result.Result.Success = false;
                return result;
            }

            var entity = new Domain.Entities.Movie
            {
                Name = request.Name,
                Rating = request.Rating,
                Category = request.Category,
                Created = new Domain.ValueObjects.Created(Constants.AdminUser),
            };

            await _movieRepository.Add(entity);
            return result;
        }
    }
}
