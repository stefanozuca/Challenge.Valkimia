using Challenge.Valkimia.Application;

namespace Challenge.Valkimia.Infrastructure.Models.Application;

public partial class Ciudad : IDataEntity<Guid>
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
