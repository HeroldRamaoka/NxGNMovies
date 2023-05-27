using AutoMapper;
using Microsoft.Extensions.Logging;

namespace NxGNMovie.Application
{
    public abstract class QueryRequestHandlerBase : RequestHandlerBase
    {
        public QueryRequestHandlerBase(ILogger logger, IMapper mapper) : base(logger, mapper)
        {
        }
    }
}
