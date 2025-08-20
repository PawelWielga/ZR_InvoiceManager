using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvoiceManager.Data.Repositories.Interfaces;
using InvoiceManager.Models;
using InvoiceManager.Services.Interfaces;

namespace InvoiceManager.Services;

public class InvoiceService(IInvoiceRepository invoiceRepository) : IInvoiceService
{
    public async Task<IEnumerable<Invoice>> GetAllInvoicesAsync()
    {
        return await invoiceRepository.GetAllAsync();
    }

    public async Task<IEnumerable<Invoice>> GetAllInvoicesWithCustomersAsync()
    {
        return await invoiceRepository.GetAllWithCustomersAsync();
    }

    public async Task<Invoice> GetInvoiceByIdAsync(int id)
    {
        return await invoiceRepository.GetByIdAsync(id);
    }

    public async Task AddInvoiceAsync(Invoice invoice)
    {
        if (string.IsNullOrWhiteSpace(invoice.InvoiceNumber))
        {
            throw new ArgumentException("Numer faktury nie może być pusty.");
        }
        if (invoice.NetAmount <= 0)
        {
            throw new ArgumentException("Kwota netto faktury musi być większa od zera.");
        }
        await invoiceRepository.AddAsync(invoice);
    }

    public async Task UpdateInvoiceAsync(Invoice invoice)
    {
        if (string.IsNullOrWhiteSpace(invoice.InvoiceNumber))
        {
            throw new ArgumentException("Numer faktury nie może być pusty.");
        }
        await invoiceRepository.UpdateAsync(invoice);
    }

    public async Task DeleteInvoiceAsync(int invoiceId)
    {
        await invoiceRepository.DeleteAsync(invoiceId);
    }

    public async Task<IEnumerable<Invoice>> GetInvoicesByCustomerIdAsync(int customerId)
    {
        return await invoiceRepository.GetInvoicesByCustomerIdAsync(customerId);
    }
}