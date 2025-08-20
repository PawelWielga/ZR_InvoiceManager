using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using InvoiceManager.Enums;
using InvoiceManager.Infrastructure;
using InvoiceManager.Models.Reports;
using InvoiceManager.Services.Interfaces;
using InvoiceManager.Utils.ReportExporters.Services;

namespace InvoiceManager.ViewModels.Reports;

public class ReportsViewModel : BaseViewModel
{
    private readonly IReportService _reportService;
    private readonly ReportProcessor<CustomerInvoicesReport> _invoicesByCustomerProcessor;
    private readonly ReportProcessor<MonthlyInvoiceSummary> _monthlySummariesProcessor;
    private readonly ReportProcessor<CountryCustomerCount> _customersByCountryProcessor;

    public ObservableCollection<CustomerInvoicesReport> InvoicesByCustomer { get; }
    public ObservableCollection<MonthlyInvoiceSummary> MonthlySummaries { get; }
    public ObservableCollection<CountryCustomerCount> CustomersByCountry { get; }

    public ReportsViewModel(
        IReportService reportService,
        ReportProcessor<CustomerInvoicesReport> invoicesByCustomerProcessor,
        ReportProcessor<MonthlyInvoiceSummary> monthlySummariesProcessor,
        ReportProcessor<CountryCustomerCount> customersByCountryProcessor)
    {
        _reportService = reportService ?? throw new ArgumentNullException(nameof(reportService));
        _invoicesByCustomerProcessor = invoicesByCustomerProcessor ?? throw new ArgumentNullException(nameof(invoicesByCustomerProcessor));
        _monthlySummariesProcessor = monthlySummariesProcessor ?? throw new ArgumentNullException(nameof(monthlySummariesProcessor));
        _customersByCountryProcessor = customersByCountryProcessor ?? throw new ArgumentNullException(nameof(customersByCountryProcessor));

        InvoicesByCustomer = [];
        MonthlySummaries = [];
        CustomersByCountry = [];
    }

    public async Task LoadDataAsync()
    {
        InvoicesByCustomer.Clear();
        var byCustomer = await _reportService.GetInvoicesTotalsByCustomerAsync();
        foreach (var item in byCustomer) InvoicesByCustomer.Add(item);

        MonthlySummaries.Clear();
        var monthly = await _reportService.GetMonthlyInvoiceSummaryAsync();
        foreach (var item in monthly) MonthlySummaries.Add(item);

        CustomersByCountry.Clear();
        var byCountry = await _reportService.GetCustomerCountByCountryAsync();
        foreach (var item in byCountry) CustomersByCountry.Add(item);
    }

    public void ExportInvoicesByCustomer(string filePath, ReportFormat format)
    {
        _invoicesByCustomerProcessor.ProcessAndExport(InvoicesByCustomer, filePath, format);
    }

    public void ExportMonthlySummaries(string filePath, ReportFormat format)
    {
        _monthlySummariesProcessor.ProcessAndExport(MonthlySummaries, filePath, format);
    }

    public void ExportCustomersByCountry(string filePath, ReportFormat format)
    {
        _customersByCountryProcessor.ProcessAndExport(CustomersByCountry, filePath, format);
    }
}