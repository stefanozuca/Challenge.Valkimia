using Challenge.Valkimia.Application;

namespace Challenge.Valkimia.Infrastructure.Models.Application;

public partial class Factura : IDataEntity<Guid>
{
    public Guid Id { get; set; }

    public Guid IdCliente { get; set; }

    public DateTime Fecha { get; set; }

    public string Detalle { get; set; } = null!;

    public decimal Importe { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
