using DesignPatterns.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.FactoryPattern
{
    public class Factory : IFactory
    {
    
        public IRepository<T> getRespository<T>(AppDbContext appDbContext) where T : class
        {
            
            if (typeof(T) == typeof(Product))
            {
                return (IRepository<T>)new ProductRepository(appDbContext);
            }
            else if (typeof(T) == typeof(User))
            {
                return (IRepository<T>)new UserRepository(appDbContext);
            }
            else
            {
                throw new NotSupportedException($"Repository for type {typeof(T).Name} is not supported.");
            }
        }
    }
}
