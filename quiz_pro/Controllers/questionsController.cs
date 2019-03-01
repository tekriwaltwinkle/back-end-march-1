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
        private IQuizRepo<question> _context;
        public questionsController(IQuizRepo<question> context) { _context = context;}

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.GetAll());
        }
        [HttpPost]
        public IActionResult Post([FromBody] question value)
        {
           _context.Add(value);
            return Ok();
        }
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            _context.Delete(id);
            return Ok();
        }

       // readonly dbContext context;

       // public questionsController(dbContext context1)
       // {
       //     this.context = context1;
       // }
       
            
            
       //     // GET: api/<controller>
       // [HttpGet]
       // public IEnumerable<Models.question> Get()
       // {
       //     return context.questions;
       // }

       // // GET api/<controller>/5
       // [HttpGet("{quid}")]
       // public IEnumerable<Models.question> Get([FromRoute] int quid)
       // {
       //     return context.questions.Where(q => q.quID == quid);
       //}

       // // POST api/<controller>
       // [HttpPost]
       // public async Task<IActionResult> Post([FromBody]Models.question question)
       // {
       //     var quiz = context.quizs.SingleOrDefault(q => q.qID == question.quID);
       //     if (quiz == null)
       //         return NotFound();

       //     context.questions.Add(question);
       //     await context.SaveChangesAsync();
       //     return Ok(question);
       // }

       // // PUT api/<controller>/5
       // [HttpPut("{id}")]
       // public async Task<IActionResult> Put(int id, [FromBody]Models.question question)
       // {
       //     if (id != question.qID)
       //         return BadRequest();
       //     context.Entry(question).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
       //     await context.SaveChangesAsync();
       //     return Ok(question);
       // }

       // // DELETE api/<controller>/5
       // [HttpDelete("{id}")]
       // public async Task<IActionResult> Delete([FromRoute] int id)
       // {
       //     if (!ModelState.IsValid)
       //     {
       //         return BadRequest(ModelState);
       //     }

       //     var question = await
       //         context.questions.SingleOrDefaultAsync(m => m.quID == id);
       //     if (question == null)
       //     {
       //         return NotFound();
       //     }

       //     context.questions.Remove(question);
       //     await context.SaveChangesAsync();

       //     return Ok(question);
       // }

      
    }
}
