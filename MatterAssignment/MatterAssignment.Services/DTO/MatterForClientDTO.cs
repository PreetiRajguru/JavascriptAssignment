namespace MatterAssignment.Services.DTO
{
    public class MatterForClientDTO
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; }

        public string JurisdictionArea { get; set; }

        public string ClientFirstName { get; set; }

        public string ClientLastName { get; set; }

        public string BillingAttorneyName { get; set; }

        public string ResponsibleAttorneyName { get; set; }
    }
}
