using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quiz_pro.Models.repos
{
    public class scoreRepo : IQuizRepo<score>
    {
        private dbContext _context;
        public scoreRepo(dbContext context)
        {
            _context = context;
        }

        public void Add(score entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<score> GetAll()
        {
            throw new NotImplementedException();
        }

        public score GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<score> GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public void Update(score entity)
        {
            throw new NotImplementedException();
        }
    }
}
