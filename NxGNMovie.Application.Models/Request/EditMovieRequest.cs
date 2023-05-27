using MediatR;
using NxGNMovie.Application.Models.Response;
using NxGNMovie.Application.Models.Results;

namespace NxGNMovie.Application.Models.Request
{
    public class EditMovieRequest : IRequest<ServiceResult<EditMovieResponse>>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public string Category { get; set; }
    }
}
