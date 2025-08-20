using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using InvoiceManager.Infrastructure;
using InvoiceManager.Models;
using InvoiceManager.Services.Interfaces;
using InvoiceManager.ViewModels.Details;

namespace InvoiceManager.ViewModels;

public class MainViewModel : BaseViewModel
{
    private readonly ICustomerService _customerService;
    private readonly IInvoiceService _invoiceService;
    private readonly IViewService _viewService;

    public ObservableCollection<Customer> Customers { get; private set; }
    public ObservableCollection<Invoice> Invoices { get; private set; }

    private Customer? _selectedCustomer;
    public Customer? SelectedCustomer
    {
        get => _selectedCustomer;
        set
        {
            SetProperty(ref _selectedCustomer, value);
        }
    }

    private Invoice? _selectedInvoice;
    public Invoice? SelectedInvoice
    {
        get => _selectedInvoice;
        set
        {
            SetProperty(ref _selectedInvoice, value);
        }
    }

    public RelayCommand AddCustomerCommand { get; }
    public RelayCommand EditCustomerCommand { get; }
    public RelayCommand DeleteCustomerCommand { get; }

    public RelayCommand AddInvoiceCommand { get; }
    public RelayCommand EditInvoiceCommand { get; }
    public RelayCommand DeleteInvoiceCommand { get; }

    public MainViewModel(ICustomerService customerService, IInvoiceService invoiceService, IViewService viewService)
    {
        _customerService = customerService;
        _invoiceService = invoiceService;
        _viewService = viewService;

        Customers = [];
        Invoices = [];

        AddCustomerCommand = new RelayCommand(AddCustomerAsync);
        EditCustomerCommand = new RelayCommand(EditCustomerAsync, () => SelectedCustomer != null);
        DeleteCustomerCommand = new RelayCommand(DeleteCustomerAsync, () => SelectedCustomer != null);

        AddInvoiceCommand = new RelayCommand(AddInvoiceAsync);
        EditInvoiceCommand = new RelayCommand(EditInvoiceAsync, () => SelectedInvoice != null);
        DeleteInvoiceCommand = new RelayCommand(DeleteInvoiceAsync, () => SelectedInvoice != null);
    }

    public async Task LoadDataAsync()
    {
        Customers.Clear();
        Invoices.Clear();

        var customers = await _customerService.GetAllCustomersAsync();
        foreach (var customer in customers)
        {
            Customers.Add(customer);
        }

        var invoices = await _invoiceService.GetAllInvoicesWithCustomersAsync();
        foreach (var invoice in invoices)
        {
            Invoices.Add(invoice);
        }
    }

    private async Task AddCustomerAsync()
    {
        var newCustomer = new Customer();

        var customerDetailsViewModel = new CustomerDetailsViewModel(
            newCustomer,
            _customerService,
            _viewService
            );

        var dialogResult = _viewService.ShowDialog(customerDetailsViewModel);

        if (dialogResult == DialogResult.OK)
        {
            Customers.Add(newCustomer);
            _viewService.ShowMessage("Customer added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await LoadDataAsync();
        }
    }

    private async Task EditCustomerAsync()
    {
        if (SelectedCustomer == null) return;

        var originalCustomer = SelectedCustomer;
        var customerToEdit = new Customer(originalCustomer);

        var customerDetailsViewModel = new CustomerDetailsViewModel(
            customerToEdit,
            _customerService,
            _viewService
            );

        var dialogResult = _viewService.ShowDialog(customerDetailsViewModel);

        if (dialogResult == DialogResult.OK)
        {
            originalCustomer.TypeKind = customerToEdit.TypeKind;
            originalCustomer.Name = customerToEdit.Name;
            originalCustomer.Abbreviation = customerToEdit.Abbreviation;
            originalCustomer.Country = customerToEdit.Country;
            originalCustomer.Address = customerToEdit.Address;
            originalCustomer.TaxId = customerToEdit.TaxId;
            originalCustomer.IsActive = customerToEdit.IsActive;

            await LoadDataAsync();
            _viewService.ShowMessage("Customer updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private async Task DeleteCustomerAsync()
    {
        if (SelectedCustomer == null) return;

        var result = _viewService.ShowMessage(
            $"Are you sure you want to delete customer '{SelectedCustomer.Name}'?",
            "Confirm Deletion",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        );

        if (result == DialogResult.Yes)
        {
            try
            {
                await _customerService.DeleteCustomerAsync(SelectedCustomer.Id);
                Customers.Remove(SelectedCustomer);
                SelectedCustomer = null;
                _viewService.ShowMessage("Customer deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadDataAsync();
            }
            catch (InvalidOperationException ex)
            {
                _viewService.ShowMessage($"Deletion failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                _viewService.ShowMessage($"An unexpected error occurred during customer deletion: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    // --- Logika CRUD dla Faktur ---
    private async Task AddInvoiceAsync()
    {
        var newInvoice = new Invoice { SaleDate = DateTime.Today };

        var invoiceDetailsViewModel = new InvoiceDetailsViewModel(
            newInvoice,
            _invoiceService,
            _customerService,
            _viewService
            );

        var dialogResult = _viewService.ShowDialog(invoiceDetailsViewModel);

        if (dialogResult == DialogResult.OK)
        {
            Invoices.Add(newInvoice);
            _viewService.ShowMessage("Invoice added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            await LoadDataAsync();
        }
    }

    private async Task EditInvoiceAsync()
    {
        if (SelectedInvoice == null) return;

        var originalInvoice = SelectedInvoice;
        var invoiceToEdit = new Invoice
        {
            Id = originalInvoice.Id,
            InvoiceNumber = originalInvoice.InvoiceNumber,
            NetAmount = originalInvoice.NetAmount,
            Currency = originalInvoice.Currency,
            VatRate = originalInvoice.VatRate,
            SaleDate = originalInvoice.SaleDate,
            Description = originalInvoice.Description,
            CustomerId = originalInvoice.CustomerId,
            Customer = originalInvoice.Customer
        };

        var invoiceDetailsViewModel = new InvoiceDetailsViewModel(
            invoiceToEdit,
            _invoiceService,
            _customerService,
            _viewService
            );

        var dialogResult = _viewService.ShowDialog(invoiceDetailsViewModel);

        if (dialogResult == DialogResult.OK)
        {
            originalInvoice.InvoiceNumber = invoiceToEdit.InvoiceNumber;
            originalInvoice.NetAmount = invoiceToEdit.NetAmount;
            originalInvoice.Currency = invoiceToEdit.Currency;
            originalInvoice.VatRate = invoiceToEdit.VatRate;
            originalInvoice.SaleDate = invoiceToEdit.SaleDate;
            originalInvoice.Description = invoiceToEdit.Description;
            originalInvoice.CustomerId = invoiceToEdit.CustomerId;
            originalInvoice.Customer = invoiceToEdit.Customer;

            await LoadDataAsync();
            _viewService.ShowMessage("Invoice updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private async Task DeleteInvoiceAsync()
    {
        if (SelectedInvoice == null) return;

        var result = _viewService.ShowMessage(
            $"Are you sure you want to delete invoice number '{SelectedInvoice.InvoiceNumber}'?",
            "Confirm Deletion",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        );

        if (result == DialogResult.Yes)
        {
            try
            {
                await _invoiceService.DeleteInvoiceAsync(SelectedInvoice.Id);
                Invoices.Remove(SelectedInvoice);
                SelectedInvoice = null; 
                _viewService.ShowMessage("Invoice deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                _viewService.ShowMessage($"An unexpected error occurred during invoice deletion: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
