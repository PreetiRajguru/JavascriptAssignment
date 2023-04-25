namespace MatterAssignment.Services.DTO
{
    public class MatterDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int ClientId { get; set; }

        public int BillingAttorneyId { get; set; }

        public int ResponsibleAttorneyId { get; set; }

        public int JurisdictionId { get; set; }
    }
}
