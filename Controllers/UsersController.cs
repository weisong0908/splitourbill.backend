using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using splitourbill_backend.Persistence;

namespace splitourbill_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly BackendDbContext _dbContext;

        public UsersController(BackendDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _dbContext.Users.ToListAsync());
        }
    }
}