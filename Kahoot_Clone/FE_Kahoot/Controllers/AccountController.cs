using BusinessObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update;
using Repositories;
using Repositories.impl;

namespace FE_Kahoot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountRepository repository = new AccountRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Account>> GetAccounts() => repository.GetAccounts();

        [HttpGet("username={username}")]
        public ActionResult<Account> GetAccountByUsername(string username) => repository.FindAccountByUsername(username);
        
    }
}
