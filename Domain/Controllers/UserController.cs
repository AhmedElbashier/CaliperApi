using Microsoft.AspNetCore.Mvc;
using CaliperApi.Domain.Helpers;
using CaliperApi.Domain.Services;
using CaliperApi.Domain.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Linq;

namespace CaliperApi.Domain.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IUserService _UserService;

        public UserController(AppDbContext context, IUserService UserService)
        {
            _context = context;
            _UserService = UserService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var Users = _UserService.GetALl();
            return Ok(Users);
        }
        
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var User = _UserService.GetUser(id);

            if (User == null)
            {
                return NotFound();
            }

            return Ok(User);
        }

            [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User User)
        {
            if (id != User.id)
            {
                return BadRequest();
            }

            _context.Entry(User).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPost]
        public IActionResult CreateUser(UserDto UserDto)
        {
            var User = _UserService.CreateUser(UserDto);
            return Ok(User);
        }

       
     [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var User = await _context.Users.FindAsync(id);
            if (User == null)
            {
                return NotFound();
            }

            _context.Users.Remove(User);
            await _context.SaveChangesAsync();

            return User;
        }

               private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.id == id);
        }
    }
}