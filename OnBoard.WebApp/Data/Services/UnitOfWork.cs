namespace OnBoard.WebApp.Data.Services
{
    /// <summary>
    /// Unit of Work to allow one database context to be in scope
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataModelDbContext _context;

        public UnitOfWork(DataModelDbContext context)
        {
            _context = context;

        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
