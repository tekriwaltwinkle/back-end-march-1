using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quiz_pro.Models.repos
{
    public class quizRepo : IQuizRepo<quiz>
    {
        private dbContext _context;

       

        public quizRepo(dbContext context)
        {
            _context = context;
        }

        public void Add(quiz Entity)
        {
            try
            {
                _context.quizs.Add(Entity);
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Delete(int Entity)
        {
        //    try
        //    {
        //        _context.quizs.Remove(Entity);
        //        _context.SaveChanges();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        }

        public void Update(quiz Entity)
        {
            try
            {
                quiz quiz = _context.quizs.Find(Entity.qID);
                quiz.Title = Entity.Title;
               
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }


        }

        public IEnumerable<quiz>GetByName(string Title)
        {
            return _context.quizs.Where((q) => q.Title == Title).ToList();
        }

        public quiz GetById(int id)
        {
            return _context.quizs.Find(id);
        }

        public IEnumerable<quiz>GetAll()
        {
            return _context.quizs.ToList();
        }
    }
}
