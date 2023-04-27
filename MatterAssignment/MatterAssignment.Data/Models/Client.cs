﻿namespace MatterAssignment.Data.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public long PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Matter> Matters { get; set; }
    }
}
