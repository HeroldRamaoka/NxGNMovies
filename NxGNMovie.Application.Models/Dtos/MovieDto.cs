using AutoMapper;
using NxGNMovie.Application.Models.Mappings;
using NxGNMovie.Domain.Entities;

namespace NxGNMovie.Application.Models.Dtos
{
    public class MovieDto : IHaveCustomMapping
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public string Category { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Movie, MovieDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(c => c.Name))
                .ForMember(dto => dto.Rating, opt => opt.MapFrom(c => c.Rating))
                .ForMember(dto => dto.Category, opt => opt.MapFrom(c => c.Category));
        }
    }
}
