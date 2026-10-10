namespace DesignPatterns.RepositoryPattern
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        void Add(T product);
        void Remove(T product);
    }
}
