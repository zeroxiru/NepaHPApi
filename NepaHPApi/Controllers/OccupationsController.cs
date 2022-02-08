using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NepaHPApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NepaHPApi.Controllers
{
    [ApiController]
    [Route("ghosts")]
    public class OccupationsController : ControllerBase
    {
        private readonly HPDBContext _context;

        public OccupationsController(HPDBContext hPDBContext)
        {

            _context = hPDBContext;
        }

         // get occupation data by id
        [HttpGet("{id:int}/")]
        public async Task<ActionResult<IEnumerable<Occupation>>> GetOccupation(int id)
        {
            try
            {
                var result = await _context.Occupations
                        .Include(p => p.Persons)
                        .Where(p => p.OccupationId == id).ToListAsync();

                if (result == null)
                {
                    return NotFound();
                }
                return result;

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                  "Error in retriving data from Database");
            }
           
        }

        //// get occupation data by namae
        [HttpGet("{name}/")]
        public async Task<ActionResult<IEnumerable<Occupation>>> GetGhosts(string name)
        {

            {

                return await _context.Occupations
                    .Include(p => p.Persons)
                  
                    .Where(p => p.OccupationName.Contains(name))
                    .ToListAsync();


            }
        }


    }
}
