using tracker_api.Models;
using tracker_api.Repositories;

namespace tracker_api.Services
{
    public class WeightService : IWeightService
    {
        private readonly IWeightRepository _weightRepository;
        public WeightService(IWeightRepository weightRepository)
        {
            _weightRepository = weightRepository;
        }

        public async Task<List<WeightEntry>> GetAllWeightEntriesByUserIdAsync(Guid userId)
        {
            var entries = await _weightRepository.GetAllWeightEntriesByUserId(userId);
            return entries;
        }
    }
}