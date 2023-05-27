using AutoMapper;

namespace NxGNMovie.Application.Models.Mappings
{
    public interface IHaveCustomMapping
    {
        void CreateMappings(Profile configuration);
    }
}
