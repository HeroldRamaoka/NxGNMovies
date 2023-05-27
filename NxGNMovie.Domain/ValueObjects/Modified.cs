using NxGNMovie.Domain.Common;
using NxGNMovie.Domain.Validation;

namespace NxGNMovie.Domain.ValueObjects
{
    public record Modified : ValueObject
    {
        private Modified() { }

        public string ModifiedBy { get; private set; }

        public DateTimeOffset ModifiedDate { get; private set; }

        public Modified(string modifiedBy)
        {
            ModifiedBy = modifiedBy.ValidateString(0, 200, nameof(modifiedBy));
            ModifiedDate = DateTimeOffset.UtcNow;
        }
    }
}
