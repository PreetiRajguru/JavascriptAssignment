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
        public ActionResult<IEnumerable<InvoiceDTO>> GetAllInvoices()
        {
            var invoices = _invoiceService.GetAll();
            return Ok(invoices);
        }

        [HttpGet("{id}")]
        public ActionResult<InvoiceDTO[]> GetInvoicesById(int id)
        {
            var invoices = _invoiceService.GetById(id);

            if (invoices.Length == 0)
            {
                return NotFound();
            }

            return Ok(invoices);
        }

        [HttpPost]
        public ActionResult<InvoiceDTO> Create(InvoiceDTO invoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _invoiceService.Create(invoice);
                return CreatedAtAction(nameof(GetInvoicesById), new { id = invoice.Id }, invoice);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating the invoice. Error message: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _invoiceService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the invoice with ID {id}. Error message: {ex.Message}");
            }
        }


        [HttpGet("bymatterid/{id}")]
        public IActionResult GetInvoicesByMatterId(int id)
        {
            try
            {
                List<InvoiceForMatterDTO> invoices = _invoiceService.GetInvoicesByMatterId(id);

                if (invoices == null)
                {
                    return NotFound();
                }

                return Ok(invoices);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("matter")]
        public IActionResult GetInvoicesByMatters()
        {
            try
            {
                var groupedInvoices = _invoiceService.GetInvoicesByMatters();
                return Ok(groupedInvoices);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving the invoices by matters. Error message: {ex.Message}");
            }
        }


        [HttpGet("billing/{attorneyId}")]
        public IActionResult GetBillingByAttorney(int attorneyId)
        {
            try
            {
                var totalBilling = _invoiceService.GetBillingByAttorney(attorneyId);
                if (totalBilling == null)
                {
                    return NotFound();
                }
                return Ok(new { AttorneyId = attorneyId, Billing = totalBilling });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving the billing for attorney with ID {attorneyId}. Error message: {ex.Message}");
            }
        }
    }
}
