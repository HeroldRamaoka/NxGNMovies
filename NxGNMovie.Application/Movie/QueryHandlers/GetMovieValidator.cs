using FluentValidation;
using NxGNMovie.Application.Models.Request;

namespace NxGNMovie.Application.Movie.QueryHandlers
{
    public class GetMovieValidator : AbstractValidator<GetMovieRequest>
    {
        public GetMovieValidator()
        {
            RuleFor(x => x.Id)
              .NotEmpty()
              .WithMessage("Id is required.");
        }
    }
}