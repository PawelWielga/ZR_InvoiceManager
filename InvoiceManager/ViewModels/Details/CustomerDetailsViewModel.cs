using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using InvoiceManager.Enums;
using InvoiceManager.Infrastructure;
using InvoiceManager.Models;
using InvoiceManager.Services.Interfaces;

namespace InvoiceManager.ViewModels.Details;

public partial class CustomerDetailsViewModel : BaseViewModel
{
    [GeneratedRegex(@"^\d{10}$")]
    private static partial Regex TaxIdRegex();

    private readonly ICustomerService _customerService;
    private readonly IViewService _viewService;
    private readonly bool _isNewCustomer;
    private readonly Customer _customer;

    public CustomerType TypeKind
    {
        get => _customer.TypeKind;
        set
        {
            if (_customer.TypeKind != value)
            {
                _customer.TypeKind = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CanSave));
            }
        }
    }

    public string Name
    {
        get => _customer.Name;
        set
        {
            if (_customer.Name != value)
            {
                _customer.Name = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CanSave));
            }
        }
    }

    public string Abbreviation
    {
        get => _customer.Abbreviation;
        set
        {
            if (_customer.Abbreviation != value)
            {
                _customer.Abbreviation = value;
                OnPropertyChanged();
            }
        }
    }

    public string Country
    {
        get => _customer.Country;
        set
        {
            if (_customer.Country != value)
            {
                _customer.Country = value;
                OnPropertyChanged();
            }
        }
    }

    public string Address
    {
        get => _customer.Address;
        set
        {
            if (_customer.Address != value)
            {
                _customer.Address = value;
                OnPropertyChanged();
            }
        }
    }

    public string TaxId
    {
        get => _customer.TaxId;
        set
        {
            string cleanedValue = value?.Trim() ?? string.Empty;

            if (_customer.TaxId != cleanedValue)
            {
                _customer.TaxId = cleanedValue;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CanSave));
            }
        }
    }

    private string _error;
    public string Error
    {
        get => _error;
        set => SetProperty(ref _error, value);
    }

    public bool IsActive
    {
        get => _customer.IsActive;
        set
        {
            if (_customer.IsActive != value)
            {
                _customer.IsActive = value;
                OnPropertyChanged();
            }
        }
    }

    public List<CustomerTypeDisplay> AvailableCustomerTypes { get; }

    public RelayCommand SaveCommand { get; }
    public RelayCommand CancelCommand { get; }
    public bool CanSave => SaveCommand.CanExecute(null);

    public event EventHandler RequestClose;
    public bool DialogResult { get; private set; }


    public CustomerDetailsViewModel(Customer customer, ICustomerService customerService, IViewService viewService)
    {
        _customerService = customerService;
        _viewService = viewService;
        _customer = customer ?? throw new ArgumentNullException(nameof(customer));
        _isNewCustomer = customer.Id == 0;

        AvailableCustomerTypes = [.. Enum.GetValues(typeof(CustomerType))
                                     .Cast<CustomerType>()
                                     .Select(e => new CustomerTypeDisplay
                                     {
                                         Type = e,
                                         DisplayName = GetEnumDescription(e)
                                     })];

        SaveCommand = new RelayCommand(SaveCustomer, CanSaveCustomer);
        CancelCommand = new RelayCommand(Cancel);
    }

    private bool CanSaveCustomer()
    {
        Error = string.Empty;

        if (string.IsNullOrWhiteSpace(Name))
        {
            Error = "Customer name is required.";
            return false;
        }

        if (string.IsNullOrWhiteSpace(TaxId))
        {
            Error = "Tax ID is required.";
            return false;
        }
        else if (!TaxIdRegex().IsMatch(TaxId))
        {
            Error = "Tax ID must contain exactly 10 digits.";
            return false;
        }

        return true;
    }

    private async Task SaveCustomer()
    {
        try
        {
            if (!CanSaveCustomer())
            {
                _viewService.ShowMessage(Error, "Validation Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            if (_isNewCustomer)
            {
                await _customerService.AddCustomerAsync(_customer);
            }
            else
            {
                await _customerService.UpdateCustomerAsync(_customer);
            }
            DialogResult = true;
            RequestClose?.Invoke(this, EventArgs.Empty);
        }
        catch (Exception ex)
        {
            _viewService.ShowMessage($"Error saving customer: {ex.Message}", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
    }

    private Task Cancel()
    {
        DialogResult = false;
        RequestClose?.Invoke(this, EventArgs.Empty);
        return Task.CompletedTask;
    }



    public class CustomerTypeDisplay
    {
        public CustomerType Type { get; set; }
        public string DisplayName { get; set; }
    }

    private static string GetEnumDescription(Enum value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());

        if (fi != null)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
        }
        return value.ToString();
    }
}