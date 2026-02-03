using FeatureFlag.Application.DTOs;
using FeatureFlag.Domain.Entities;
using FeatureFlag.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FeatureFlag.Application.Services
{
    public class FeatureFlagService : IFeatureFlagService
    {
        private readonly IFeatureFlagRepository _flagRepository;

        public FeatureFlagService(IFeatureFlagRepository flagRepository)
        {
            _flagRepository = flagRepository;
        }

        public async Task<int> GetPercentage()
        {
            var percentage = await _flagRepository.GetPercentageAsync();
            return percentage;
        }

        public async Task SetPercentageAsync(int percentage)
        {
            if (percentage < 0 || percentage > 100)
                throw new ArgumentException("Percentage must be between 0 and 100");

            await _flagRepository.SetPercentageAsync(percentage);
        }
    }
}
