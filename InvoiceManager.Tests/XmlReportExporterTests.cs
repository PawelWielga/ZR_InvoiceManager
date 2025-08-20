using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using NUnit.Framework;
using InvoiceManager.Utils.ReportExporters.Exporters;

namespace InvoiceManager.Tests;

[TestFixture]
public class XmlReportExporterTests
{
    public class TestItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    [Test]
    public void Export_WritesValidXmlFile()
    {
        var exporter = new XmlReportExporter<TestItem>();
        var items = new List<TestItem>
        {
            new TestItem { Id = 1, Name = "A" },
            new TestItem { Id = 2, Name = "B" }
        };
        var path = Path.GetTempFileName();
        try
        {
            exporter.Export(items, path);
            var serializer = new XmlSerializer(typeof(List<TestItem>));
            using var reader = new StreamReader(path);
            var result = (List<TestItem>)serializer.Deserialize(reader)!;
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].Id, Is.EqualTo(1));
            Assert.That(result[1].Name, Is.EqualTo("B"));
        }
        finally
        {
            File.Delete(path);
        }
    }
}
