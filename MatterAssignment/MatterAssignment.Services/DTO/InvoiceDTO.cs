using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterAssignment.Services.DTO
{
    public class InvoiceDTO
    {
        public int Id { get; set; }

        public decimal HoursWorked { get; set; }

        public int AttorneyId { get; set; }

        public int MatterId { get; set; }
    }
}
