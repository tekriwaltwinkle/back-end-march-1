using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quiz_pro.Models;
using quiz_pro.Models.repos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace quiz_pro.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class questionsController : Controller
    {

        private readonly dbContext _context;
        public questionsController(dbContext context)
        {
            _context = context;
        }


        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<question> Get()
        {
            return _context.questions.ToList();

        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var question = await
                _context.questions.SingleOrDefaultAsync(m => m.qID == id);

            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        // POST api/<controller>
        [HttpPost]
        public IEnumerable<question> Post([FromBody] question question)
        {


            _context.questions.Add(question);
            _context.SaveChanges();


            return _context.questions.ToList();

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] question question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != question.qID)
            {
                return BadRequest();
            }

            _context.Entry(question).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizExists(id))
                {
                    return NotFound();

                }
                else
                {
                    throw;
                }
            }
            return NotFound();

        }



        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var question = await
                _context.quizs.SingleOrDefaultAsync(m => m.qID == id);
            if (question == null)
            {
                return NotFound();
            }

            _context.quizs.Remove(question);
            await _context.SaveChangesAsync();

            return Ok(question);
        }

        private bool QuizExists(int id)
        {
            return _context.quizs.Any(e => e.qID == id);
        }
    }
}
