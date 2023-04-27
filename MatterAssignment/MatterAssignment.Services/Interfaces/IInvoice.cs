using MatterAssignment.Services.DTO;

namespace MatterAssignment.Services.Interfaces
{
    public interface IInvoice
    {
        IEnumerable<InvoiceDTO> GetAll();

        InvoiceDTO[] GetById(int id);

        void Create(InvoiceDTO invoice);

        void Delete(int id);

        List<InvoiceForMatterDTO> GetInvoicesByMatterId(int matterId);

        IEnumerable<MatterInvoiceDTO> GetInvoicesByMatters();

        double GetBillingByAttorney(int attorneyId);
    }
}
