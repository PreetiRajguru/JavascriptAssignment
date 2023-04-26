using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterAssignment.Services.DTO
{
    public class MatterInvoiceDTO
    {
        public int MatterId { get; set; }

        public IEnumerable<InvoiceDTO> Invoices { get; set; }
    }
}
