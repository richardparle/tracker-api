using Npgsql;
using tracker_api.Models;

namespace tracker_api.Repositories
{
    public class WeightRepository : IWeightRepository
    {
        private readonly string _connectionString;

        public WeightRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException(nameof(configuration), "Connection string cannot be null.");
        }

        public async Task<List<WeightEntry>> GetAllWeightEntriesByUserId(Guid userId)
        {
            var weightEntries = new List<WeightEntry>();

            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    using (var command = new NpgsqlCommand("SELECT id, weight_kg, date, user_id FROM weight_entries WHERE user_id = @user_Id", connection))
                    {
                        command.Parameters.AddWithValue("@user_Id", userId);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                weightEntries.Add(new WeightEntry
                                {
                                    Id = reader.GetInt32(0),
                                    WeightKg = reader.GetDecimal(1),
                                    Date = reader.GetDateTime(2),
                                    UserId = reader.GetGuid(3)
                                });
                            }
                        }
                    }
                }
                return weightEntries;
            }
            catch (Exception ex)
            {
                // @TODO - Add proper error handling
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
    }
}