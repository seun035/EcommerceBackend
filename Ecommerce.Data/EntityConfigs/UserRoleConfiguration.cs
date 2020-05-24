using Ecommerce.Core.Users.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Data.EntityConfigs
{
    class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(k => new { k.UserId, k.Role });

            builder
                .HasOne<User>(ur => ur.User)
                .WithMany(u => u.Roles)
                .HasForeignKey(f => f.UserId);
        }
    }
}
