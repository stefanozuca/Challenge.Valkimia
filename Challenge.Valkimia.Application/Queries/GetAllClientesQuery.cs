using AutoMapper;
using Challenge.Valkimia.Application.ReadModels;
using Challenge.Valkimia.Common;
using MediatR;

namespace Challenge.Valkimia.Application.Queries
{
    public class GetAllClientesQuery : IRequest<Result<IEnumerable<ClienteReadModel>>>
    {
        public QueryOptions Options { get; set; } 

        public class GetAllClientesQueryHandler : IRequestHandler<GetAllClientesQuery, Result<IEnumerable<ClienteReadModel>>>
        {
            private readonly IMapper _mapper;
            private readonly IClienteRepository _clienteRepository;

            public GetAllClientesQueryHandler(IMapper mapper,
                IClienteRepository clienteRepository
                ) {
                _mapper = mapper;
                _clienteRepository = clienteRepository;
            }

            public async Task<Result<IEnumerable<ClienteReadModel>>> Handle(GetAllClientesQuery request, CancellationToken cancellationToken)
            {
                var result = new Result<IEnumerable<ClienteReadModel>>();

                var getClientesResult = await _clienteRepository.GetAllClientes(request.Options);

                if (getClientesResult.Failed)
                    result.Failed();
                else
                {
                    var data = _mapper.Map<IEnumerable<ClienteReadModel>>(getClientesResult.Data);

                    result.Successful().WithData(data);
                    result.AddMetadata("RecordCount", data.Count());
                }

                return result;
            }
        }
    }
}
