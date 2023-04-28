namespace Challenge.Valkimia.Infrastructure.Services
{
    public interface IDbInitializerService
    {
        void Migrate();
        void Seed();
    }
}
