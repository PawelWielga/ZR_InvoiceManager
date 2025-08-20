using System.Collections.Generic;
using System.Threading.Tasks;
using InvoiceManager.Models.Reports;

namespace InvoiceManager.Services.Interfaces;

public interface IReportService
{
    Task<IEnumerable<CustomerInvoicesReport>> GetInvoicesTotalsByCustomerAsync();
    Task<IEnumerable<MonthlyInvoiceSummary>> GetMonthlyInvoiceSummaryAsync();
    Task<IEnumerable<CountryCustomerCount>> GetCustomerCountByCountryAsync();
}
