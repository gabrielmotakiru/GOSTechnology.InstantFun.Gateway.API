using InstantFun.Domain.BindingModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstantFun.Domain.Interfaces
{
    public interface IRegisterService
    {
        Task<Boolean> Register(RegisterBindingModel model);
    }
}
