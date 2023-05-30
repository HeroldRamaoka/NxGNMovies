using NxGNMovie.Application.Models.Dtos;
using NxGNMovie.Application.Models.Results;

namespace NxGNMovie.Application.Models.Response
{
    public record GetMoviesResponse(bool Success, string ErrorMessage, List<MovieDto> Movies) : BaseRecordResponse(Success, ErrorMessage);

}
