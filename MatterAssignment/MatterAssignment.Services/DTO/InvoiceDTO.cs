using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace MatterAssignment.Services.DTO
{
    public class InvoiceDTO
    {
        [JsonIgnore]
        public int Id { get; set; }

        public decimal HoursWorked { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime InvoiceDate { get; set; }

        public int AttorneyId { get; set; }

        public int MatterId { get; set; }
    }
}


/*
public class InvoiceDTO
{
    [JsonIgnore]
    public int Id { get; set; }

    public decimal HoursWorked { get; set; }

    public decimal TotalAmount { get; set; }

    public DateTime InvoiceDate { get; set; }

    public int AttorneyId { get; set; }

    public int MatterId { get; set; }
}CreateComInterfaceFlags a interface service and controller method for 
 showing Last weeks Billing by Attorney id*/