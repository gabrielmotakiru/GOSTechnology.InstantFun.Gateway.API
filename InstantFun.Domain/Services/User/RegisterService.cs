using InstantFun.Domain.BindingModels;
using InstantFun.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace InstantFun.Domain.Services
{
    public class RegisterService : IRegisterService
    {
        /// <summary>
        /// _userManager.
        /// </summary>
        private readonly UserManager<IdentityUser> _userManager;

        /// <summary>
        /// RegisterService.
        /// </summary>
        public RegisterService(UserManager<IdentityUser> userManager)
        {
            this._userManager = userManager;
        }

        public async Task<bool> Register(RegisterBindingModel model)
        {
            var user = new IdentityUser { UserName = model.UserName, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            return result.Succeeded;
        }
    }
}
