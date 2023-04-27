using Newtonsoft.Json;

namespace MatterAssignment.Services.DTO
{
    public class RoleMasterDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
