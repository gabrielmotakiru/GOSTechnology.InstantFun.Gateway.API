using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstantFun.Data.Data
{
    /// <summary>
    /// ApplicationDbContext.
    /// </summary>  
    public class ApplicationDbContext : IdentityDbContext
    {
        /// <summary>
        /// ApplicationDbContext.
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
