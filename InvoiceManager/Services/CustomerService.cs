using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceManager.Data.Repositories.Interfaces;
using InvoiceManager.Models;
using InvoiceManager.Services.Interfaces;

namespace InvoiceManager.Services;

public class CustomerService(ICustomerRepository customerRepository, IInvoiceRepository invoiceRepository) : ICustomerService
{
    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        return await customerRepository.GetAllAsync();
    }

    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
        return await customerRepository.GetByIdAsync(id);
    }

    public async Task AddCustomerAsync(Customer customer)
    {
        if (string.IsNullOrWhiteSpace(customer.Name))
        {
            throw new ArgumentException("Nazwa kontrahenta nie może być pusta.");
        }
        await customerRepository.AddAsync(customer);
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
        if (string.IsNullOrWhiteSpace(customer.Name))
        {
            throw new ArgumentException("Nazwa kontrahenta nie może być pusta.");
        }
        await customerRepository.UpdateAsync(customer);
    }

    public async Task DeleteCustomerAsync(int customerId)
    {
        var hasInvoices = await HasInvoicesAsync(customerId);
        if (hasInvoices)
        {
            throw new InvalidOperationException("Nie można usunąć kontrahenta, ponieważ posiada powiązane faktury.");
        }
        await customerRepository.DeleteAsync(customerId);
    }

    public async Task<IEnumerable<Customer>> SearchCustomersAsync(string searchTerm)
    {
        return await customerRepository.SearchCustomersAsync(searchTerm);
    }

    public async Task<bool> HasInvoicesAsync(int customerId)
    {
        var invoices = await invoiceRepository.GetInvoicesByCustomerIdAsync(customerId);
        return invoices.Any();
    }
}