using MatterAssignment.Data.Models;
using MatterAssignment.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterAssignment.Services.Mapper
{
    public class MattersForClientMapper
    {
        public MatterForClientDTO Map(Matter entity)
        {
            return new MatterForClientDTO
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                ClientFirstName = entity.Client.FirstName,
                ClientLastName = entity.Client.LastName,
                JurisdictionArea = entity.Jurisdiction.JurisdictionName,
                BillingAttorneyName = entity.Attorney.Name,
                ResponsibleAttorneyName = entity.Attorney.Name
            };
        }
    }
}
