using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JWTLogin.Data;

namespace JWTLogin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly Context _context;
        private readonly ILogger<UsersController> _logger;

        public UsersController(Context context, ILogger<UsersController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return _context.User != null ?
                        Ok(await _context.User.ToListAsync()) :
                        Problem("Entity set 'Context.User'  is null.");
        }
    }
}
