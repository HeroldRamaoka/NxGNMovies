using NxGNMovie.Domain.Common;
using NxGNMovie.Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace NxGNMovie.Domain.ValueObjects
{
    public record Created : ValueObject
    {
        private Created() { }

        [Required]
        public string Author { get; set; }

        [Required]
        public DateTimeOffset CreatedDate { get; set; }

        public Created(string author, DateTimeOffset? createdDate = default)
        {
            Author = author.ValidateString(1, 200, nameof(author));

            if (createdDate != default)
            {
                CreatedDate = createdDate.Value;
            }
            else
            {
                CreatedDate = DateTimeOffset.UtcNow;
            }
        }
    }
}
