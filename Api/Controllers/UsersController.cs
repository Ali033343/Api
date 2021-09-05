using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly DataContext _Context;

        public UsersController(DataContext Context)
        {
            _Context = Context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUsers>>> GetUsers()
        {
            var users =await  _Context.Users.ToListAsync();
            return  users;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUsers>> GetUsers(int id)
        {
            var user = await _Context.Users.FindAsync(id);
            return user;

        }
    }
}