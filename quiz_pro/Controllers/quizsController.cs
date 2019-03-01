using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quiz_pro.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace quiz_pro.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class quizsController : Controller
    {
        private readonly dbContext _context;
        public quizsController(dbContext context)
        {
            _context = context;
        }


        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<quiz> Get()
        {
            return _context.quizs.ToList();

        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quiz = await
                _context.quizs.SingleOrDefaultAsync(m => m.qID == id);

            if (quiz == null)
            {
                return NotFound();
            }
            return Ok(quiz);
        }

        // POST api/<controller>
        [HttpPost]
        public IEnumerable<quiz> Post([FromBody] quiz quiz)
        {
            

            _context.quizs.Add(quiz);
            _context.SaveChanges();


            return _context.quizs.ToList();

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] quiz quiz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id!= quiz.qID)
            {
                return BadRequest();
            }

            _context.Entry(quiz).State = EntityState.Modified;

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
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quiz = await
                _context.quizs.SingleOrDefaultAsync(m => m.qID == id);
            if (quiz == null)
            {
                return NotFound();
            }

            _context.quizs.Remove(quiz);
            await _context.SaveChangesAsync();

            return Ok(quiz);
        }

        private bool QuizExists(int id)
        {
            return _context.quizs.Any(e => e.qID == id);
        }
    }
}
