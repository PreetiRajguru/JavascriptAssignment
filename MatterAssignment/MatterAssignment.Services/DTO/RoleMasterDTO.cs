using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterAssignment.Services.DTO
{
    public class RoleMasterDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
