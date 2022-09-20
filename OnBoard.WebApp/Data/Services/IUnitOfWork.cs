namespace OnBoard.WebApp.Data.Services
{
    public interface IUnitOfWork
    {
        int SaveChanges();
    }
}