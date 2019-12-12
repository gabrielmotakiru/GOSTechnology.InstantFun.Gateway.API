using System;
using System.Collections.Generic;
using System.Text;

namespace InstantFun.Domain.BindingModels
{
    /// <summary>
    /// LoginBindingModel.
    /// </summary>
    public class LoginBindingModel
    {
        public String UserName { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
    }
}
