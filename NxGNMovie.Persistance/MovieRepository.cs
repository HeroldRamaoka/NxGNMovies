using Dapper;
using Microsoft.VisualBasic;
using NxGNMovie.Application.Contracts.Interfaces;
using NxGNMovie.Domain.Entities;

namespace NxGNMovie.Persistance
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MovieRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Movie> GetById(long id)
        {
            const string query = "SELECT * FROM Movies WHERE Id = @Id";
            
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<Movie>(query, new { Id = id });
            }
        }

        public async Task<Movie> GetByName(string name)
        {
            const string query = "SELECT * FROM Movies WHERE Name = @name";

            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<Movie>(query, new { Name = name });
            }
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            const string query = "SELECT * FROM Movies";
            using (var connection = _dbContext.CreateConnection())
            {
                var movies = await connection.QueryAsync<Movie>(query);

                return movies.ToList();
            }
        }

        public async Task Add(Movie movie)
        {
            const string query = "INSERT INTO Movies (Name, Category, Rating, CreatedDate, Author) VALUES (@Name, @Category, @Rating, @CreatedDate, @Author)";
            using (var connection = _dbContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, new
                {
                    Name = movie.Name,
                    Category = movie.Category,
                    Rating = movie.Rating,
                    CreatedDate = movie.Created.CreatedDate,
                    Author = movie.Created.Author
                });
            }
        }

        public async Task Update(Movie movie)
        {
            const string query = "UPDATE Movies SET Name = @Name, Category = @Category, Rating = @Rating, ModifiedDate = @ModifiedDate, ModifiedBy = @ModifiedBy WHERE Id = @Id";

            using (var connection = _dbContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, new
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    Category = movie.Category,
                    Rating = movie.Rating,
                    ModifiedDate = movie.Modified.ModifiedDate,
                    ModifiedBy = movie.Modified.ModifiedBy
                });
            }
        }

        public async Task Delete(long id)
        {
            const string query = "DELETE FROM Movies WHERE Id = @Id";
            using (var connection = _dbContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}
