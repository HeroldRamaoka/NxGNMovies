using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace NxGNMovie.Application
{
    public abstract class RequestHandler<TRequest, TResult> : RequestHandlerBase, IRequestHandler<TRequest, TResult> where TRequest : IRequest<TResult> where TResult : class, new()
    {
        protected RequestHandler(ILogger logger, IMapper mapper)
            : base(logger, mapper)
        {
        }

        protected abstract Task HandleRequest(TRequest request, TResult result, CancellationToken cancellationToken);

        protected virtual Exception OnException(Exception ex)
        {
            return ex;
        }

        public async Task<TResult> Handle(TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = new TResult();

                await HandleRequest(request, result, cancellationToken).ConfigureAwait(false);

                return result;
            }
            catch (Exception ex)
            {
                var managedException = OnException(ex);
                Logger.LogError(ex, ex.Message);

                throw managedException;
            }
        }
    }
}
