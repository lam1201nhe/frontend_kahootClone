using BusinessObjects.Models;
using DataTransfer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.impl;

namespace FE_Kahoot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository repository = new UserRepository();

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers() => repository.GetUsers();

        [HttpGet("id")]
        public ActionResult<User> GetUserByUserID(int id) => repository.GetUserByUserID(id);

        [HttpPost]
        public IActionResult SaveUser(ProfileDTO user)
        {
            var newUser = new User
            {
                FullName = user.FullName,
                Email = user.Email,
                AccountId = user.AccountId,
                Dob = user?.Dob,
                Image = user?.Image,
                Description = user?.Description,
                Phone = user.Phone,
                Gender = user?.Gender
            };
            repository.SaveUser(newUser);
            return Ok(newUser);
        }

        [HttpPut("id")]
        public IActionResult UpdateUser(int userId, ProfileDTO user)
        {
            var newUser = new User
            {
                FullName = user.FullName,
                Email = user.Email,
                AccountId = user.AccountId,
                Dob = user?.Dob,
                Image = user?.Image,
                Description = user?.Description,
                Phone = user.Phone,
                Gender = user?.Gender
            };
            repository.SaveUser(newUser);
            return Ok(newUser);
        }

        [HttpGet("EmailExisted")]
        public IActionResult CheckEmailIsExisted(string email)
        {
            User user = repository.CheckEmailExisted(email);
            if (user != null)
            {
                return Ok(user);
            }
            return Ok();
        }

        [HttpGet("PhoneExisted")]
        public IActionResult CheckPhoneIsExisted(string phone)
        {
            User user = repository.CheckEmailExisted(phone);
            if (user != null)
            {
                return Ok(user);
            }
            return Ok();
        }
    }
}
