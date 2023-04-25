namespace MatterAssignment.Services.DTO
{
    public class InvoiceDTO
    {
        public int Id { get; set; }

        public decimal HoursWorked { get; set; }

        public int AttorneyId { get; set; }

        public int MatterId { get; set; }
    }
}



/*
public class InvoiceDTO
{
    public int Id { get; set; }

    public decimal HoursWorked { get; set; }

    public int AttorneyId { get; set; }

    public int MatterId { get; set; }
}
for this dto create a interface service method  and controller method for get invoices by matter (use group by in linq and group 
invoices according to matter)*/