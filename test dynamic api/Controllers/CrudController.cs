using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test_dynamic_api.Models;

namespace test_dynamic_api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        public readonly DataContext _context;
        public CrudController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetUser")]
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(await _context.User.ToListAsync());
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult<List<User>>> Post(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return await _context.User.ToListAsync();
        }

        [HttpPost("UpdateUser")]
        public async Task<ActionResult<List<User>>> update(User user)
        {
            var data = await _context.User.FindAsync(user.Id);
            if (data == null)
                return BadRequest("Data Not Found");

            data.FirstName = user.FirstName;
            data.LastName = user.LastName;
            data.Age = user.Age;
            data.City = user.City;

            await _context.SaveChangesAsync();
            return Ok(await _context.User.ToListAsync());
        }
    }
}
