using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Models;

namespace Test.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class AllController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger<AllController> _logger;
        public AllController(DataContext context, ILogger<AllController> logger)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("get/{id}")]
        public string GetUser(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return "User not found";
            }
            else
            {
                return user.Username;
            }
        }

        [HttpGet("get-user-list")]
        public List<User> GetUserList()
        {
            var users = _context.Users.ToList();

            if (users == null)
            {
                return new List<User>();
            }
            else
            {
                return users;
            }
        }


        [HttpPost("register-user")]
        public int AddUser([FromBody] User user)
        {
            User newUser = new User()
            {
                Username = user.Username,
                Password = user.Password
            };
            try
            {
                _context.Users.Add(newUser);
                _context.SaveChanges();
                return 1;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return 0;
            }
        }

        [HttpPost("register-item")]
        public int AddItem([FromBody] Item item)
        {
            Item newItem = new Item()
            {
                Name = item.Name
            };
            try
            {
                _context.Items.Add(newItem);
                _context.SaveChanges();
                return 1;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return 0;
            }
        }

        [HttpPut("update-user-password/{id}")]
        public int updateUserPassword(int id, [FromBody] string newPassword)
        {
            var oldUser = _context.Users
                        .FirstOrDefault(x => x.Id == id);
            if (oldUser == null)
            {
                return 0;
            }
            else
            {
                oldUser.Password = newPassword;
                _context.SaveChanges();
                return 1;
            }
        }

        [HttpDelete("delete-item/{id}")]
        public int deleteItem(int id)
        {
            var itemDelete = _context.Items
                            .FirstOrDefault(x => x.Id == id);
            if (itemDelete == null)
            {
                return 0;
            }
            else
            {
                _context.Remove(itemDelete);
                _context.SaveChanges();
                return 1;
            }
        }



    }
}