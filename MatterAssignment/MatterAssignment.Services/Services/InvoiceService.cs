using MatterAssignment.Data.Context;
using MatterAssignment.Data.Models;
using MatterAssignment.Services.DTO;
using MatterAssignment.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MatterAssignment.Services.Services
{

    public class InvoiceService : IInvoice
    {
        private readonly MatterAssignmentDbContext _dbContext;

        public InvoiceService(MatterAssignmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<InvoiceDTO> GetAllInvoices()
        {
            return _dbContext.Invoices.Select(i => new InvoiceDTO
            {
                Id = i.Id,
                HoursWorked = i.HoursWorked,
                AttorneyId = i.AttorneyId,
                MatterId = i.MatterId
            });
        }

        public InvoiceDTO GetInvoiceById(int id)
        {
            var invoice = _dbContext.Invoices.FirstOrDefault(i => i.Id == id);
            if (invoice == null) return null;
            return new InvoiceDTO
            {
                Id = invoice.Id,
                HoursWorked = invoice.HoursWorked,
                AttorneyId = invoice.AttorneyId,
                MatterId = invoice.MatterId
            };
        }

        public void CreateInvoice(InvoiceDTO invoice)
        {
            var newInvoice = new Invoice
            {
                HoursWorked = invoice.HoursWorked,
                AttorneyId = invoice.AttorneyId,
                MatterId = invoice.MatterId
            };
            _dbContext.Invoices.Add(newInvoice);
            _dbContext.SaveChanges();
            invoice.Id = newInvoice.Id;
        }

        public void DeleteInvoice(int id)
        {
            var invoice = _dbContext.Invoices.FirstOrDefault(i => i.Id == id);
            if (invoice == null) return;
            _dbContext.Invoices.Remove(invoice);
            _dbContext.SaveChanges();
        }



        public InvoiceDTO GetInvoiceByMatterId(int matterId)
        {
            using (var dbContext = new MatterAssignmentDbContext())
            {
                var invoice = dbContext.Invoices
                    .Where(i => i.MatterId == matterId)
                    .Include(i => i.Attorney)
                    .FirstOrDefault();

                if (invoice == null)
                {
                    return null;
                }

                var invoiceDTO = new InvoiceDTO
                {
                    Id = invoice.Id,
                    HoursWorked = invoice.HoursWorked,
                    AttorneyId = invoice.Attorney.Id,
                    MatterId = invoice.MatterId
                };

                return invoiceDTO;
            }
        }


        
    }
}
