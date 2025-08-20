namespace InvoiceManager.Models.Reports;

public class CustomerInvoicesReport
{
    public string CustomerName { get; set; } = string.Empty;
    public int InvoiceCount { get; set; }
    public decimal TotalNetAmount { get; set; }
}
