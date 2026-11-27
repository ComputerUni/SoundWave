using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SoundWave.Business.Services.Abstract;
using SoundWave.DataAccess.Repositories.Albums;
using SoundWave.DataAccess.Repositories.Artists;
using SoundWave.DataAccess.Repositories.Songs;
using SoundWave.DTO.DashboardDtos;
using SoundWave.DTO.SongDtos;
using SoundWave.DTO.UserDtos;
using SoundWave.Entity.Entities;
using SoundWave.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoundWave.Business.Services.Concrete
{
    public class DashboardService(UserManager<AppUser> _userManager, IArtistRepository _artistRepository, IAlbumRepository _albumRepository, ISongRepository _songRepository) : IDashboardService
    {
        public async Task<ResultDashboardDto> GetDashboardDataAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var artists = await _artistRepository.GetAllAsync();
            var albums = await _albumRepository.GetAllAsync();
            var songs = await _songRepository.GetAllAsync();

            int freeCount = 0, standartCount = 0, premiumCount = 0, diamondCount = 0;
            foreach(var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("Admin")) continue;

                var packageRole = roles.FirstOrDefault(r => Enum.TryParse<SubscriptionLevel>(r, out _));
                var level = Enum.TryParse<SubscriptionLevel>(packageRole, out var parsed) ? parsed : SubscriptionLevel.Free;

                switch(level)
                {
                    case SubscriptionLevel.Free: freeCount++; break;
                    case SubscriptionLevel.Standard: standartCount++; break;
                    case SubscriptionLevel.Premium: premiumCount++; break;
                    case SubscriptionLevel.Diamond: diamondCount++; break;    
                }
            }

            var topArtists = artists.Select(artist =>
            {
                var artistAlbumIds = albums.Where(al => al.ArtistId == artist.Id).Select(al => al.Id).ToHashSet();

                return new
                {
                    artist.Name,
                    SongCount = songs.Count(s => artistAlbumIds.Contains(s.AlbumId))
                };
            }).OrderByDescending(x => x.SongCount).Take(5).ToList();

            return new ResultDashboardDto
            {
                TotalUsers = users.Count,
                TotalAlbums = albums.Count,
                TotalArtists = artists.Count,
                TotalSong = songs.Count,

                FreeUserCount = freeCount,
                StandardUserCount = standartCount,
                PremiumUserCount = premiumCount,
                DiamondUserCount = diamondCount,

                TopArtistNames = topArtists.Select(x => x.Name).ToList(),
                TopArtistSongCounts = topArtists.Select(x => x.SongCount).ToList(),

                RecentSongs = songs.OrderByDescending(s => s.Id).Take(5).Select(s =>
                {
                    var album = albums.FirstOrDefault(al => al.Id == s.AlbumId);
                    var artist = album != null ? artists.FirstOrDefault(a => a.Id == album.ArtistId) : null;

                    return new ResultSongDto
                    {
                        Id = s.Id,
                        Title = s.Title,
                        Duration = s.Duration,
                        PlayCount = s.PlayCount,
                        SubscriptionLevel = s.SubscriptionLevel,
                        AlbumTitle = album?.Title ?? "-",
                        ArtistName = artist?.Name ?? "-"
                    };

                }).ToList(),

                RecentUsers = users.OrderByDescending(u => u.Id).Take(5).Select(u => new ResultUserDto
                {
                    Id = u.Id,
                    FullName = u.FullName,
                    UserName = u.UserName!,
                    Email = u.Email!,
                    IsLockedOut = u.LockoutEnd.HasValue && u.LockoutEnd.Value > DateTimeOffset.UtcNow
                }).ToList(),
            };
        }
    }
}
