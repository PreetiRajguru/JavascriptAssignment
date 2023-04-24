namespace MatterAssignment.Data.Models
{
    public class JurisdictionMaster
    {
        public int Id { get; set; }

        public string JurisdictionName { get; set; }

        public Attorney Attorney { get; set; } = null!;

        public Matter Matter { get; set; }

    }
}
