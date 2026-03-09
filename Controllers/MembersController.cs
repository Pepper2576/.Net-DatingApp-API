using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController(AppDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task <ActionResult<IReadOnlyList<AppUser>>> GetUsers()
        {
            var  members = await context.User.ToListAsync();
            Console.WriteLine($"[LOG] Getting all members, count: {members.Count}");
            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(string id)
        {
            var member = await context.User.FindAsync(id);
            if (member == null) return NotFound();
            Console.WriteLine($"[LOG] Getting member with id {id}");
            return Ok(member);
        }
    }
}
