namespace MatterAssignment.Services.DTO
{
    public class InvoiceForMatterDTO
    {

        public int Id { get; set; }

        public decimal HoursWorked { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime InvoiceDate { get; set; }

        public string BillingAttorneyName { get; set; }

        public string AttorneyName { get; set; }

        public string ResponsibleAttorneyName { get; set; }

        public string Mattername { get; set; }

    }
}
