using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ModularCoreApi.Models;

namespace ModularCoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly BuildContext _context;

        private readonly ILogger<UserController> _logger;

        public UserController(BuildContext context, ILogger<UserController> logger) {

            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<List<User>> Get()
        {
            return await _context.Users.ToListAsync();
        }
    }
}