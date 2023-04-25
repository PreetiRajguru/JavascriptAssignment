namespace MatterAssignment.Data.Models
{
    public class AttorneyRole
    {
        public int Id { get; set; }

        public int AttorneyId { get; set; }
        public int RoleMasterId { get; set; }

        public Attorney Attorney { get; set; }
        public RoleMaster RoleMaster { get; set; }

        public bool IsDeleted { get; set; }
    }
}
