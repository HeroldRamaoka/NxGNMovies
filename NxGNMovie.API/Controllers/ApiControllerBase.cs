using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace NxGNMovie.API.Controllers
{
    [ApiController]
    [Route("api/")]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender _mediator;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
    }
}
