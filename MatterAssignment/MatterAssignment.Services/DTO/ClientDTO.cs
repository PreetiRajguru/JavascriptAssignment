﻿using System.Text.Json.Serialization;

namespace MatterAssignment.Services.DTO
{
    public class ClientDTO
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public long PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
    }
}
