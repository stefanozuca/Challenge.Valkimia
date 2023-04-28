namespace Challenge.Valkimia.Domain.Entities;

public class Factura : IEntity<Guid>
{
    public Guid Id { get; set; }

    public Guid IdCliente { get; set; }

    public DateTime Fecha { get; set; }

    public string Detalle { get; set; } = null!;

    public decimal Importe { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
