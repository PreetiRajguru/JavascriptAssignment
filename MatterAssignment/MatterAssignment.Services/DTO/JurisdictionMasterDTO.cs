using Newtonsoft.Json;

namespace MatterAssignment.Services.DTO
{
    public class JurisdictionMasterDTO
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string JurisdictionName { get; set; }
    }
}
