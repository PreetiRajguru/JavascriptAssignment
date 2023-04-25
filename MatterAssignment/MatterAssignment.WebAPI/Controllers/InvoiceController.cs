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
            return _invoiceService.GetAllInvoices();
        }

        [HttpGet("{id}")]
        public ActionResult<InvoiceDTO> GetById(int id)
        {
            var invoice = _invoiceService.GetInvoiceById(id);
            if (invoice == null) return NotFound();
            return invoice;
        }

        [HttpPost]
        public ActionResult<InvoiceDTO> Create(InvoiceDTO invoice)
        {
            _invoiceService.CreateInvoice(invoice);
            return CreatedAtAction(nameof(GetById), new { id = invoice.Id }, invoice);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _invoiceService.DeleteInvoice(id);
            return NoContent();
        }


        [HttpGet("matter/{matterId}")]
        public ActionResult<InvoiceDTO> GetInvoiceByMatterId(int matterId)
        {
            var invoiceDto = _invoiceService.GetInvoiceByMatterId(matterId);

            if (invoiceDto == null)
            {
                return NotFound();
            }

            return Ok(invoiceDto);
        }


        [HttpGet("grouped-by-matter")]
        public IActionResult GetInvoicesGroupedByMatter()
        {
            var groupedInvoices = _invoiceService.GetInvoicesGroupedByMatterId();

            return Ok(groupedInvoices);
        }

    }
}

