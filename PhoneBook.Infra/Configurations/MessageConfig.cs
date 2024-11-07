using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Domain.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Persistence.Configurations
{
    public class MessageConfig : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            // Table Name
            builder.ToTable("message");

            // Properties Settings
            builder.HasKey(x => x.Id);
            builder.Property(c=>c.Text).IsRequired().HasColumnName("text").HasMaxLength(100);
            builder.Property(c => c.From).IsRequired().HasColumnName("from");
            builder.Property(c => c.To).IsRequired().HasColumnName("to");
            builder.Property(c => c.SendTime).IsRequired().HasColumnName("send_time");
        }
    }
}
