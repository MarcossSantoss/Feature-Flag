using FeatureFlag.Application.DTOs;
using FeatureFlag.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FeatureFlag.Application.Services
{
    public interface IFeatureFlagService
    {
        Task<int> GetPercentage();
        Task SetPercentageAsync(int percentage);
    }
}
