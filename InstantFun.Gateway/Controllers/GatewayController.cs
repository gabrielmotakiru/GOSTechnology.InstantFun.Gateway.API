using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using InstantFun.Data.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InstantFun.Gateway.Controllers
{
    public class Model
    {
        public String UserName { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        UserManager<IdentityUser> _userManager;

        public GatewayController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            //var db = new ApplicationDbContext();
            //db.Database.EnsureCreated();
        }

        [HttpPost("PostModel")]
        public async Task<IActionResult> Post([FromBody]Model model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.UserName, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }
    }
}