using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstantFun.Domain.BindingModels;
using InstantFun.Domain.Configurations;
using InstantFun.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceStack.Redis;

namespace InstantFun.Gateway.Controllers
{
    /// <summary>
    /// RegisterController.
    /// </summary>
    [ApiController]
    [Route(Util.ROUTE_CONTROLLER_BASE)]
    public class RegisterController : BaseController
    {
        /// <summary>
        /// _registerService.
        /// </summary>
        //private readonly IRegisterService _registerService;

        /// <summary>
        /// RegisterController.
        /// </summary>
        public RegisterController()
        {
            //this._registerService = registerService;

            
        }

        /// <summary>
        /// Post.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        //[Authorize]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]RegisterBindingModel registerBindingModel)
        {
            //var result = await this._registerService.Register(model);
            //return Ok(result);



            //var registerBindingModel = new RegisterBindingModel { Email = "gabrielzxc2@gmail.com", Password = "teste", PhoneNumber = "11958395433", UserName = "gabrielmotakiru" };
            var key = $"[{registerBindingModel.Email}-{registerBindingModel.Password}-{registerBindingModel.PhoneNumber}-{registerBindingModel.UserName}]";

            try
            {
                //using (var redisClient = new RedisClient("redis-13893.c8.us-east-1-3.ec2.cloud.redislabs.com", 13893, "R6BdMdvUEK6rHEGJVgGdF92dli3gkSUH"))
                using (var redisClient = new RedisClient("localhost:6379"))
                {
                    if (redisClient.Exists(key) > 0)
                    {
                        return BadRequest($"Chave já existe: {key}");
                    }
                    else
                    {
                        redisClient.SetNX("", new byte[1]);
                        redisClient.Set<RegisterBindingModel>(key, registerBindingModel, new TimeSpan(0, 0, 0, 60, 0));
                        return Ok("Chave adicionada.");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Chave já existe: {key}");
            }
        }
    }
}