using FluentValidation;
using NxGNMovie.Application.Models.Request;

namespace NxGNMovie.Application.Movie.RequestHandlers
{
    public class CreateMovieValidator : AbstractValidator<CreateMovieRequest>
    {
        public CreateMovieValidator()
        {
            RuleFor(x => x.Name)
              .NotEmpty()
              .WithMessage("Name is required.");
            RuleFor(x => x.Rating)
              .GreaterThan(0)
              .WithMessage("Rating must be greater than 0.");
            RuleFor(x => x.Category)
              .NotEmpty()
              .WithMessage("Category is required.");
        }
    }
}