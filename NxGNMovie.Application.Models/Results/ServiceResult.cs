namespace NxGNMovie.Application.Models.Results
{
    public class ServiceResult<T> where T : class
    {
        public T Result { get; set; }
    }
}
