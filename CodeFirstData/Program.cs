using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blob.Core.Domain.Users;
using System.Data.Entity;


namespace CodeFirstData
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BlobContext())
            {
                var user = new User { Id = 1, fname = "Romesh" };
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
    }

    

    public class BlobContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}
