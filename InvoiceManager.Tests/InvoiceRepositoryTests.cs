using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using InvoiceManager.Data.Context;
using InvoiceManager.Data.Repositories;
using InvoiceManager.Models;
using InvoiceManager.Enums;

namespace InvoiceManager.Tests;

[TestFixture]
public class InvoiceRepositoryTests
{
    private static AppDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        return new AppDbContext(options);
    }

    [Test]
    public async Task AddAsync_AddsInvoiceToDatabase()
    {
        using var context = CreateContext();
        var repository = new InvoiceRepository(context);
        var customer = new Customer { Name = "John", TaxId = "1", TypeKind = CustomerType.Individual };
        context.Customers.Add(customer);
        context.SaveChanges();

        var invoice = new Invoice
        {
            InvoiceNumber = "INV-1",
            NetAmount = 100m,
            Currency = "USD",
            VatRate = 23m,
            SaleDate = DateTime.Today,
            CustomerId = customer.Id,
            Customer = customer
        };

        await repository.AddAsync(invoice);

        Assert.AreEqual(1, context.Invoices.Count());
        Assert.AreEqual(customer.Id, context.Invoices.First().CustomerId);
    }

    [Test]
    public async Task DeleteAsync_RemovesInvoice()
    {
        using var context = CreateContext();
        var repository = new InvoiceRepository(context);
        var customer = new Customer { Name = "A", TaxId = "2", TypeKind = CustomerType.Company };
        context.Customers.Add(customer);
        context.SaveChanges();

        var invoice = new Invoice
        {
            InvoiceNumber = "INV-2",
            NetAmount = 50m,
            Currency = "EUR",
            VatRate = 20m,
            SaleDate = DateTime.Today,
            CustomerId = customer.Id,
            Customer = customer
        };
        await repository.AddAsync(invoice);
        var id = invoice.Id;

        await repository.DeleteAsync(id);

        Assert.IsNull(await context.Invoices.FindAsync(id));
    }

    [Test]
    public async Task GetInvoicesByCustomerIdAsync_ReturnsOnlyForSpecifiedCustomer()
    {
        using var context = CreateContext();
        var repository = new InvoiceRepository(context);
        var c1 = new Customer { Name = "C1", TaxId = "3", TypeKind = CustomerType.Company };
        var c2 = new Customer { Name = "C2", TaxId = "4", TypeKind = CustomerType.Company };
        context.Customers.AddRange(c1, c2);
        context.SaveChanges();

        await repository.AddAsync(new Invoice
        {
            InvoiceNumber = "INV-3",
            NetAmount = 20m,
            Currency = "USD",
            VatRate = 10m,
            SaleDate = DateTime.Today,
            CustomerId = c1.Id,
            Customer = c1
        });
        await repository.AddAsync(new Invoice
        {
            InvoiceNumber = "INV-4",
            NetAmount = 40m,
            Currency = "USD",
            VatRate = 10m,
            SaleDate = DateTime.Today,
            CustomerId = c2.Id,
            Customer = c2
        });

        var result = await repository.GetInvoicesByCustomerIdAsync(c2.Id);

        Assert.AreEqual(1, result.Count());
        Assert.AreEqual("INV-4", result.First().InvoiceNumber);
    }

    [Test]
    public async Task UpdateAsync_UpdatesInvoice()
    {
        using var context = CreateContext();
        var repository = new InvoiceRepository(context);
        var customer = new Customer { Name = "B", TaxId = "5", TypeKind = CustomerType.Organization };
        context.Customers.Add(customer);
        context.SaveChanges();

        var invoice = new Invoice
        {
            InvoiceNumber = "INV-5",
            NetAmount = 10m,
            Currency = "USD",
            VatRate = 8m,
            SaleDate = DateTime.Today,
            CustomerId = customer.Id,
            Customer = customer
        };
        await repository.AddAsync(invoice);

        invoice.NetAmount = 15m;
        invoice.Description = "Updated";

        await repository.UpdateAsync(invoice);

        var updated = await repository.GetByIdAsync(invoice.Id);
        Assert.AreEqual(15m, updated!.NetAmount);
        Assert.AreEqual("Updated", updated.Description);
    }

    [Test]
    public async Task GetAllWithCustomersAsync_IncludesCustomer()
    {
        using var context = CreateContext();
        var repository = new InvoiceRepository(context);
        var customer = new Customer { Name = "D", TaxId = "6", TypeKind = CustomerType.Company };
        context.Customers.Add(customer);
        context.SaveChanges();

        await repository.AddAsync(new Invoice
        {
            InvoiceNumber = "INV-6",
            NetAmount = 30m,
            Currency = "USD",
            VatRate = 5m,
            SaleDate = DateTime.Today,
            CustomerId = customer.Id,
            Customer = customer
        });

        var result = await repository.GetAllWithCustomersAsync();

        var invoice = result.First();
        Assert.IsNotNull(invoice.Customer);
        Assert.AreEqual(customer.Id, invoice.Customer!.Id);
    }
}
