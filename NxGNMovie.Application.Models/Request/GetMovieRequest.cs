using MediatR;
using NxGNMovie.Application.Models.Response;
using NxGNMovie.Application.Models.Results;

namespace NxGNMovie.Application.Models.Request
{
    public class GetMovieRequest : IRequest<ServiceResult<GetMovieResponse>>
    {
        public long Id { get; set; }
    }
}
