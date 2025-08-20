using System.Collections.Generic;
using System.Threading.Tasks;
using InvoiceManager.Models;

namespace InvoiceManager.Data.Repositories.Interfaces;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<IEnumerable<Customer>> SearchCustomersAsync(string searchTerm);

    Task<Customer> GetWithInvoicesByIdAsync(int id);
}
