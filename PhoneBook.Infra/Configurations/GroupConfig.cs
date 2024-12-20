﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Domain.Contacts;
using PhoneBook.Domain.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Infra.Configurations
{
    public class GroupConfig : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            // Table Name
            builder.ToTable("groups");

            // Key
            builder.HasKey(c => c.Id);

            // Config GroupName Property
            builder.Property(c => c.GroupName).IsRequired().HasMaxLength(55).HasColumnName("group_name");

            // Config Id Property
            builder.Property(c => c.Id).HasColumnName("id");
        }
    }
}
