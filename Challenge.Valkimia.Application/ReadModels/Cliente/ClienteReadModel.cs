namespace Challenge.Valkimia.Application.ReadModels
{
    public class ClienteReadModel
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; } 

        public string Apellido { get; set; } 

        public string Domicilio { get; set; } 

        public string Email { get; set; }

        public string NombreCiudad { get; set; }

        public int CantidadFacturas { get; set; }
    }
}
