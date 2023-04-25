namespace MatterAssignment.Data.Models
{
    public class RoleMaster
    {
        public int Id { get; set; }

        public string RoleName { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<AttorneyRole> AttorneyRoles { get; set; }
    }
}
