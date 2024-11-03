using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Domain.CallHistories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Infra.Data.Configurations
{
    public class CallHistoryConfig : IEntityTypeConfiguration<CallHistory>
    {
        public void Configure(EntityTypeBuilder<CallHistory> builder)
        {
            // Table Name
            builder.ToTable("call_histories");

            // Key
            builder.HasKey(x => x.Id);

            // Config Name Property
            builder.Property(c => c.Id).HasColumnName("id");

            // Config CallDateTime Property
            builder.Property(c => c.CallDateTime).HasColumnName("call_date_time");

            // Config CallTypeId Property
            builder.Property(c => c.CallTypeId).HasColumnName("call_type_id");

            // Config ContactId Property
            builder.Property(c => c.ContactId).HasColumnName("contact_id");
        }
    }
}
