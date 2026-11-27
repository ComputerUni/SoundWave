using SoundWave.DTO.DashboardDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoundWave.Business.Services.Abstract
{
    public interface IDashboardService
    {
        Task<ResultDashboardDto> GetDashboardDataAsync();
    }
}
