using NxGNMovie.Domain.Entities;

namespace NxGNMovie.Application.Contracts.Interfaces
{
    public interface IMovieRepository
    {
        Task<Movie> GetById(long id);
        Task<Movie> GetByName(string name);
        Task<IEnumerable<Movie>> GetAll();
        Task Add(Movie movie);
        Task Update(Movie movie);
        Task Delete(long id);
    }
}
