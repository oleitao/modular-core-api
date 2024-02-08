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
    public class TouchController : ControllerBase
    {
        private readonly BuildContext _context;

        private readonly ILogger<TouchController> _logger;

        public TouchController(BuildContext context, ILogger<TouchController> logger) {

            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<List<Touch>> Get()
        {
            return await _context.Touchs.ToListAsync();
        }
    }
}