using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyApi.Controllers
{
    [ApiController]
    public class BaseController: ControllerBase
    {
        private ISender _mediator;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
    }
}
