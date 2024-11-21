using tracker_api.Models;

namespace tracker_api.Repositories
{
    public interface IWeightRepository
    {
        Task<List<WeightEntry>> GetAllWeightEntriesByUserId(Guid userId);
    }
}