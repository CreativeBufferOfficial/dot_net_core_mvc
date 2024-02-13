namespace Sample.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets the repository for managing product entities.
        /// </summary>
        IProductRepository ProductDetails { get; }

        /// <summary>
        /// Saves changes made in the unit of work to the underlying database.
        /// </summary>
        /// <returns>The number of objects written to the underlying database.</returns>
        int Save();
    }
}
