using Microsoft.AspNetCore.Identity;
using SoundWave.DataAccess.Context;
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

        public static async Task SeedUsersAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            var users = new List<(AppUser user, string password, string role)>
            {
                (new AppUser
                {
                    UserName = "ahmetyilmaz",
                    Email = "ahmet.yilmaz@gmail.com",
                    FullName = "Ahmet Yılmaz",
                    CreatedAt = DateTime.UtcNow,
                    SubscriptionLevel = SubscriptionLevel.Free
                }, "Free123!", "Free"),

                (new AppUser
                {
                    UserName = "zeynepkaya",
                    Email = "zeynep.kaya@gmail.com",
                    FullName = "Zeynep Kaya",
                    CreatedAt = DateTime.UtcNow,
                    SubscriptionLevel = SubscriptionLevel.Standard
                }, "Standard123!", "Standard"),

                (new AppUser
                {
                    UserName = "emirdemir",
                    Email = "emir.demir@gmail.com",
                    FullName = "Emir Demir",
                    CreatedAt = DateTime.UtcNow,
                    SubscriptionLevel = SubscriptionLevel.Premium
                }, "Premium123!", "Premium"),

                (new AppUser
                {
                    UserName = "sedacelik",
                    Email = "seda.celik@gmail.com",
                    FullName = "Seda Çelik",
                    CreatedAt = DateTime.UtcNow,
                    SubscriptionLevel = SubscriptionLevel.Diamond
                }, "Diamond123!", "Diamond"),
            };

            foreach (var (user, password, role) in users)
            {
                if (await userManager.FindByEmailAsync(user.Email) is null)
                {
                    var result = await userManager.CreateAsync(user, password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, role);
                    }
                }
            }
        }

        public static async Task SeedMusicAsync(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<AppDbContext>();

            if (context.Artists.Any()) return;

            var artists = new List<Artist>
            {
                new Artist
                {
                    Name = "The Weeknd",
                    ImageUrl = "/images/artists/weeknd.jpg",
                    Bio = "Canadian singer and songwriter known for his dark R&B style."
                },
                new Artist
                {
                    Name = "Daft Punk",
                    ImageUrl = "/images/artists/daftpunk.jpg",
                    Bio = "French electronic music duo known for their innovative sound."
                },
                new Artist
                {
                    Name = "Billie Eilish",
                    ImageUrl = "/images/artists/billie.jpg",
                    Bio = "American singer-songwriter known for her whisper-pop style."
                }
            };

            await context.Artists.AddRangeAsync(artists);
            await context.SaveChangesAsync();

            var albums = new List<Album>
            {
                new Album { Title = "After Hours", CoverImageUrl = "/images/albums/afterhours.jpg", ReleaseYear = 2020, ArtistId = artists[0].Id },
                new Album { Title = "Random Access Memories", CoverImageUrl = "/images/albums/ram.jpg", ReleaseYear = 2013, ArtistId = artists[1].Id },
                new Album { Title = "Happier Than Ever", CoverImageUrl = "/images/albums/happier.jpg", ReleaseYear = 2021, ArtistId = artists[2].Id }
            };

            await context.Albums.AddRangeAsync(albums);
            await context.SaveChangesAsync();

            var songs = new List<Song>
            {
                new Song { Title = "Blinding Lights", Duration = TimeSpan.FromMinutes(3.5), AudioUrl = "/audio/blinding-lights.mp3", PlayCount = 0, SubscriptionLevel = SubscriptionLevel.Free, AlbumId = albums[0].Id },
                new Song { Title = "Save Your Tears", Duration = TimeSpan.FromMinutes(3.35), AudioUrl = "/audio/save-your-tears.mp3", PlayCount = 0, SubscriptionLevel = SubscriptionLevel.Free, AlbumId = albums[0].Id },
                new Song { Title = "In Your Eyes", Duration = TimeSpan.FromMinutes(3.57), AudioUrl = "/audio/in-your-eyes.mp3", PlayCount = 0, SubscriptionLevel = SubscriptionLevel.Free, AlbumId = albums[0].Id },

        
                new Song { Title = "Get Lucky", Duration = TimeSpan.FromMinutes(4.08), AudioUrl = "/audio/get-lucky.mp3", PlayCount = 0, SubscriptionLevel = SubscriptionLevel.Standard, AlbumId = albums[1].Id },
                new Song { Title = "Instant Crush", Duration = TimeSpan.FromMinutes(4.34), AudioUrl = "/audio/instant-crush.mp3", PlayCount = 0, SubscriptionLevel = SubscriptionLevel.Standard, AlbumId = albums[1].Id },
                new Song { Title = "Lose Yourself to Dance", Duration = TimeSpan.FromMinutes(5.53), AudioUrl = "/audio/lose-yourself.mp3", PlayCount = 0, SubscriptionLevel = SubscriptionLevel.Standard, AlbumId = albums[1].Id },

        
                new Song { Title = "Happier Than Ever", Duration = TimeSpan.FromMinutes(4.98), AudioUrl = "/audio/happier-than-ever.mp3", PlayCount = 0, SubscriptionLevel = SubscriptionLevel.Premium, AlbumId = albums[2].Id },
                new Song { Title = "Oxytocin", Duration = TimeSpan.FromMinutes(3.58), AudioUrl = "/audio/oxytocin.mp3", PlayCount = 0, SubscriptionLevel = SubscriptionLevel.Premium, AlbumId = albums[2].Id },
                new Song { Title = "NDA", Duration = TimeSpan.FromMinutes(3.35), AudioUrl = "/audio/nda.mp3", PlayCount = 0, SubscriptionLevel = SubscriptionLevel.Premium, AlbumId = albums[2].Id },

        
                new Song { Title = "Blinding Lights (Studio Session)", Duration = TimeSpan.FromMinutes(5.12), AudioUrl = "/audio/blinding-lights-studio.mp3", PlayCount = 0, SubscriptionLevel = SubscriptionLevel.Diamond, AlbumId = albums[0].Id },
                new Song { Title = "Get Lucky (FLAC Master)", Duration = TimeSpan.FromMinutes(4.08), AudioUrl = "/audio/get-lucky-flac.mp3", PlayCount = 0, SubscriptionLevel = SubscriptionLevel.Diamond, AlbumId = albums[1].Id },
                new Song { Title = "Happier Than Ever (Hi-Fi)", Duration = TimeSpan.FromMinutes(4.98), AudioUrl = "/audio/happier-hifi.mp3", PlayCount = 0, SubscriptionLevel = SubscriptionLevel.Diamond, AlbumId = albums[2].Id },
            };

            await context.Songs.AddRangeAsync(songs);
            await context.SaveChangesAsync();
        }
    }
}
