using Sample.DAL.DBContext;
using Sample.DAL.Interfaces;
using Sample.DAL.Migrations;

namespace Sample.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _dbContext; // Database context instance.
        public IProductRepository ProductDetails { get; } // Repository for managing product entities.

        // Constructor for UnitOfWork class.
        public UnitOfWork(ApplicationDBContext dbContext, IProductRepository productRepository)
        {
            _dbContext = dbContext; // Initialize the database context.
            ProductDetails = productRepository; // Initialize the product repository.
        }

        // Save changes made in the current unit of work to the underlying database.
        public int Save()
        {
            return _dbContext.SaveChanges(); // Return the number of affected rows after saving changes.
        }

        // Dispose method implementation for releasing resources.
        public void Dispose()
        {
            Dispose(true); // Call the overloaded Dispose method.
            GC.SuppressFinalize(this); // Suppress finalization to improve performance.
        }

        // Overloaded Dispose method to release managed resources.
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose(); // Dispose the database context to release managed resources.
            }
        }
    }
}