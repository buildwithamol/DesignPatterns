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
           FactoryPattern.Factory factory = new FactoryPattern.Factory();
          
            var product = factory.getRespository<Product>(context);
            var user = factory.getRespository<User>(context);

            // Add products (synchronous API used for simplicity here).
            // In a real app prefer async and avoid blocking on async calls (.Result).
            product.Add(new Product { Id = 1, Name = "Laptop", Price = 75000 });
            product.Add(new Product { Id = 2, Name = "Mouse", Price = 500 });
          
            
            user.Add(new User { Id = 1, Name = "John Doe" });
            user.Add(new User { Id = 2, Name = "Jane Smith"});

            // Fetch all products from the repository.
            // NOTE: repository.GetAllAsync() returns a Task; accessing .Result blocks
            // the current thread. Prefer async Main + await in production code.
            var products = product.GetAllAsync().Result;

            var users = user.GetAllAsync().Result;

            Console.WriteLine("Products in DB:");
            foreach (var p in products)
            {
                // Print each product's Id, Name and Price using string interpolation.
                Console.WriteLine($"{p.Id} - {p.Name} - {p.Price}");
            }
            Console.WriteLine("---------------------------------------------------------");
            foreach (var u in users)
            {
                // Print each user's Id and Name using string interpolation.
                Console.WriteLine($"{u.Id} - {u.Name}");
            }

            // Fetch by Id (again using .Result for brevity in this demo).
            var productss = product.GetByIdAsync(1).Result;

            var usersk = user.GetByIdAsync(1).Result;

           Console.WriteLine($"\nFetched Product: {productss?.Name} - {productss?.Price}");
           Console.WriteLine($"\nFetched User: {usersk?.Name}");
        }
    }
}
