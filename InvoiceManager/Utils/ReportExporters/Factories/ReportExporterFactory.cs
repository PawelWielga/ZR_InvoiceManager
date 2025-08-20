using System;
using Microsoft.Extensions.DependencyInjection;
using InvoiceManager.Utils.ReportExporters.Interfaces;
using InvoiceManager.Utils.ReportExporters.Exporters;
using InvoiceManager.Enums;

namespace InvoiceManager.Utils.ReportExporters.Factories;

public class ReportExporterFactory<T>(IServiceProvider serviceProvider) : IReportExporterFactory<T>
{
    private readonly IServiceProvider _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

    public IReportExporter<T> GetExporter(ReportFormat format)
    {
        return format switch
        {
            ReportFormat.Csv => _serviceProvider.GetRequiredService<CsvReportExporter<T>>(),
            ReportFormat.Xml => _serviceProvider.GetRequiredService<XmlReportExporter<T>>(),
            _ => throw new ArgumentException($"Unsupported report format: {format}", nameof(format))
        };
    }
}