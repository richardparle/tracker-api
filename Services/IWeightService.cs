using tracker_api.Models;

namespace tracker_api.Services
{
    public interface IWeightService
    {
        Task<List<WeightEntry>> GetAllWeightEntriesByUserIdAsync(Guid userId);
    }
}