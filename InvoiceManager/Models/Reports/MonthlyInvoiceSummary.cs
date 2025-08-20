namespace InvoiceManager.Models.Reports;

public class MonthlyInvoiceSummary
{
    public int Year { get; set; }
    public int Month { get; set; }
    public decimal TotalNet { get; set; }
    public decimal TotalGross { get; set; }
}
