using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MatterAssignment.Services.DTO
{
    public class AttorneyDTO
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Rate { get; set; }

        public int JurisdictionId { get; set; }
    }
}
