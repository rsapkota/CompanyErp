﻿using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer
{
    public static class AdminUserSeed
    {
        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByEmailAsync("abc@xyz.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "abc@xyz.com",
                    Email = "abc@xyz.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "Admin@123").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}
