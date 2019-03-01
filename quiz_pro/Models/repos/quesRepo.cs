using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quiz_pro.Models.repos
{
    public class quesRepo : IQuizRepo<question>
    {
        private dbContext _context;
        public quesRepo(dbContext context)
        {
            _context = context;
        }

        public void Add(question Entity)
        {
            try
            {
                _context.questions.Add(Entity);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Delete(int Entity)
        {
            try
            {
                var ques = _context.questions.SingleOrDefault(m => m.quID == Entity);
                _context.questions.Remove(ques);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Update(question Entity)
        {
            try
            {
                question question = _context.questions.Find(Entity.quID);
                question.Text = Entity.Text;
                question.CorrectAnswer = Entity.CorrectAnswer;
                question.Answer1 = Entity.Answer1;
                question.Answer2 = Entity.Answer2;
                question.Answer3 = Entity.Answer3;
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }


        }

        public IEnumerable<question> GetByName(string Text)
        {
            return _context.questions.Where((q) => q.Text == Text).ToList();
        }

        public question GetById(int id)
        {
            return _context.questions.Find(id);
        }

        public IEnumerable<question> GetAll()
        {
            return _context.questions.ToList();
        }
    }
}

