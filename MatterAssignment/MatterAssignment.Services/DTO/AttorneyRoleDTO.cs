using System.Text.Json.Serialization;

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
