using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using InvoiceManager.Utils.ReportExporters.Interfaces;

namespace InvoiceManager.Utils.ReportExporters.Exporters;

public class XmlReportExporter<T> : IReportExporter<T>
{
    public void Export(IEnumerable<T> data, string filePath)
    {
        var serializer = new XmlSerializer(typeof(List<T>));
        using var writer = new StreamWriter(filePath, false, Encoding.UTF8);
        serializer.Serialize(writer, data.ToList());
    }
}