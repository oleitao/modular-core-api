using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ModularCoreApi.Models;
using System.Security.Cryptography.X509Certificates;

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

        [HttpGet("{id}")]
        public async Task<List<User>> Get(Guid id)
        {

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
                return null;

            return new List<User>() { user };
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync( x => x.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }
            
            return false;
        }

        [HttpPost]
        public void Post([FromBody]User user)
        {
            _context.Users.Add(user);
            _context.SaveChangesAsync();
        }

        [HttpPut]
        public async Task<User> Put([FromBody]User user)
        {
            var editedUser = await _context.Users.FirstOrDefaultAsync(x =>x.Id == user.Id);
            if (editedUser != null)
            {
                editedUser.Name=user.Name;
                return editedUser;
            }

            return null;
        }

    }
}