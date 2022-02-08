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
    [ApiController]
    [Route("Houses")]
    public class HousesController : ControllerBase
    {


        private readonly HPDBContext _context;

        public HousesController(HPDBContext hPDBContext)
        {

            _context = hPDBContext;
        }

        // GET: everyone
        [HttpGet]

        public async Task<ActionResult<IEnumerable<House>>> GetHouses()
        {
          
            {
                return await _context.Houses
                    .Include(p => p.Persons)
                    .ToListAsync();
            } 
        }
        // get houses fby name
        [HttpGet("{name}/")]
        public async Task<ActionResult<IEnumerable<House>>> GetHouses(string name)
        {

            {
                return await _context.Houses
                    .Include(p => p.Persons)
                    .Where(p => p.HouseName.Contains(name))
                    .ToListAsync();
            }
        }


    }
}
