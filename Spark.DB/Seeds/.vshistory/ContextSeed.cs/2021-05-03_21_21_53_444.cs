﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Spark.DB.Models.IdentityModels;
using Spark.Domain.Roles;
using System.Threading.Tasks;

namespace Spark.DB.Seeds
{
    public static class ContextSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            # region Roles
            //modelBuilder.Entity<ApplicationRole>().HasData(
            //    new ApplicationRole
            //    {
            //        Id = 1,
            //        Name = "Admin",
            //        NormalizedName = "Admin".ToUpper()
            //    },
            //    new ApplicationRole
            //    {
            //        Id = 2,
            //        Name = "Student",
            //        NormalizedName = "Student".ToUpper()
            //    },
            //    new ApplicationRole
            //    {
            //        Id = 3,
            //        Name = "Teacher",
            //        NormalizedName = "Teacher".ToUpper()
            //    }
            //);
            #endregion 
        }

        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            await roleManager.CreateAsync(new IdentityRole(UserRoles.Student));
            await roleManager.CreateAsync(new IdentityRole(UserRoles.Teacher));
        }
    }
}
