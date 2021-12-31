using System.Linq;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly DataContext _context;

    public UserController(DataContext context)
    {
        _context = context;
    }

    [HttpGet] 
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    [HttpGet("{id}")] 
    public async Task<ActionResult<AppUser>> GetUserAsync(int id)
    {
        var  user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        if(user == null){
            return BadRequest("INVALID_ID");
        }
        return user;
    }
}
