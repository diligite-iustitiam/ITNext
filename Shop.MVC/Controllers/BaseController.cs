using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebProjectOnAzure.Controllers
{
    public abstract class BaseController : Controller
    {
        private IMediator? _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
