using System.Collections.Generic;
using System.Threading.Tasks;
using InvoiceManager.Models;

namespace InvoiceManager.Services.Interfaces;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
    Task<Customer> GetCustomerByIdAsync(int id);
    Task AddCustomerAsync(Customer customer);
    Task UpdateCustomerAsync(Customer customer);
    Task DeleteCustomerAsync(int customerId);
    Task<IEnumerable<Customer>> SearchCustomersAsync(string searchTerm);
    Task<bool> HasInvoicesAsync(int customerId);
}