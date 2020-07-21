using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Contexts;
using WebApplication1.Core;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        private readonly IUserService UserService;

        public UserController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsers([FromHeader] string authorization)
        {
            var users = await UserService.GetList();
            return Ok(new CoreResponse<IEnumerable<User>>
            {
                Success = true, 
                Result = users, 
                Message = "User List" + authorization
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await UserService.GetOne(id);
            var response = new CoreResponse<User> { Success = true, Result = user, Message = "" };
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            var savedUser = await UserService.CreateOne(user);
            return Ok(new CoreResponse<User>
            {
                Success = true,
                Result = savedUser,
                Message = "User Get By Id"
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(int id, User user)
        {
            var testUser = await UserService.GetOne(id);
            CoreResponse<User> response;
            if (id != testUser.Id)
            {
                response = new CoreResponse<User> { Success = false, Result = null, Message = "user not match" };
                return NotFound(response);
            }

            var savedUser = await UserService.UpdateOne(user);
            response = new CoreResponse<User> { Success = false, Result = null, Message = "user updated" };
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            CoreResponse<User> response;
            var savedUser = await UserService.DeleteOne(id);
            response = new CoreResponse<User> { Success = true, Result = null, Message = "user deleted" };
            return Ok(response);
        }

    }
}
