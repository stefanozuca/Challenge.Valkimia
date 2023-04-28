using Challenge.Valkimia.Common;
using Challenge.Valkimia.Domain.Entities;
using MediatR;

namespace Challenge.Valkimia.Application.Commands
{
    public class CreateClienteCommand : IRequest<Result>
    {

        public CreateClienteCommand()
        {

        }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Domicilio { get; set; }
        public string CiudadID { get; set; }
        public bool Habilitado { get; set; }

        public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, Result>
        {
            private readonly IApplicationUserService _applicationUserService;
            private readonly IClienteRepository _clienteRepository;
            private readonly ICiudadRepository _ciudadRepository;

            public CreateClienteCommandHandler(IApplicationUserService applicationUserService, 
                IClienteRepository clienteRepository,
                ICiudadRepository ciudadRepository)
            {
                _applicationUserService = applicationUserService;
                _clienteRepository = clienteRepository;
                _ciudadRepository = ciudadRepository;
            }

            public async Task<Result> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
            {
                var cliente = new Cliente(request.Apellido, request.Nombre, request.Email);
                cliente.Domicilio = request.Domicilio;
                cliente.Habilitado = request.Habilitado;
                cliente.IdCiudadNavigation = await _ciudadRepository.GetFirstAsync(ciudad => ciudad.Id == Guid.Parse(request.CiudadID));

                var resultUserIdentity = await _applicationUserService.CreateUser(cliente, request.Password, new List<string> { "User" }, true);
            
                if (resultUserIdentity.Failed)
                    return new Result().Failed().WithError(resultUserIdentity.MessageWithErrors);

                _clienteRepository.Add(cliente);

                await _clienteRepository.UnitOfWork.SaveChangesAsync();
                return new Result().Successful();

            }
        }
    }
}
