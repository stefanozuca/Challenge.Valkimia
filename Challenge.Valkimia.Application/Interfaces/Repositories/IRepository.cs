namespace Challenge.Valkimia.Application
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
