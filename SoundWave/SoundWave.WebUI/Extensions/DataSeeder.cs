using Microsoft.AspNetCore.Identity;
using SoundWave.Entity.Entities;
using SoundWave.Entity.Enums;

namespace SoundWave.WebUI.Extensions
{
    public static class DataSeeder
    {
        public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>();
            var roles = Enum.GetNames(typeof(SubscriptionLevel));
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new AppRole { Name = role });
                }
            }
        }
    }
}
