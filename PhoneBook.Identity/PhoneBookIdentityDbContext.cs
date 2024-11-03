using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Identity
{
    public class PhoneBookIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        #region DbSet
        public DbSet<ApplicationUser> Users { get; set; }
        #endregion

        #region Ctor
        public PhoneBookIdentityDbContext(DbContextOptions<PhoneBookIdentityDbContext> options) : base(options)
        {
        }
        #endregion       
    }
}
