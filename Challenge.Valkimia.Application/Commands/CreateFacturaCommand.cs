using Challenge.Valkimia.Domain.Entities;
using MediatR;

namespace Challenge.Valkimia.Application.Commands
{
    //public class CreateFacturaCommand : IRequest<Guid>
    //{
    //    public Guid IdCliente { get; set; }
    //    public DateTime Fecha { get; set; }
    //    public string Detalle { get; set; }
    //    public decimal Importe { get; set; }

    //    public class CreateFacturaCommandHandler : IRequestHandler<CreateFacturaCommand, Guid>
    //    {
    //        //private readonly IApplicationDbContext _context;
    //        //public CreateFacturaCommandHandler(IApplicationDbContext context)
    //        //{
    //        //    _context = context;
    //        //}

    //        public async Task<Guid> Handle(CreateFacturaCommand request, CancellationToken cancellationToken)
    //        {
                
    //            var factura = new Factura();
    //            //factura.IdCliente = request.IdCliente;
    //            //factura.Fecha = request.Fecha;
    //            //factura.Detalle = request.Detalle;
    //            //factura.Importe = request.Importe;

    //            //_context.Facturas.Add(factura);
    //            //await _context.SaveChangesAsync();
    //            return factura.Id;
    //        }
    //    }
    //}
}
