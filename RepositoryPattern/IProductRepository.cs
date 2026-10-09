namespace DesignPatterns.RepositoryPattern
{
    public interface IProductRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        void Add(T product);
        void Remove(T product);
    }
}
