namespace MatterAssignment.Services.DTO
{
    public class AttorneyWithIdDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Rate { get; set; }

        public int JurisdictionId { get; set; }
    }
}
