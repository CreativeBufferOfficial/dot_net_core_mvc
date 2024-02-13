namespace Sample.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id); // Asynchronously retrieves an entity by its unique identifier.
        Task<IEnumerable<T>> GetAll(); // Asynchronously retrieves all entities of type T.
        Task Add(T entity); // Asynchronously adds a new entity to the repository.
        void Delete(T entity); // Deletes the specified entity from the repository.
        void Update(T entity); // Updates the specified entity in the repository.
    }
}