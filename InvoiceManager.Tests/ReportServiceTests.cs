using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using InvoiceManager.Data.Context;
using InvoiceManager.Models;
using InvoiceManager.Models.Reports;
using InvoiceManager.Services;

namespace InvoiceManager.Tests;

[TestFixture]
public class ReportServiceTests
{
    private static AppDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        return new AppDbContext(options);
    }

    [Test]
    public async Task GetInvoicesTotalsByCustomerAsync_ReturnsCorrectTotals()
    {
        using var context = CreateContext();
        var c1 = new Customer { Name = "A", TaxId = "1" };
        var c2 = new Customer { Name = "B", TaxId = "2" };
        context.Customers.AddRange(c1, c2);
        context.SaveChanges();
        context.Invoices.AddRange(
            new Invoice { InvoiceNumber = "1", NetAmount = 100m, VatRate = 23m, SaleDate = DateTime.Today, CustomerId = c1.Id, Customer = c1 },
            new Invoice { InvoiceNumber = "2", NetAmount = 50m, VatRate = 23m, SaleDate = DateTime.Today, CustomerId = c1.Id, Customer = c1 },
            new Invoice { InvoiceNumber = "3", NetAmount = 30m, VatRate = 23m, SaleDate = DateTime.Today, CustomerId = c2.Id, Customer = c2 }
        );
        context.SaveChanges();
        var service = new ReportService(context);

        var result = (await service.GetInvoicesTotalsByCustomerAsync()).ToList();

        Assert.AreEqual(2, result.Count);
        var first = result.First(r => r.CustomerName == "A");
        Assert.AreEqual(2, first.InvoiceCount);
        Assert.AreEqual(150m, first.TotalNetAmount);
    }

    [Test]
    public async Task GetMonthlyInvoiceSummaryAsync_ReturnsMonthlyTotals()
    {
        using var context = CreateContext();
        context.Invoices.AddRange(
            new Invoice { InvoiceNumber = "1", NetAmount = 10m, VatRate = 20m, SaleDate = new DateTime(2024, 1, 15), CustomerId = 1 },
            new Invoice { InvoiceNumber = "2", NetAmount = 20m, VatRate = 20m, SaleDate = new DateTime(2024, 1, 20), CustomerId = 1 },
            new Invoice { InvoiceNumber = "3", NetAmount = 30m, VatRate = 20m, SaleDate = new DateTime(2024, 2, 5), CustomerId = 1 }
        );
        context.SaveChanges();
        var service = new ReportService(context);

        var result = (await service.GetMonthlyInvoiceSummaryAsync()).OrderBy(r => r.Month).ToList();

        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(1, result[0].Month);
        Assert.AreEqual(30m, result[0].TotalNet);
        Assert.AreEqual(1 + 0.2m, (result[0].TotalGross / result[0].TotalNet));
    }

    [Test]
    public async Task GetCustomerCountByCountryAsync_ReturnsCounts()
    {
        using var context = CreateContext();
        context.Customers.AddRange(
            new Customer { Name = "A", TaxId = "1", Country = "PL" },
            new Customer { Name = "B", TaxId = "2", Country = "PL" },
            new Customer { Name = "C", TaxId = "3", Country = "DE" }
        );
        context.SaveChanges();
        var service = new ReportService(context);

        var result = (await service.GetCustomerCountByCountryAsync()).ToList();

        Assert.AreEqual(2, result.Count);
        var pl = result.First(r => r.Country == "PL");
        Assert.AreEqual(2, pl.CustomerCount);
    }
}
