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

        public IEnumerable<InvoiceDTO> GetAll()
        {
            var invoices = _dbContext.Invoices.Select(i => new InvoiceDTO
            {
                Id = i.Id,
                HoursWorked = i.HoursWorked,
                TotalAmount = i.TotalAmount,
                InvoiceDate = i.InvoiceDate,
                AttorneyId = i.AttorneyId,
                MatterId = i.MatterId
            });
            return invoices;
        }

        public InvoiceDTO[] GetById(int id)
        {
            var invoices = _dbContext.Invoices
                .Where(i => i.Id == id)
                .Select(i => new InvoiceDTO
                {
                    Id = i.Id,
                    HoursWorked = i.HoursWorked,
                    TotalAmount = i.TotalAmount,
                    InvoiceDate = i.InvoiceDate,
                    AttorneyId = i.AttorneyId,
                    MatterId = i.MatterId
                })
                .ToArray();

            return invoices;
        }

        public void Create(InvoiceDTO invoice)
        {
            decimal attorneyRate = _dbContext.Attorneys.Where(a => a.Id == invoice.AttorneyId).Select(a => a.Rate).First();
            Invoice newInvoice = new Invoice
            {
                HoursWorked = invoice.HoursWorked,
                TotalAmount = invoice.HoursWorked * attorneyRate,
                InvoiceDate = invoice.InvoiceDate,
                AttorneyId = invoice.AttorneyId,
                MatterId = invoice.MatterId
            };
            _dbContext.Invoices.Add(newInvoice);
            _dbContext.SaveChanges();
            invoice.Id = newInvoice.Id;
        }

        public void Delete(int id)
        {
            Invoice invoice = _dbContext.Invoices.FirstOrDefault(i => i.Id == id);
            if (invoice == null) return;
            _dbContext.Invoices.Remove(invoice);
            _dbContext.SaveChanges();
        }

        public List<InvoiceForMatterDTO> GetInvoicesByMatterId(int matterId)
        {
            IQueryable<Invoice> invoices = _dbContext.Invoices
                .Include(i => i.Matter)
                .Where(i => i.MatterId.Equals(matterId));

            List<InvoiceForMatterDTO> invoiceMatter = new List<InvoiceForMatterDTO>();

            foreach (var item in invoices)
            {
                var attorney = _dbContext.Attorneys.Where(s => s.Id == item.AttorneyId).FirstOrDefault();
                invoiceMatter.Add(new InvoiceForMatterDTO { AttorneyName = attorney.Name, Id = item.Id });
            }

            return invoiceMatter;
        }


        public IEnumerable<MatterInvoiceDTO> GetInvoicesByMatters()
        {
            List<Invoice> invoices = _dbContext.Invoices.ToList();

            IEnumerable<MatterInvoiceDTO> groupedInvoices = invoices.GroupBy(i => i.MatterId)
                                           .Select(g => new MatterInvoiceDTO
                                           {
                                               MatterId = g.Key,
                                               Invoices = g.Select(i => new InvoiceDTO
                                               {
                                                   TotalAmount = i.TotalAmount,
                                                   InvoiceDate = i.InvoiceDate,
                                                   HoursWorked = i.HoursWorked,
                                                   AttorneyId = i.AttorneyId
                                               }).ToList()
                                           });
            return groupedInvoices;
        }

        public double GetBillingByAttorney(int attorneyId)
        {
            DateTime today = DateTime.Today;
            DateTime previousWeekStart = today.AddDays(-(int)today.DayOfWeek - 6);
            DateTime previousWeekEnd = previousWeekStart.AddDays(6);

            decimal billing = _dbContext.Invoices
                .Where(i => i.AttorneyId == attorneyId && i.InvoiceDate >= previousWeekStart && i.InvoiceDate <= previousWeekEnd)
                .Sum(im => im.TotalAmount);

            return Convert.ToDouble(billing);
        }
    }
}