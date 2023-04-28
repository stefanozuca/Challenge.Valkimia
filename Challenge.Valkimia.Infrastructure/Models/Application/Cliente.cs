using Challenge.Valkimia.Application;

namespace Challenge.Valkimia.Infrastructure.Models.Application;

public partial class Cliente : IDataEntity<Guid>
{
    #region Constants

    public const string FullNameClaimType = "cliente:nombrecompleto";

    #endregion

    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Domicilio { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public Guid IdCiudad { get; set; }

    public bool Habilitado { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual Ciudad IdCiudadNavigation { get; set; } = null!;

}
