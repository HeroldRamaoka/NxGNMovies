using NxGNMovie.Domain.Exceptions;

namespace NxGNMovie.Domain.Validation
{
    public static class ValueBasedValidation
    {
        public static string ValidateString(this string text, int minimumValue, int maximumValue, string name, bool allowNull = false)
        {
            if (minimumValue > 0 && string.IsNullOrWhiteSpace(text) && !allowNull)
            {
                throw new DomainValidationException("Invalid value. Value cannot be null.", name);
            }
            if (!string.IsNullOrWhiteSpace(text) && text.Length > maximumValue)
            {
                throw new DomainValidationException($"Invalid value. Length cannot exceed {maximumValue}.", name);
            }
            if (!string.IsNullOrWhiteSpace(text) && text.Length < minimumValue)
            {
                throw new DomainValidationException($"Invalid value. Length cannot be less then {minimumValue}.", name);
            }

            return text;
        }
    }
}
