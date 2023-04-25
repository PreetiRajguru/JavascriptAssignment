using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterAssignment.Services.DTO
{
    public class ClientMatterDTO
    {
        public int ClientId { get; set; }

        public IEnumerable<MatterDTO> Matters { get; set;}
    }
}
