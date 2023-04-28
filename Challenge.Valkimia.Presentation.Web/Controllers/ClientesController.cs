using AutoMapper;
using Challenge.Valkimia.Application;
using Challenge.Valkimia.Application.Commands;
using Challenge.Valkimia.Application.Queries;
using Challenge.Valkimia.Presentation.Resources;
using Challenge.Valkimia.Presentation.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Challenge.Valkimia.Presentation.Web.Controllers
{
    [Authorize]
    public class ClientesController : BaseController
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public ClientesController(INotificationService notificationService, IMapper mapper) 
            : base(notificationService)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> LoadData([FromForm] DataTablesParameters parameters) {
            // Getting all users 
            var queryOptions = parameters.ToQueryOptions();
            var usersQuery = await Mediator.Send(new GetAllClientesQuery { Options = queryOptions });

            if (usersQuery.Failed) return null;

            var recordCount = usersQuery.GetMetadata<int>("RecordCount");
            //Returning Json Data  
            return Json(new { draw = parameters.Draw, recordsFiltered = recordCount, recordsTotal = recordCount, data = usersQuery.Data });
        }

        public async Task<IActionResult> Index() {
            return View();
        }

        public async Task<IActionResult> GetAll()
        {
            var usersQuery = await Mediator.Send(new GetAllClientesQuery());
            return Json(usersQuery.Data);
        }

        public async Task<IActionResult> Create() {

            var ciudadesQuery = await Mediator.Send(new GetAllCiudadesQuery());

            ViewData["CiudadID"] = new SelectList(ciudadesQuery, "Id", "Nombre");

            return View(new CreateClienteViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClienteViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var command = _mapper.Map<CreateClienteCommand>(vm);

            var result = await Mediator.Send(command);

            if (result.Succeeded) {
                _notificationService.SuccessNotification($"Cliente creado!");
                return RedirectToAction(nameof(Index));
            }
            else {
                _notificationService.ErrorNotification(result.MessageWithErrors);
                ModelState.AddModelError("", "Fallo la creacion del cliente.");
            }

            return View(vm);
        }
    }
}
