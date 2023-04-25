﻿using MatterAssignment.Services.DTO;
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
            var invoice = _invoiceService.GetById(id);
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
        public ActionResult<InvoiceDTO> GetInvoiceByMatter(int matterId)
        {
            var invoiceDto = _invoiceService.GetInvoiceByMatter(matterId);

            if (invoiceDto == null)
            {
                return NotFound();
            }

            return Ok(invoiceDto);
        }


        [HttpGet("matter")]
        public IActionResult GetInvoicesForMatters()
        {
            var groupedInvoices = _invoiceService.GetInvoicesForMatters();

            return Ok(groupedInvoices);
        }


        [HttpGet("billing/{attorneyId}")]
        public IActionResult GetBillingByAttorney(int attorneyId)
        {
            var totalBilling = _invoiceService.GetBillingByAttorney(attorneyId);

            if (totalBilling == null)
            {
                return NotFound();
            }

            return Ok(new { AttorneyId = attorneyId, Billing = totalBilling });
        }





     /*   [HttpGet]
        public ActionResult<Dictionary<int, double>> GetAllBillingByAttorney()
        {
            var billingByAttorney = _invoiceService.GetAllBillingByAttorney();

            if (billingByAttorney == null || billingByAttorney.Count == 0)
            {
                return NotFound();
            }

            return Ok(billingByAttorney);
        }*/


        /*   [HttpGet("last-week-by-attorney/{attorneyId}")]
           public IActionResult GetTotalBillingByAttorneyLastWeek(int attorneyId)
           {
               decimal totalBilling = _invoiceService.GetTotalBillingByAttorneyLastWeek(attorneyId);
               if (totalBilling == 0)
               {
                   return NotFound();
               }
               return Ok(totalBilling);
           }*/
    }
}

