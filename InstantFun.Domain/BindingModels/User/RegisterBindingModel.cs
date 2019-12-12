using System;
using System.Collections.Generic;
using System.Text;

namespace InstantFun.Domain.BindingModels
{
    /// <summary>
    /// RegisterBindingModel.
    /// </summary>
    public class RegisterBindingModel
    {
        public String UserName { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String PhoneNumber { get; set; }
    }
}
