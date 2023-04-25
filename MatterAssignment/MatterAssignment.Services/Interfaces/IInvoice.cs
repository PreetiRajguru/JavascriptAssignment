using MatterAssignment.Services.DTO;

namespace MatterAssignment.Services.Interfaces
{
    public interface IInvoice
    {
        IEnumerable<InvoiceDTO> GetAll();
        InvoiceDTO GetById(int id);
        void Create(InvoiceDTO invoice);
        void Delete(int id);
        InvoiceDTO GetInvoiceByMatter(int matterId);
        Dictionary<int, List<InvoiceDTO>> GetInvoicesForMatters();

        double GetBillingByAttorney(int attorneyId);



        /*  Dictionary<int, double> GetAllBillingByAttorney();*/

        /*  decimal GetTotalBillingByAttorneyLastWeek(int attorneyId);*/
    }
}
