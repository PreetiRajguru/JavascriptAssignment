using MatterAssignment.Services.DTO;

namespace MatterAssignment.Services.Interfaces
{
    public interface IInvoice
    {
        IEnumerable<InvoiceDTO> GetAllInvoices();
        InvoiceDTO GetInvoiceById(int id);
        void CreateInvoice(InvoiceDTO invoice);
        void DeleteInvoice(int id);
        InvoiceDTO GetInvoiceByMatterId(int matterId);

    }
}
