namespace MatterAssignment.Data.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        public decimal HoursWorked { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime InvoiceDate { get; set; }

        public int AttorneyId { get; set; }

        public Attorney Attorney { get; set; }

        public int MatterId { get; set; }

        public Matter Matter { get; set; }

        public bool IsDeleted { get; set; }
    }
}
