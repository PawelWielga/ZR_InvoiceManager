using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using InvoiceManager.Utils.ReportExporters.Interfaces;

namespace InvoiceManager.Utils.ReportExporters.Exporters;

public class CsvReportExporter<T> : IReportExporter<T>
{
    public void Export(IEnumerable<T> data, string filePath)
    {
        var list = data.ToList();
        using var writer = new StreamWriter(filePath, false, Encoding.UTF8);
        var props = typeof(T).GetProperties();
        writer.WriteLine(string.Join(";", props.Select(p => p.Name)));
        foreach (var item in list)
        {
            var values = props.Select(p => p.GetValue(item)?.ToString() ?? string.Empty);
            writer.WriteLine(string.Join(";", values));
        }
    }
}