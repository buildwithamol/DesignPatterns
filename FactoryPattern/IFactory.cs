using DesignPatterns.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.FactoryPattern
{
    public interface IFactory
    {
        public IRepository<T> getRespository<T>(AppDbContext appDbContext) where T : class;
    }
}
