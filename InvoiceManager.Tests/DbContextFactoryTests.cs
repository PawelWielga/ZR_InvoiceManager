using System;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using InvoiceManager.Infrastructure;

namespace InvoiceManager.Tests;

[TestFixture]
public class DbContextFactoryTests
{
    [Test]
    public void Create_WithNullOrEmptyConnectionString_ThrowsArgumentException([Values(null, "")] string conn)
    {
        Assert.Throws<ArgumentException>(() => DbContextFactory.Create(conn));
    }

    [Test]
    public void Create_ReturnsContextConfiguredForSqlServer()
    {
        const string connection = "Server=(localdb)\\mssqllocaldb;Database=TestDb;Trusted_Connection=True;";
        using var context = DbContextFactory.Create(connection);

        Assert.NotNull(context);
        Assert.IsTrue(context.Database.IsSqlServer());
        Assert.AreEqual(connection, context.Database.GetConnectionString());
    }
}
