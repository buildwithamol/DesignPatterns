using DesignPatterns.RepositoryPattern;

namespace DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create and use the EF Core DB context. 'using var' ensures disposal
            // of the context when Main exits.
            using var context = new AppDbContext();

            // Create the repository that wraps data access for Product entities.
            var repository = new ProductRepository(context);

            // Add products (synchronous API used for simplicity here).
            // In a real app prefer async and avoid blocking on async calls (.Result).
            repository.Add(new Product { Id = 1, Name = "Laptop", Price = 75000 });
            repository.Add(new Product { Id = 2, Name = "Mouse", Price = 500 });

            // Fetch all products from the repository.
            // NOTE: repository.GetAllAsync() returns a Task; accessing .Result blocks
            // the current thread. Prefer async Main + await in production code.
            var products = repository.GetAllAsync().Result;

            Console.WriteLine("Products in DB:");
            foreach (var p in products)
            {
                // Print each product's Id, Name and Price using string interpolation.
                Console.WriteLine($"{p.Id} - {p.Name} - {p.Price}");
            }

            // Fetch by Id (again using .Result for brevity in this demo).
            var product = repository.GetByIdAsync(1).Result;
            Console.WriteLine($"\nFetched: {product?.Name} - {product?.Price}");
        }
    }
}
