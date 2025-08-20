using DevExpress.LookAndFeel;
using DevExpress.Skins;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using InvoiceManager.Data.Context;
using InvoiceManager.Infrastructure;
using InvoiceManager.Services.Interfaces;
using InvoiceManager.Services;
using InvoiceManager.ViewModels;
using InvoiceManager.Views;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManager;

internal static class Program
{
        private static IViewService _viewService = new ViewService(new ServiceCollection().BuildServiceProvider());
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

        SkinManager.EnableFormSkins();
        UserLookAndFeel.Default.SetSkinStyle("Office 2019 Colorful");

        using var loginForm = new LoginView();
        if (loginForm.ShowDialog() == DialogResult.OK)
        {
            if (!string.IsNullOrWhiteSpace(GlobalConfig.ConnectionString))
            {
                ServiceLocator.Configure(GlobalConfig.ConnectionString);

                var scope = ServiceLocator.CreateScope();

                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.Migrate();

                var customerService = scope.ServiceProvider.GetRequiredService<ICustomerService>();
                var invoiceService = scope.ServiceProvider.GetRequiredService<IInvoiceService>();
                _viewService = scope.ServiceProvider.GetRequiredService<IViewService>();

                var viewModel = new MainViewModel(customerService, invoiceService, _viewService);

                Application.Run(new MainView(viewModel, scope));
            }
            else
            {
                _viewService.ShowMessage(
                    "Missing connection string. Application will exit.",
                    "Configuration Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                Application.Exit();
            }
        }
        else
        {
            Application.Exit();
        }
    }

    private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        if (e.ExceptionObject is Exception ex)
        {
            _viewService.ShowMessage(
                $"An unhandled application error occurred: {ex.Message}\n\n{ex.StackTrace}",
                "Application Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
        Application.Exit();
    }
}