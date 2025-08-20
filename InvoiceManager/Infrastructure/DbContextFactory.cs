using Microsoft.EntityFrameworkCore;
using System;
using InvoiceManager.Data.Context;

namespace InvoiceManager.Infrastructure;

public static class DbContextFactory
{
    public static AppDbContext Create(string connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentException("Connection string cannot be null or empty.", nameof(connectionString));
        }

        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new AppDbContext(optionsBuilder.Options);
    }
}