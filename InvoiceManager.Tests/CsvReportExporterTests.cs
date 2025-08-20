using System.IO;
using NUnit.Framework;
using InvoiceManager.Utils.ReportExporters.Exporters;

namespace InvoiceManager.Tests;

[TestFixture]
public class CsvReportExporterTests
{
    private class TestItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    [Test]
    public void Export_WritesValidCsvFile()
    {
        var exporter = new CsvReportExporter<TestItem>();
        var data = new[]
        {
            new TestItem { Id = 1, Name = "A" },
            new TestItem { Id = 2, Name = "B" }
        };
        var path = Path.GetTempFileName();
        try
        {
            exporter.Export(data, path);
            var lines = File.ReadAllLines(path);
            Assert.That(lines.Length, Is.EqualTo(3));
            Assert.That(lines[0], Is.EqualTo("Id;Name"));
            Assert.That(lines[1], Is.EqualTo("1;A"));
            Assert.That(lines[2], Is.EqualTo("2;B"));
        }
        finally
        {
            File.Delete(path);
        }
    }
}
