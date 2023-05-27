using NxGNMovie.Application.Models.Dtos;
using NxGNMovie.Application.Models.Results;

namespace NxGNMovie.Application.Models.Response
{
    public record GetMovieResponse(bool Success, string ErrorMessage, MovieDto Movie) : BaseRecordResponse(Success, ErrorMessage);

}
