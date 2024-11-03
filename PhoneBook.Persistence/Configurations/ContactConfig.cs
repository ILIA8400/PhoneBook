using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Domain.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Infra.Configurations
{
    internal class ContactConfig : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            // Table Name
            builder.ToTable("contacts");

            // Key
            builder.HasKey(x => x.Id);

            // Config Name Property
            builder.Property(c => c.Name).IsRequired().HasMaxLength(55);
            builder.Property(c => c.Name).HasColumnName("name");

            // Config PhoneNumber Property
            builder.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(11);
            builder.Property(c => c.PhoneNumber).HasColumnName("phone_number");

            // Config PhoneNumber Property
            builder.Property(c => c.Email).HasColumnName("email").HasMaxLength(255);

            // Config Address Property
            builder.Property(c => c.Address).HasColumnName("address").HasMaxLength(255);

            // Config Id Property
            builder.Property(c => c.Id).HasColumnName("id");
        }
    }
}
