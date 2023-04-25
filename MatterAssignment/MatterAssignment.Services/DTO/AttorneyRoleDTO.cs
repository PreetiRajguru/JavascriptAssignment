using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MatterAssignment.Services.DTO
{
    public class AttorneyRoleDTO
    {
        [JsonIgnore]
        public int Id { get; set; }

        public int AttorneyId { get; set; }

        public int RoleMasterId { get; set; }
    }
}
