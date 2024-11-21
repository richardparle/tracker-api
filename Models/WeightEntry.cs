namespace tracker_api.Models
{
        public class WeightEntry
        {
                public int Id { get; set; }
                public decimal WeightKg { get; set; }
                public DateTime Date { get; set; }
                public Guid UserId { get; set; }
        }
}
