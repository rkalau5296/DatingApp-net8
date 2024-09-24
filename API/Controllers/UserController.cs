using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] // /api/user
public class UsersController(DataContext context) : ControllerBase
{   
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        IEnumerable<AppUser> users = await context.Users.ToListAsync();
        if(users == null )return NotFound();
        return Ok(users);
    }
    [HttpGet("{id}")] // /api/user/3
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        var user = await context.Users.FindAsync(id);

        if(user==null)return NotFound();
        return Ok(user);
    }
}
