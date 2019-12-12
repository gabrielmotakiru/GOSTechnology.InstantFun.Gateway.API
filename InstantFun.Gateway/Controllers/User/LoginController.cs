using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using InstantFun.Domain.BindingModels;
using InstantFun.Domain.Configurations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace InstantFun.Gateway.Controllers.User
{
    /// <summary>
    /// LoginController.
    /// </summary>
    [ApiController]
    [Route(Util.ROUTE_CONTROLLER_BASE)]
    public class LoginController : ControllerBase
    {
        UserManager<IdentityUser> _userManager;

        /// <summary>
        /// LoginController.
        /// </summary>
        public LoginController(UserManager<IdentityUser> userManager)
        {
            this._userManager = userManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody]LoginBindingModel model)
        {
            try
            {
                //var service = new UserService();
                //var user = service.Authenticate(model.UserName, model.Password);

                var user = await this._userManager.FindByEmailAsync(model.Email);

                if (user == null)
                    return null;

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("43e4dbf0-52ed-4203-895d-42b586496bd4");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim("InstantFun-Gateway", user.PasswordHash)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.SecurityStamp = tokenHandler.WriteToken(token);

                user.PasswordHash = null;

                if (user == null)
                    return BadRequest(new { message = "Usuário ou senha inválidos" });

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}