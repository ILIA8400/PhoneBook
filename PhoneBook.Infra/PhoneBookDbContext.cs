using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.CallHistories;
using PhoneBook.Domain.Contacts;
using PhoneBook.Domain.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Infra
{
    public class PhoneBookDbContext : DbContext
    {
        #region DbSets
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactGroup> Groups { get; set; }
        public DbSet<CallHistory> CallHistories { get; set; }
        public DbSet<CallType> CallTypes { get; set; }
        #endregion

        #region Ctor
        public PhoneBookDbContext(DbContextOptions<PhoneBookDbContext> options) : base(options)
        {
        }
        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PhoneBookDbContext).Assembly);
        }
        #endregion
    }
}
