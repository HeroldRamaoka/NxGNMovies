using AutoMapper;
using Microsoft.Extensions.Logging;

namespace NxGNMovie.Application
{
    public abstract class RequestHandlerBase
    {
        protected readonly ILogger Logger;
        protected readonly IMapper Mapper;

        public RequestHandlerBase(ILogger logger, IMapper mapper)
        {
            Logger = logger;
            Mapper = mapper;
        }
    }
}
