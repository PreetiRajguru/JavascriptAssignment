namespace MatterAssignment.Data.Models
{
    public class Attorney
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Rate { get; set; }

        public int JurisdictionId { get; set; }
        public JurisdictionMaster Jurisdiction { get; set; } = null!;

        public ICollection<Matter> Matters { get; set; }

        public ICollection<AttorneyRole> AttorneyRoles { get; set; }

        public ICollection<Invoice> Invoices { get; set; }
    }
}
