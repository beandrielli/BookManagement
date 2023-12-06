using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Interfaces
{

    public interface IRepository<TEntity> where TEntity : class { 
    
        TEntity? GetById(int id);

        IEnumerable<TEntity> GetAll();

        TEntity? GetByName(string name);

        void Save(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
