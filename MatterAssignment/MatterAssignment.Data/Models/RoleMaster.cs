using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterAssignment.Data.Models
{
    public class RoleMaster
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public ICollection<AttorneyRole> AttorneyRoles { get; set; }
    }
}
