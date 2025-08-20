using Bogus;
using System;
using System.Collections.Generic;
using InvoiceManager.Enums;
using InvoiceManager.Models;

namespace InvoiceManager.Utils;

public static class DataSeeder
{
    public static IEnumerable<Customer> GenerateCustomers(int count)
    {
        var faker = new Faker<Customer>()
            .RuleFor(c => c.TypeKind, f => f.PickRandom<CustomerType>())
            .RuleFor(c => c.Name, f => f.Company.CompanyName())
            .RuleFor(c => c.Abbreviation, f => f.Company.CompanySuffix())
            .RuleFor(c => c.Country, f => f.Address.Country())
            .RuleFor(c => c.Address, f => f.Address.FullAddress())
            .RuleFor(c => c.TaxId, f => f.Random.Replace("##########"));

        return faker.Generate(count);
    }

    public static IEnumerable<Invoice> GenerateInvoices(int customerId, int count)
    {
        var faker = new Faker<Invoice>()
            .RuleFor(i => i.InvoiceNumber, f => f.Random.AlphaNumeric(10).ToUpper())
            .RuleFor(i => i.NetAmount, f => decimal.Parse(f.Commerce.Price()))
            .RuleFor(i => i.Currency, f => f.Finance.Currency().Code)
            .RuleFor(i => i.VatRate, f => f.Random.Decimal(0, 25))
            .RuleFor(i => i.SaleDate, f => f.Date.Between(DateTime.Today.AddYears(-1), DateTime.Today))
            .RuleFor(i => i.Description, f => f.Commerce.ProductName())
            .RuleFor(i => i.CustomerId, _ => customerId);

        return faker.Generate(count);
    }

    public static IEnumerable<Invoice> GenerateInvoicesForCustomers(IEnumerable<Customer> customers, int countPerCustomer)
    {
        var result = new List<Invoice>();
        foreach (var customer in customers)
        {
            result.AddRange(GenerateInvoices(customer.Id, countPerCustomer));
        }

        return result;
    }
}
