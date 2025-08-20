using System.Collections.Generic;
using System.Threading.Tasks;
using InvoiceManager.Models;

namespace InvoiceManager.Data.Repositories.Interfaces;

public interface IInvoiceRepository : IRepository<Invoice>
{
    Task<IEnumerable<Invoice>> GetInvoicesByCustomerIdAsync(int customerId);

    Task<IEnumerable<Invoice>> GetAllWithCustomersAsync();
}
