using Newtonsoft.Json;

namespace MatterAssignment.Services.DTO
{
    public class InvoiceDTO
    {
        [JsonIgnore]
        public int Id { get; set; }

        public decimal HoursWorked { get; set; }

        public int AttorneyId { get; set; }

        public int MatterId { get; set; }
    }
}