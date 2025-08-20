using InvoiceManager.Enums;

namespace InvoiceManager.Utils.ReportExporters.Interfaces;

public interface IReportExporterFactory<T>
{
    IReportExporter<T> GetExporter(ReportFormat format);
}