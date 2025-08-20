using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using InvoiceManager.Data.Context;
using InvoiceManager.Data.Repositories;
using InvoiceManager.Data.Repositories.Interfaces;
using InvoiceManager.Services;
using InvoiceManager.Services.Interfaces;
using InvoiceManager.ViewModels.Details;
using InvoiceManager.Views.Details;
using InvoiceManager.ViewModels.Reports;
using InvoiceManager.Views.Reports;
using InvoiceManager.Utils.ReportExporters.Exporters;
using InvoiceManager.Utils.ReportExporters.Factories;
using InvoiceManager.Utils.ReportExporters.Interfaces;
using InvoiceManager.Utils.ReportExporters.Services;

namespace InvoiceManager.Infrastructure;

public static class ServiceLocator
{
    private static Lazy<IServiceProvider> _lazyProvider = new(() =>
    {
        if (_serviceCollection == null)
            throw new InvalidOperationException("ServiceLocator not configured. Call Configure() first.");

        return _serviceCollection.BuildServiceProvider();
    });

    private static IServiceCollection? _serviceCollection;

    public static void Configure(string connectionString)
    {
        if (_serviceCollection != null)
            throw new InvalidOperationException("ServiceLocator is already configured.");

        _serviceCollection = new ServiceCollection();

        AddDatabaseServices(_serviceCollection, connectionString);
        AddRepositoryServices(_serviceCollection);
        AddDomainServices(_serviceCollection);
        AddViewServices(_serviceCollection);
        AddReportExportServices(_serviceCollection);
        AddViewModelAndViews(_serviceCollection);
    }

    private static void AddDatabaseServices(IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString), ServiceLifetime.Scoped);
    }

    private static void AddRepositoryServices(IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IInvoiceRepository, InvoiceRepository>();
    }

    private static void AddDomainServices(IServiceCollection services)
    {
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IInvoiceService, InvoiceService>();
        services.AddScoped<IReportService, ReportService>();
    }

    private static void AddViewServices(IServiceCollection services)
    {
        services.AddSingleton<IViewService, ViewService>();
    }

    private static void AddReportExportServices(IServiceCollection services)
    {
        services.AddTransient(typeof(CsvReportExporter<>));
        services.AddTransient(typeof(XmlReportExporter<>));
        services.AddTransient(typeof(IReportExporterFactory<>), typeof(ReportExporterFactory<>));
        services.AddTransient(typeof(ReportProcessor<>));
    }

    private static void AddViewModelAndViews(IServiceCollection services)
    {
        services.AddTransient<CustomerDetailsViewModel>();
        services.AddTransient<CustomerDetailsView>();
        services.AddTransient<InvoiceDetailsViewModel>();
        services.AddTransient<InvoiceDetailsView>();
        services.AddTransient<ReportsView>();
        services.AddTransient<ReportsViewModel>();
    }

    public static IServiceScope CreateScope()
    {
        return _lazyProvider.Value.CreateScope();
    }

    public static T GetService<T>()
    {
        return _lazyProvider.Value.GetRequiredService<T>();
    }
}