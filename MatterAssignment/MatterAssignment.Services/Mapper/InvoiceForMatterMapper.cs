using MatterAssignment.Data.Models;
using MatterAssignment.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterAssignment.Services.Mapper
{
    public class InvoiceForMatterMapper
    {

        public InvoiceForMatterDTO Map(Invoice entity)
        {
            return new InvoiceForMatterDTO
            {
                Id = entity.Id,
                HoursWorked = entity.HoursWorked,
                TotalAmount = entity.TotalAmount,
                InvoiceDate = entity.InvoiceDate,
                Mattername = entity.Matter.Title,
                //Attorney = entity.Attorney
                //BillingAttorneyName = entity.Attorney.Name,
            };
        }
    }
}
