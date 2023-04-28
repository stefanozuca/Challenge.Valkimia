namespace Challenge.Valkimia.Domain.Entities;

public class Ciudad : IEntity<Guid>
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
