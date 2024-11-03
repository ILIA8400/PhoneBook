using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Domain.CallHistories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Infra.Data.Configurations
{
    public class CallTypeConfig : IEntityTypeConfiguration<CallType>
    {
        public void Configure(EntityTypeBuilder<CallType> builder)
        {
            // Table Name
            builder.ToTable("call_types");

            // Key
            builder.HasKey(x => x.Id);

            // Config Name Property
            builder.Property(x => x.Name).IsRequired().HasColumnName("name");

            // Data
            builder.HasData(
                new CallType
                {
                    Name = "Missed Call"
                },
                new CallType
                {
                    Name = "Outgoing Call"
                },
                new CallType
                {
                    Name = "Incoming Call"
                }
            );
        }
    }
}
