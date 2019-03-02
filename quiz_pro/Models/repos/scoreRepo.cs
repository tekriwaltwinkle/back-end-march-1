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

        public void Add(score Entity)
        {
            try
            {
                _context.scores.Add(Entity);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Delete(score Entity)
        {
            try
            {
                _context.scores.Remove(Entity);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Update(score Entity)
        {
            try
            {
                score score = _context.scores.Find(Entity.scoreId);
                score.username = Entity.username;
                score.title = Entity.title;
                score.marks = Entity.marks;
                score.date = Entity.date;
                score.uID = Entity.uID;
                score.qID = Entity.qID;
        


        _context.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }


        }

        public IEnumerable<score> GetByName(string Title)
        {
            return _context.scores.Where((q) => q.username == Title).ToList();
        }

        public score GetById(int id)
        {
            return _context.scores.Find(id);
        }

        public IEnumerable<score> GetAll()
        {
            return _context.scores.ToList();
        }
    }
}
