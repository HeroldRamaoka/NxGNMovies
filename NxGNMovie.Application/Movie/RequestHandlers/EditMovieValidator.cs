using FluentValidation;
using NxGNMovie.Application.Models.Request;

namespace NxGNMovie.Application.Movie.RequestHandlers
{
    public class EditMovieValidator : AbstractValidator<EditMovieRequest>
    {
        public EditMovieValidator()
        {
            RuleFor(x => x.Id)
              .GreaterThan(0)
              .WithMessage("Id is required.");
        }
    }
}