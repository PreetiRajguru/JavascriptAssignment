namespace MatterAssignment.Data.Models
{
    public class JurisdictionMaster
    {
        public int Id { get; set; }

        public string JurisdictionName { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Attorney> Attorneys { get; set; }

        public ICollection<Matter> Matters { get; set; }

    }
}
