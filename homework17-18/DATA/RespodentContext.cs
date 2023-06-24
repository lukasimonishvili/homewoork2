using BCryptNet = BCrypt.Net.BCrypt;
using DOMAIN;
using Microsoft.EntityFrameworkCore;
using System;

namespace DATA
{
    public class RespodentContext : DbContext
    {
        public DbSet<Respodent> Respodents { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var date = DateTime.Now;
            modelBuilder.Entity<Respodent>().HasData(
                new Respodent
                {
                    Id = 1,
                    FirstName = "Default",
                    LastName = "Admin",
                    Role = Roles.Admin,
                    CreateDate = $"{date.Month}-{date.Day}-{date.Year}",
                    Username = "admin",
                    Password = BCryptNet.HashPassword("admin"),
                    JobPosition = "Admin",
                    Salary = 7000,
                    WorkExperience = 2,

                });
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost\\SQLEXPRESS;Database=InterviewHomework;Trusted_Connection=True;MultipleActiveResultSets=True"
            );
        }
    }
}
