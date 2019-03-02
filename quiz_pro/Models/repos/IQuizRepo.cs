using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quiz_pro.Models.repos
{
  public interface IQuizRepo<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetByName(string Name);
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);

    }
}
