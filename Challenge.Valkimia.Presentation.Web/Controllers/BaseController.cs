using Challenge.Valkimia.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Valkimia.Presentation.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly INotificationService NotificationService;
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public BaseController(INotificationService notificationService)
        {
            NotificationService = notificationService;
        }
    }
}
