using SoundWave.DTO.SongDtos;
using SoundWave.DTO.UserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoundWave.DTO.DashboardDtos
{
    public class ResultDashboardDto
    {
        public int TotalUsers { get; set; }
        public int LockedUsersCount { get; set; }
        public int TotalArtists { get; set; }
        public int TotalAlbums { get; set; }
        public int TotalSong { get; set; }

        public int FreeUserCount { get; set; }
        public int StandardUserCount { get; set; }
        public int PremiumUserCount { get; set; }
        public int DiamondUserCount { get; set; }

        public List<string> TopArtistNames { get; set; } = new();
        public List<int> TopArtistSongCounts { get; set; } = new();

        public List<ResultSongDto> RecentSongs { get; set; } = new();
        public List<ResultUserDto> RecentUsers { get; set; } = new();
    }
}
