namespace MatterAssignment.Services.DTO
{
    public class MatterInvoiceDTO
    {
        public int MatterId { get; set; }

        public IEnumerable<InvoiceDTO> Invoices { get; set; }
    }
}
