using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NepaHPApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace NepaHPApi.Controllers
{

    [Route("everyone")]
    [ApiController]
    public class PersonalsController :ControllerBase
    {

        private readonly HPDBContext _context;

        public PersonalsController(HPDBContext hPDBContext) {

            _context = hPDBContext;
        }

        // GET: everyone
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetEveryOne()
        {
            //await Task.Delay(3000);
            return await _context.Persons
                .Include(h => h.House)
                 .Include(p => p.Occupation)
                 .AsNoTracking()
                .ToListAsync();
            
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Person>> GetPersonById(int id)
        {
            var author = await _context.Persons.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }


        [HttpGet("{search}/")]
        public async Task<ActionResult> SearchByName(string q)
        {
            try
            {
                var result = from m in _context.Persons select m;
                if (!String.IsNullOrEmpty(q))
                {
                    result = result.Where(p => p.FirstName.Contains(q) || p.MiddleName.Contains(q) || p.LastName.Contains(q));
                }  
                return Ok(result.ToList());

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  "Error in retriving data from Database ");
            }

        }

        

    }
}
