using System.Collections.Generic;
using System.Threading.Tasks;
using InvoiceManager.Models;

namespace InvoiceManager.Services.Interfaces;

public interface IInvoiceService
{
    Task<IEnumerable<Invoice>> GetAllInvoicesAsync();
    Task<IEnumerable<Invoice>> GetAllInvoicesWithCustomersAsync();
    Task<Invoice> GetInvoiceByIdAsync(int id);
    Task AddInvoiceAsync(Invoice invoice);
    Task UpdateInvoiceAsync(Invoice invoice);
    Task DeleteInvoiceAsync(int invoiceId);
    Task<IEnumerable<Invoice>> GetInvoicesByCustomerIdAsync(int customerId);
}