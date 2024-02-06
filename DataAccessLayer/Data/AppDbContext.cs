using DataAccessLayer.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Visitor> Visitors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Integrated Security=SSPI;Initial Catalog=ERP;Data Source=.\\SqlExpress;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{

        //    string ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
        //    string ROLE_ID = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";

        //    //seed admin role
        //    builder.Entity<IdentityRole>().HasData(new IdentityRole
        //    {
        //        Name = "SuperAdmin",
        //        NormalizedName = "SUPERADMIN",
        //        Id = ROLE_ID,
        //        ConcurrencyStamp = ROLE_ID
        //    });

        //    //create user
        //    var appUser = new IdentityUser
        //    {
        //        Id = ADMIN_ID,
        //        Email = "rabin@gmail.com",
        //        EmailConfirmed = true,
        //        UserName = "Rabin@gmail.com",
        //     NormalizedUserName = "RABIN@GMAIL.COM"
        //    };

        //    //set user password
        //    PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
        //    appUser.PasswordHash = ph.HashPassword(appUser, "Admin@123");

        //    //seed user
        //    builder.Entity<IdentityUser>().HasData(appUser);

        //    //set user role to admin
        //    builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        //    {
        //        RoleId = ROLE_ID,
        //        UserId = ADMIN_ID
        //    });

        //    base.OnModelCreating(builder);
        //}
    }

    public class ApplicationUser : IdentityUser
    {
        public string? Address { get; set; }
        public string? PinCode { get; set; }
        public string? About { get; set; }
        public string? ProfilePictureFileName { get; set; }
    }
}
