using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using InvoiceManager.Models;
using InvoiceManager.Services;
using InvoiceManager.Data.Repositories.Interfaces;

namespace InvoiceManager.Tests;

[TestFixture]
public class CustomerServiceTests
{
    private Mock<ICustomerRepository> _customerRepository = null!;
    private Mock<IInvoiceRepository> _invoiceRepository = null!;
    private CustomerService _service = null!;

    [SetUp]
    public void SetUp()
    {
        _customerRepository = new Mock<ICustomerRepository>(MockBehavior.Strict);
        _invoiceRepository = new Mock<IInvoiceRepository>(MockBehavior.Strict);
        _service = new CustomerService(_customerRepository.Object, _invoiceRepository.Object);
    }

    [Test]
    public void AddCustomerAsync_EmptyName_ThrowsArgumentException()
    {
        var customer = new Customer { Name = "" };

        Assert.ThrowsAsync<ArgumentException>(() => _service.AddCustomerAsync(customer));
    }

    [Test]
    public async Task AddCustomerAsync_ValidCustomer_CallsRepository()
    {
        var customer = new Customer { Name = "John" };
        _customerRepository.Setup(r => r.AddAsync(customer)).Returns(Task.CompletedTask).Verifiable();

        await _service.AddCustomerAsync(customer);

        _customerRepository.Verify();
    }

    [Test]
    public void UpdateCustomerAsync_EmptyName_ThrowsArgumentException()
    {
        var customer = new Customer { Name = "" };

        Assert.ThrowsAsync<ArgumentException>(() => _service.UpdateCustomerAsync(customer));
    }

    [Test]
    public async Task UpdateCustomerAsync_ValidCustomer_CallsRepository()
    {
        var customer = new Customer { Name = "A" };
        _customerRepository.Setup(r => r.UpdateAsync(customer)).Returns(Task.CompletedTask).Verifiable();

        await _service.UpdateCustomerAsync(customer);

        _customerRepository.Verify();
    }

    [Test]
    public void DeleteCustomerAsync_HasInvoices_ThrowsInvalidOperationException()
    {
        _invoiceRepository.Setup(r => r.GetInvoicesByCustomerIdAsync(1)).ReturnsAsync(new List<Invoice> { new Invoice() });

        Assert.ThrowsAsync<InvalidOperationException>(() => _service.DeleteCustomerAsync(1));
    }

    [Test]
    public async Task DeleteCustomerAsync_NoInvoices_CallsRepository()
    {
        _invoiceRepository.Setup(r => r.GetInvoicesByCustomerIdAsync(1)).ReturnsAsync(new List<Invoice>());
        _customerRepository.Setup(r => r.DeleteAsync(1)).Returns(Task.CompletedTask).Verifiable();

        await _service.DeleteCustomerAsync(1);

        _customerRepository.Verify();
    }

    [Test]
    public async Task GetAllCustomersAsync_ReturnsFromRepository()
    {
        var customers = new List<Customer> { new Customer { Name = "A" } };
        _customerRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(customers);

        var result = await _service.GetAllCustomersAsync();

        Assert.AreEqual(customers, result);
    }
}
