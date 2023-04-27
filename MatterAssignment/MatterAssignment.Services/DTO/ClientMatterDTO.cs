namespace MatterAssignment.Services.DTO
{
    public class ClientMatterDTO
    {
        public int ClientId { get; set; }

        public IEnumerable<MatterDTO> Matters { get; set; }
    }
}
