using System;
using System.Collections.Generic;
using InvoiceManager.Enums;
using InvoiceManager.Utils.ReportExporters.Interfaces;

namespace InvoiceManager.Utils.ReportExporters.Services;

public class ReportProcessor<T>(IReportExporterFactory<T> exporterFactory)
{
    private readonly IReportExporterFactory<T> _exporterFactory = exporterFactory ?? throw new ArgumentNullException(nameof(exporterFactory));

    public void ProcessAndExport(IEnumerable<T> data, string filePath, ReportFormat format)
    {
        var exporter = _exporterFactory.GetExporter(format);
        exporter.Export(data, filePath);
    }
}