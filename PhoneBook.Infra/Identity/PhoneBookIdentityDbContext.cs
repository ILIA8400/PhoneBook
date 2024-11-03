using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Infra.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Infra.Identity
{
    public class PhoneBookIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        #region DbSet
        public DbSet<ApplicationUser> Users { get; set; }
        #endregion

        #region Ctor
        public PhoneBookIdentityDbContext(DbContextOptions options) : base(options)
        {
        }
        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(PhoneBookIdentityDbContext).Assembly);
        } 
        #endregion
    }
}
