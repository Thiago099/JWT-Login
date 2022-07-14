using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using natura_process_api.Data;

namespace natura_process_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
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



        // GET: Users
        [HttpGet(Name = "GetUser")]
        public async Task<IActionResult> Index()
        {
            return _context.User != null ?
                        Ok(await _context.User.ToListAsync()) :
                        Problem("Entity set 'Context.User'  is null.");
        }
    }
}
