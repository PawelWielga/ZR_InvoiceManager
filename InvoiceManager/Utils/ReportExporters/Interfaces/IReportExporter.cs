using System.Collections.Generic;

namespace InvoiceManager.Utils.ReportExporters.Interfaces;

public interface IReportExporter<T>
{
    void Export(IEnumerable<T> data, string filePath);
}