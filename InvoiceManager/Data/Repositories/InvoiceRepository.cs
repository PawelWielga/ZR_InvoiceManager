using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceManager.Data.Context;
using InvoiceManager.Data.Repositories.Interfaces;
using InvoiceManager.Models;

namespace InvoiceManager.Data.Repositories;

public class InvoiceRepository(AppDbContext context) : IInvoiceRepository
{
    public async Task<IEnumerable<Invoice>> GetAllAsync()
    {
        return await context.Invoices
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Invoice> GetByIdAsync(int id)
    {
        return await context.Invoices
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task AddAsync(Invoice entity)
    {
        if (entity.Customer != null)
        {
            var tracked = context.ChangeTracker.Entries<Customer>()
                .FirstOrDefault(e => e.Entity.Id == entity.Customer.Id);

            if (tracked != null)
            {
                entity.Customer = tracked.Entity;
            }
            else
            {
                context.Customers.Attach(entity.Customer);
            }
        }

        await context.Invoices.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Invoice entity)
    {
        if (entity.Customer != null)
        {
            var tracked = context.ChangeTracker.Entries<Customer>()
                .FirstOrDefault(e => e.Entity.Id == entity.Customer.Id);

            if (tracked != null)
            {
                entity.Customer = tracked.Entity;
            }
            else
            {
                context.Customers.Attach(entity.Customer);
            }
        }

        var trackedEntity = await context.Invoices.FindAsync(entity.Id);
        if (trackedEntity != null)
        {
            context.Entry(trackedEntity).CurrentValues.SetValues(entity);
        }
        else
        {
            context.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var invoiceToDelete = await context.Invoices.FindAsync(id);
        if (invoiceToDelete != null)
        {
            context.Invoices.Remove(invoiceToDelete);
            await context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Invoice>> GetInvoicesByCustomerIdAsync(int customerId)
    {
        return await context.Invoices
            .AsNoTracking()
            .Where(i => i.CustomerId == customerId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Invoice>> GetAllWithCustomersAsync()
    {
        return await context.Invoices
            .Include(i => i.Customer)
            .AsNoTracking()
            .ToListAsync();
    }
}
