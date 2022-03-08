using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProject.Models;
using WebApiProject.Repositories;

namespace WebApiProject.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository= accountRepository;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] SignUpModel model)
        {
          var result = await _accountRepository.SignUp(model);

            if(result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }

        [HttpPost]
        public async Task<IActionResult> Signin([FromBody] SignInModel model)
        {
            var result = await _accountRepository.Signin(model);

            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
