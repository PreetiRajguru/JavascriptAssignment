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
            return _dbContext.Invoices.Select(i => new InvoiceDTO
            {
                Id = i.Id,
                HoursWorked = i.HoursWorked,
                TotalAmount = i.TotalAmount,
                InvoiceDate = i.InvoiceDate,
                AttorneyId = i.AttorneyId,
                MatterId = i.MatterId
            });
        }

        public InvoiceDTO GetById(int id)
        {
            Invoice invoice = _dbContext.Invoices.FirstOrDefault(i => i.Id == id);
            if (invoice == null) return null;
            return new InvoiceDTO
            {
                Id = invoice.Id,
                HoursWorked = invoice.HoursWorked,
                TotalAmount = invoice.TotalAmount,
                InvoiceDate = invoice.InvoiceDate,
                AttorneyId = invoice.AttorneyId,
                MatterId = invoice.MatterId
            };
        }

        public void Create(InvoiceDTO invoice)
        {
            decimal attorneyRate = _dbContext.Attorneys.Where(a => a.Id ==  invoice.AttorneyId).Select (  a => a.Rate).First();
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

        public InvoiceDTO GetInvoiceByMatter(int matterId)
        {
            using (MatterAssignmentDbContext dbContext = new MatterAssignmentDbContext())
            {
                Invoice invoice = dbContext.Invoices
                    .Where(i => i.MatterId == matterId)
                    .Include(i => i.Attorney)
                    .FirstOrDefault();

                if (invoice == null)
                {
                    return null;
                }

                InvoiceDTO invoiceDTO = new InvoiceDTO
                {
                    Id = invoice.Id,
                    HoursWorked = invoice.HoursWorked,
                    TotalAmount = invoice.TotalAmount,
                    InvoiceDate = invoice.InvoiceDate,
                    AttorneyId = invoice.Attorney.Id,
                    MatterId = invoice.MatterId
                };

                return invoiceDTO;
            }
        }

        public Dictionary<int, List<InvoiceDTO>> GetInvoicesForMatters()
        {
            List<Invoice> invoices = _dbContext.Invoices.ToList();

            Dictionary<int, List<InvoiceDTO>> groupedInvoices = invoices.GroupBy(i => i.MatterId)
                                          .ToDictionary(g => g.Key,
                                                        g => g.Select(i => new InvoiceDTO
                                                        {
                                                            TotalAmount = i.TotalAmount,
                                                            InvoiceDate = i.InvoiceDate,
                                                            HoursWorked = i.HoursWorked,
                                                            AttorneyId = i.AttorneyId
                                                        }).ToList());
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