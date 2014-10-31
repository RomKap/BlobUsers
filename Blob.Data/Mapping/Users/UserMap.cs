using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using Blob.Core.Domain.Users;


namespace Blob.Data.Mapping.Users
{
    public partial class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.ToTable("Users");
            this.HasKey(c => c.Id);
            this.Property(u => u.Username).HasMaxLength(50);
            this.Property(u => u.fname).HasMaxLength(50);
            this.Property(u => u.lname).HasMaxLength(50);

            this.HasMany<UserRoles>(c => c.UserRoles)
                .WithMany()
                .Map(m => m.ToTable("UserRoles"));

            this.HasMany<Address>(c => c.Addresses)
                .WithMany()
                .Map(m => m.ToTable("Address"));
        }
    }
}
