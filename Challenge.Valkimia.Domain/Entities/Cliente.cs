namespace Challenge.Valkimia.Domain.Entities;

public class Cliente : IEntity<Guid>
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Domicilio { get; set; } = null!;

    public string Email { get; private set; } = null!;

    public string Password { get; set; } = null!;

    public Guid IdCiudad { get; set; }

    public bool Habilitado { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual Ciudad IdCiudadNavigation { get; set; } = null!;

    private Cliente() { }

    public Cliente(string lastname, string name, string email)
    {
        Apellido = lastname;
        Nombre = name;
        Email = email;
    }
}
