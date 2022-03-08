using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProject.Models;

namespace WebApiProject.Repositories
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUp(SignUpModel model);

        Task<string> Signin(SignInModel model);
    }
}
