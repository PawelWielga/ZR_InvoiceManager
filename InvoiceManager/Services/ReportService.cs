using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceManager.Data.Context;
using InvoiceManager.Models.Reports;
using InvoiceManager.Services.Interfaces;

namespace InvoiceManager.Services;

public class ReportService(AppDbContext context) : IReportService
{
    public async Task<IEnumerable<CustomerInvoicesReport>> GetInvoicesTotalsByCustomerAsync()
    {
        return await context.Invoices
            .Include(i => i.Customer)
            .GroupBy(i => i.Customer.Name)
            .Select(g => new CustomerInvoicesReport
            {
                CustomerName = g.Key,
                InvoiceCount = g.Count(),
                TotalNetAmount = g.Sum(i => i.NetAmount)
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<MonthlyInvoiceSummary>> GetMonthlyInvoiceSummaryAsync()
    {
        return await context.Invoices
            .GroupBy(i => new { i.SaleDate.Year, i.SaleDate.Month })
            .Select(g => new MonthlyInvoiceSummary
            {
                Year = g.Key.Year,
                Month = g.Key.Month,
                TotalNet = g.Sum(i => i.NetAmount),
                TotalGross = g.Sum(i => i.NetAmount * (1 + i.VatRate / 100m))
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<CountryCustomerCount>> GetCustomerCountByCountryAsync()
    {
        return await context.Customers
            .GroupBy(c => c.Country)
            .Select(g => new CountryCustomerCount
            {
                Country = g.Key,
                CustomerCount = g.Count()
            })
            .ToListAsync();
    }
}
