using HospitalLibrary.Core.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Identity
{
    public class AuthenticationDbContext : IdentityDbContext<SecUser>
    {

        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /*IdentityUser user = new IdentityUser()
            {
                UserName = "pera",
                NormalizedUserName = "PERA",
                Email = "pera@gmail.com",
                NormalizedEmail = "PERA@GMAIL.COM"
            };

            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            user.PasswordHash = ph.HashPassword(user, "1234");

            builder.Entity<IdentityUser>().HasData(
                user
            );*/

        }
    }
}
