using MatterAssignment.Services.DTO;

namespace MatterAssignment.Services.Interfaces
{
    public interface IInvoice
    {
        IEnumerable<InvoiceDTO> GetAllInvoices();
        InvoiceDTO GetInvoiceById(int id);
        void CreateInvoice(InvoiceDTO invoice);
        void DeleteInvoice(int id);
        InvoiceDTO GetInvoiceByMatter(int matterId);
        Dictionary<int, List<InvoiceDTO>> GetInvoicesForMatters();

        double GetBillingByAttorney(int attorneyId);



        /*  Dictionary<int, double> GetAllBillingByAttorney();*/

        /*  decimal GetTotalBillingByAttorneyLastWeek(int attorneyId);*/
    }
}
