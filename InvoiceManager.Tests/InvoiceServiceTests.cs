using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvoiceManager.Models;
using InvoiceManager.Services;
using InvoiceManager.Data.Repositories.Interfaces;

namespace InvoiceManager.Tests;

[TestFixture]
public class InvoiceServiceTests
{
    private Mock<IInvoiceRepository> _repository = null!;
    private InvoiceService _service = null!;

    [SetUp]
    public void SetUp()
    {
        _repository = new Mock<IInvoiceRepository>(MockBehavior.Strict);
        _service = new InvoiceService(_repository.Object);
    }

    [Test]
    public void AddInvoiceAsync_EmptyInvoiceNumber_ThrowsArgumentException()
    {
        var invoice = new Invoice { InvoiceNumber = "", NetAmount = 10m };

        Assert.ThrowsAsync<ArgumentException>(() => _service.AddInvoiceAsync(invoice));
    }

    [Test]
    public void AddInvoiceAsync_NonPositiveNetAmount_ThrowsArgumentException()
    {
        var invoice = new Invoice { InvoiceNumber = "INV-1", NetAmount = 0m };

        Assert.ThrowsAsync<ArgumentException>(() => _service.AddInvoiceAsync(invoice));
    }

    [Test]
    public async Task AddInvoiceAsync_ValidInvoice_CallsRepository()
    {
        var invoice = new Invoice { InvoiceNumber = "INV-1", NetAmount = 5m };
        _repository.Setup(r => r.AddAsync(invoice)).Returns(Task.CompletedTask).Verifiable();

        await _service.AddInvoiceAsync(invoice);

        _repository.Verify();
    }

    [Test]
    public void UpdateInvoiceAsync_EmptyInvoiceNumber_ThrowsArgumentException()
    {
        var invoice = new Invoice { InvoiceNumber = "" };

        Assert.ThrowsAsync<ArgumentException>(() => _service.UpdateInvoiceAsync(invoice));
    }

    [Test]
    public async Task UpdateInvoiceAsync_ValidInvoice_CallsRepository()
    {
        var invoice = new Invoice { InvoiceNumber = "INV-1" };
        _repository.Setup(r => r.UpdateAsync(invoice)).Returns(Task.CompletedTask).Verifiable();

        await _service.UpdateInvoiceAsync(invoice);

        _repository.Verify();
    }

    [Test]
    public async Task DeleteInvoiceAsync_CallsRepository()
    {
        _repository.Setup(r => r.DeleteAsync(1)).Returns(Task.CompletedTask).Verifiable();

        await _service.DeleteInvoiceAsync(1);

        _repository.Verify();
    }

    [Test]
    public async Task GetAllInvoicesAsync_ReturnsFromRepository()
    {
        var invoices = new List<Invoice> { new Invoice { InvoiceNumber = "INV-1" } };
        _repository.Setup(r => r.GetAllAsync()).ReturnsAsync(invoices);

        var result = await _service.GetAllInvoicesAsync();

        Assert.AreEqual(invoices, result);
    }
}
