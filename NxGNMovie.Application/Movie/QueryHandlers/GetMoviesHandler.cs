using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NxGNMovie.Application.Contracts.Interfaces;
using NxGNMovie.Application.Models.Dtos;
using NxGNMovie.Application.Models.Response;
using NxGNMovie.Application.Models.Results;

namespace NxGNMovie.Application.Movie.QueryHandlers
{
    public class GetMoviesRequest : IRequest<ServiceResult<GetMoviesResponse>>
    {
    }

    public class GetMoviesHandler : RequestHandler<GetMoviesRequest, ServiceResult<GetMoviesResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;

        public GetMoviesHandler(ILogger<GetMoviesRequest> logger, IMapper mapper, IMovieRepository movieRepository) : base(logger, mapper)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        protected override async Task<ServiceResult<GetMoviesResponse>> HandleRequest(GetMoviesRequest request, ServiceResult<GetMoviesResponse> result, CancellationToken cancellationToken)
        {
            var movies = await _movieRepository.GetAll().ConfigureAwait(false);

            result.Result = new(true, default, _mapper.Map<List<MovieDto>>(movies));

            return result;
        }
    }
}
