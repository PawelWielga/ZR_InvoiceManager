using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using InvoiceManager.Infrastructure;
using InvoiceManager.Models;
using InvoiceManager.Services.Interfaces;

namespace InvoiceManager.ViewModels.Details;

public class InvoiceDetailsViewModel : BaseViewModel
{
    private readonly IInvoiceService _invoiceService;
    private readonly ICustomerService _customerService;
    private readonly IViewService _viewService;

    public Invoice Invoice { get; }

    private readonly bool _isNewInvoice;

    public ObservableCollection<Customer> AvailableCustomers { get; } = [];

    private Customer? _selectedCustomerInternal;

    public Customer? SelectedCustomer
    {
        get => _selectedCustomerInternal;
        set
        {
            if (SetProperty(ref _selectedCustomerInternal, value))
            {
                Invoice.CustomerId = value?.Id ?? 0;
                Invoice.Customer = value;
                UpdateCanSaveState();
            }
        }
    }

    public RelayCommand SaveCommand { get; }
    public RelayCommand CancelCommand { get; }
    public RelayCommand LoadCustomersCommand { get; }
    public RelayCommand SearchCustomersCommand { get; } 

    private bool _canSave;
    public bool CanSave
    {
        get => _canSave;
        private set
        {
            SetProperty(ref _canSave, value);
        }
    }

    public event EventHandler? RequestClose;
    public bool DialogResult { get; private set; }

    public InvoiceDetailsViewModel(
        Invoice invoice,
        IInvoiceService invoiceService,
        ICustomerService customerService,
        IViewService viewService)
    {
        Invoice = invoice ?? throw new ArgumentNullException(nameof(invoice));
        _invoiceService = invoiceService;
        _customerService = customerService;
        _viewService = viewService;
        _isNewInvoice = invoice.Id == 0;

        SaveCommand = new RelayCommand(
            executeAsync: SaveInvoiceAsync,
            canExecute: CanSaveInvoice);

        CancelCommand = new RelayCommand(
            execute: Cancel);

        LoadCustomersCommand = new RelayCommand(
            executeAsync: InitialLoadCustomersAsync);

        SearchCustomersCommand = new RelayCommand(
            executeAsyncWithParameter: async (param) => await PerformCustomerSearchAsync(param as string));

        _selectedCustomerInternal = Invoice.Customer;

        UpdateCanSaveState();
    }

    private async Task InitialLoadCustomersAsync()
    {
        await PerformCustomerSearchAsync(string.Empty);

        if (Invoice.CustomerId != 0 && _selectedCustomerInternal == null)
        {
            var customer = await _customerService.GetCustomerByIdAsync(Invoice.CustomerId);
            if (customer != null)
            {
                if (!AvailableCustomers.Any(c => c.Id == customer.Id))
                {
                    AvailableCustomers.Insert(0, customer);
                }
                SelectedCustomer = customer;
            }
        }
        else if (Invoice.CustomerId != 0 && _selectedCustomerInternal != null && _selectedCustomerInternal.Id == Invoice.CustomerId)
        {
            if (!AvailableCustomers.Any(c => c.Id == _selectedCustomerInternal.Id))
            {
                AvailableCustomers.Insert(0, _selectedCustomerInternal);
            }
        }
        UpdateCanSaveState();
    }

    private async Task PerformCustomerSearchAsync(string? searchTerm)
    {
        var customers = await _customerService.SearchCustomersAsync(searchTerm ?? string.Empty);

        var results = customers.Take(5).ToList();

        if (SelectedCustomer != null && !results.Any(c => c.Id == SelectedCustomer.Id))
        {
            results.Insert(0, SelectedCustomer);
        }

        AvailableCustomers.Clear();
        foreach (var c in results)
        {
            AvailableCustomers.Add(c);
        }
        UpdateCanSaveState();
    }

    public string InvoiceNumber
    {
        get => Invoice.InvoiceNumber;
        set
        {
            if (Invoice.InvoiceNumber != value)
            {
                Invoice.InvoiceNumber = value;
                OnPropertyChanged();
                UpdateCanSaveState();
            }
        }
    }

    public decimal NetAmount
    {
        get => Invoice.NetAmount;
        set
        {
            if (Invoice.NetAmount != value)
            {
                Invoice.NetAmount = value;
                OnPropertyChanged();
                UpdateCanSaveState();
            }
        }
    }

    public string Currency
    {
        get => Invoice.Currency;
        set
        {
            if (Invoice.Currency != value)
            {
                Invoice.Currency = value;
                OnPropertyChanged();
                UpdateCanSaveState();
            }
        }
    }

    public decimal VatRate
    {
        get => Invoice.VatRate;
        set
        {
            if (Invoice.VatRate != value)
            {
                Invoice.VatRate = value;
                OnPropertyChanged();
                UpdateCanSaveState();
            }
        }
    }

    public DateTime SaleDate
    {
        get => Invoice.SaleDate;
        set
        {
            if (Invoice.SaleDate != value)
            {
                Invoice.SaleDate = value;
                OnPropertyChanged();
                UpdateCanSaveState();
            }
        }
    }

    public string Description
    {
        get => Invoice.Description;
        set
        {
            if (Invoice.Description != value)
            {
                Invoice.Description = value;
                OnPropertyChanged();
            }
        }
    }

    private void UpdateCanSaveState()
    {
        CanSave = CanSaveInvoice();
    }

    private bool CanSaveInvoice()
    {
        if (string.IsNullOrWhiteSpace(Invoice.InvoiceNumber))
            return false;
        if (Invoice.NetAmount <= 0)
            return false;
        if (string.IsNullOrWhiteSpace(Invoice.Currency))
            return false;
        if (_selectedCustomerInternal == null || _selectedCustomerInternal.Id == 0)
            return false;

        return true;
    }

    private async Task SaveInvoiceAsync()
    {
        try
        {
            Invoice.Customer = _selectedCustomerInternal;

            if (_isNewInvoice)
            {
                await _invoiceService.AddInvoiceAsync(Invoice);
            }
            else
            {
                await _invoiceService.UpdateInvoiceAsync(Invoice);
            }

            DialogResult = true;
            RequestClose?.Invoke(this, EventArgs.Empty);
        }
        catch (Exception ex)
        {
            _viewService.ShowMessage($"Error saving invoice: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void Cancel()
    {
        DialogResult = false;
        RequestClose?.Invoke(this, EventArgs.Empty);
    }

}
