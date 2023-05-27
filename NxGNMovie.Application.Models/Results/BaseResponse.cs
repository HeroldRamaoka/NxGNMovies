namespace NxGNMovie.Application.Models.Results
{
    public abstract class BaseResponse
    {
        public string ErrorMessage { get; set; }
        public bool Success { get; set; }
    }
}
