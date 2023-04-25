using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterAssignment.Data.Models
{
    public class AttorneyRole
    {
        public int Id { get; set; }

        public int AttorneyId { get; set; }
        public int RoleMasterId { get; set; }

        public Attorney Attorney { get; set; }
        public RoleMaster RoleMaster { get; set; }
        public string RoleName { get; set; }
    }
}
