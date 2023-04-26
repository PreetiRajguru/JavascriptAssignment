using MatterAssignment.Services.DTO;
using MatterAssignment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MatterAssignment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoice _invoiceService;

        public InvoiceController(IInvoice invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public IEnumerable<InvoiceDTO> GetAll()
        {
            return _invoiceService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<InvoiceDTO> GetById(int id)
        {
            InvoiceDTO invoice = _invoiceService.GetById(id);
            if (invoice == null) return NotFound();
            return invoice;
        }

        [HttpPost]
        public ActionResult<InvoiceDTO> Create(InvoiceDTO invoice)
        {
            _invoiceService.Create(invoice);
            return CreatedAtAction(nameof(GetById), new { id = invoice.Id }, invoice);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _invoiceService.Delete(id);
            return NoContent();
        }


        [HttpGet("matter/{matterId}")]
        public ActionResult<InvoiceDTO> GetInvoiceForMatter(int matterId)
        {
            InvoiceDTO invoiceDto = _invoiceService.GetInvoiceForMatter(matterId);

            if (invoiceDto == null)
            {
                return NotFound();
            }

            return Ok(invoiceDto);
        }


        [HttpGet("matter")]
        public IActionResult GetInvoicesByMatters()
        {
            IEnumerable<MatterInvoiceDTO> groupedInvoices = _invoiceService.GetInvoicesByMatters();

            return Ok(groupedInvoices);
        }


        [HttpGet("billing/{attorneyId}")]
        public IActionResult GetBillingByAttorney(int attorneyId)
        {
            double totalBilling = _invoiceService.GetBillingByAttorney(attorneyId);

            if (totalBilling == null)
            {
                return NotFound();
            }

            return Ok(new { AttorneyId = attorneyId, Billing = totalBilling });
        }
    }
}

