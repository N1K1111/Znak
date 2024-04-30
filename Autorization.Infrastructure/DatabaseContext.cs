using Autorization.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autorization.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>().HasData(new User
            {
                Id = Guid.Parse("a2a7dcb7-49fd-4ab9-bd00-b05d31a12d3e"),
                Email = "a@mail.ru",
                ImagePath = "/content/avatars/35a44d12-42f9-4254-a7d3-2e3bf26c934c.jpg",
                Role = "user",
                Username = "Andrey Glazev",
                PasswordHash = "473287f8298dba7163a897908958f7c0eae733e25d2e027992ea2edc9bed2fa8"
            });
        }
        public override ValueTask DisposeAsync()
        {
            SaveChanges();
            return base.DisposeAsync();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=123123;Database=OTUS_AUTH;Port=5432;");
        }
    }
}
