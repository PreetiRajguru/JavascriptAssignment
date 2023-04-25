namespace MatterAssignment.Data.Models
{
    public class Matter
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public int ClientId { get; set; }

        public int BillingAttorneyId { get; set; }

        public int ResponsibleAttorneyId { get; set; }

        public int JurisdictionId { get; set; }

        public Client Client { get; set; }

        public Attorney Attorney { get; set; }

        public JurisdictionMaster Jurisdiction { get; set; } = null!;

        public ICollection<Invoice> Invoices { get; set; }
    }
}
