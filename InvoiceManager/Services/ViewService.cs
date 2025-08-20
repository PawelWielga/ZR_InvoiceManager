using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using InvoiceManager.Services.Interfaces;
using InvoiceManager.ViewModels.Details;
using InvoiceManager.Views.Details;

namespace InvoiceManager.Services;

public class ViewService(IServiceProvider serviceProvider) : IViewService
{
    public DialogResult ShowMessage(string message, string caption, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information)
    {
        return MessageBox.Show(message, caption, buttons, icon);
    }

    public DialogResult ShowDialog<TViewModel>(TViewModel viewModel)
    {
        if (viewModel is CustomerDetailsViewModel customerDetailsVm)
        {
            using var scope = serviceProvider.CreateScope();
            var customerDetailsView = scope.ServiceProvider.GetRequiredService<CustomerDetailsView>();

            customerDetailsView.ViewModel = customerDetailsVm;

            return customerDetailsView.ShowDialog();
        }
        else if (viewModel is InvoiceDetailsViewModel invoiceDetailsVm)
        {
            using var scope = serviceProvider.CreateScope();
            var invoiceDetailsView = scope.ServiceProvider.GetRequiredService<InvoiceDetailsView>();

            invoiceDetailsView.ViewModel = invoiceDetailsVm;

            return invoiceDetailsView.ShowDialog();
        }

        throw new NotSupportedException($"No view found for ViewModel type: {typeof(TViewModel).Name}");
    }
}