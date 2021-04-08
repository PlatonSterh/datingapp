using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using API.Entities;
using API.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UsersController : ControllerBase
  {
    private readonly DataContext _context;
    public UsersController(DataContext context)
    {
      _context = context;

    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsersAsync() {
      return await _context.Users.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUser(int id) {
      return await _context.Users.FindAsync(id);
    }
  }
}