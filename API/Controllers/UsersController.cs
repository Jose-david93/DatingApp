using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> Get()
        {
            return Ok( await _context.Users.ToListAsync());
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> Get(int id)
        {
            return Ok(await _context.Users.FirstOrDefaultAsync(x => x.Id == id));
        }
    }
}
