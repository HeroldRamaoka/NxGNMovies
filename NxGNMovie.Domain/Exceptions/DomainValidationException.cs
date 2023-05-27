namespace NxGNMovie.Domain.Exceptions
{
    public class DomainValidationException : ArgumentException
    {
        public DomainValidationException(string message, string parameterName) : base(message, parameterName) { }
    }
}
