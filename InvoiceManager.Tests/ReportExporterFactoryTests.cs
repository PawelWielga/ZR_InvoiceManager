using System;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using InvoiceManager.Enums;
using InvoiceManager.Utils.ReportExporters.Exporters;
using InvoiceManager.Utils.ReportExporters.Factories;
using InvoiceManager.Utils.ReportExporters.Interfaces;

namespace InvoiceManager.Tests;

[TestFixture]
public class ReportExporterFactoryTests
{
    private ServiceProvider _provider = null!;

    private class TestItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    [SetUp]
    public void SetUp()
    {
        var services = new ServiceCollection();
        services.AddTransient<CsvReportExporter<TestItem>>();
        services.AddTransient<XmlReportExporter<TestItem>>();
        _provider = services.BuildServiceProvider();
    }

    [Test]
    public void GetExporter_CsvFormat_ReturnsCsvExporter()
    {
        var factory = new ReportExporterFactory<TestItem>(_provider);

        var exporter = factory.GetExporter(ReportFormat.Csv);

        Assert.IsInstanceOf<CsvReportExporter<TestItem>>(exporter);
    }

    [Test]
    public void GetExporter_XmlFormat_ReturnsXmlExporter()
    {
        var factory = new ReportExporterFactory<TestItem>(_provider);

        var exporter = factory.GetExporter(ReportFormat.Xml);

        Assert.IsInstanceOf<XmlReportExporter<TestItem>>(exporter);
    }

    [Test]
    public void GetExporter_UnsupportedFormat_ThrowsArgumentException()
    {
        var factory = new ReportExporterFactory<TestItem>(_provider);

        Assert.Throws<ArgumentException>(() => factory.GetExporter((ReportFormat)99));
    }
}
