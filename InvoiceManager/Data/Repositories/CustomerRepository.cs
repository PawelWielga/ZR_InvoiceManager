using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceManager.Data.Context;
using InvoiceManager.Data.Repositories.Interfaces;
using InvoiceManager.Models;

namespace InvoiceManager.Data.Repositories;

public class CustomerRepository(AppDbContext context) : ICustomerRepository
{
    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await context.Customers
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Customer> GetByIdAsync(int id)
    {
        return await context.Customers
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Customer> GetWithInvoicesByIdAsync(int id)
    {
        return await context.Customers
            .Include(c => c.Invoices)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddAsync(Customer entity)
    {
        if (!string.IsNullOrWhiteSpace(entity.TaxId))
        {
            bool taxIdExists = await context.Customers
                .AnyAsync(c => c.TaxId == entity.TaxId);

            if (taxIdExists)
            {
                throw new InvalidOperationException("Customer with the same TaxId already exists.");
            }
        }

        await context.Customers.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Customer entity)
    {
        if (!string.IsNullOrWhiteSpace(entity.TaxId))
        {
            bool taxIdExists = await context.Customers
                .AnyAsync(c => c.TaxId == entity.TaxId && c.Id != entity.Id);

            if (taxIdExists)
            {
                throw new InvalidOperationException("Another customer with the same TaxId already exists.");
            }
        }

        var trackedEntity = await context.Customers.FindAsync(entity.Id);
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
        var customerToDelete = await context.Customers.FindAsync(id);
        if (customerToDelete != null)
        {
            context.Customers.Remove(customerToDelete);
            await context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Customer>> SearchCustomersAsync(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return await GetAllAsync();
        }

        return await context.Customers
            .AsNoTracking()
            .Where(c =>
                c.Name.Contains(searchTerm) ||
                c.Address.Contains(searchTerm) ||
                c.Country.Contains(searchTerm) ||
                c.TaxId.Contains(searchTerm) ||
                c.Abbreviation.Contains(searchTerm))
            .ToListAsync();
    }
}
