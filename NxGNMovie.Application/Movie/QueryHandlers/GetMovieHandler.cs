using AutoMapper;
using Microsoft.Extensions.Logging;
using NxGNMovie.Application.Contracts.Interfaces;
using NxGNMovie.Application.Models.Dtos;
using NxGNMovie.Application.Models.Request;
using NxGNMovie.Application.Models.Response;
using NxGNMovie.Application.Models.Results;

namespace NxGNMovie.Application.Movie.QueryHandlers
{
    public class GetMovieHandler : RequestHandler<GetMovieRequest, ServiceResult<GetMovieResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;

        public GetMovieHandler(ILogger<GetMovieRequest> logger, IMapper mapper, IMovieRepository movieRepository) : base(logger, mapper)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        protected override async Task<ServiceResult<GetMovieResponse>> HandleRequest(GetMovieRequest request, ServiceResult<GetMovieResponse> result, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetById(request.Id).ConfigureAwait(false);

            result.Result = new(true, default, _mapper.Map<MovieDto>(movie));

            return result;
        }
    }
}
