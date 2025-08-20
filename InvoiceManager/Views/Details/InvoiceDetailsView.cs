using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using System;
using System.Linq;
using System.Windows.Forms;
using InvoiceManager.Models;
using InvoiceManager.ViewModels.Details;

namespace InvoiceManager.Views.Details;

public partial class InvoiceDetailsView : XtraForm
{
    private InvoiceDetailsViewModel? _viewModel;
    private readonly BindingSource _invoiceBindingSource;
    private readonly Timer _searchTimer;

    public InvoiceDetailsViewModel? ViewModel
    {
        get => _viewModel;
        set
        {
            if (_viewModel != null)
            {
                _viewModel.RequestClose -= ViewModel_RequestClose;
            }
            _viewModel = value;
            if (_viewModel != null)
            {
                _invoiceBindingSource.DataSource = _viewModel;
                _viewModel.RequestClose += ViewModel_RequestClose;

                _viewModel.LoadCustomersCommand.Execute(null);

                ConfigureControls();
            }
        }
    }

    public InvoiceDetailsView()
    {
        InitializeComponent();
        _invoiceBindingSource = [];
        _searchTimer = new Timer { Interval = 300 };
        _searchTimer.Tick += (s, e) =>
        {
            _searchTimer.Stop();
            _viewModel?.SearchCustomersCommand.Execute(slueCustomer.AutoSearchText);
        };

        ConfigureSearchLookUpEdit();
    }

    private void ConfigureControls()
    {
        if (_viewModel == null) return;

        txtInvoiceNumber.DataBindings.Clear();
        txtNetAmount.DataBindings.Clear();
        txtCurrency.DataBindings.Clear();
        txtVatRate.DataBindings.Clear();
        txtSaleDate.DataBindings.Clear();
        txtDescription.DataBindings.Clear();
        slueCustomer.DataBindings.Clear();
        btnSave.DataBindings.Clear();
        btnCancel.DataBindings.Clear();

        txtInvoiceNumber.DataBindings.Add("EditValue", _invoiceBindingSource, nameof(InvoiceDetailsViewModel.InvoiceNumber), true, DataSourceUpdateMode.OnPropertyChanged);
        txtNetAmount.DataBindings.Add("EditValue", _invoiceBindingSource, nameof(InvoiceDetailsViewModel.NetAmount), true, DataSourceUpdateMode.OnPropertyChanged);
        txtCurrency.DataBindings.Add("EditValue", _invoiceBindingSource, nameof(InvoiceDetailsViewModel.Currency), true, DataSourceUpdateMode.OnPropertyChanged);
        txtVatRate.DataBindings.Add("EditValue", _invoiceBindingSource, nameof(InvoiceDetailsViewModel.VatRate), true, DataSourceUpdateMode.OnPropertyChanged);
        txtSaleDate.DataBindings.Add("EditValue", _invoiceBindingSource, nameof(InvoiceDetailsViewModel.SaleDate), true, DataSourceUpdateMode.OnPropertyChanged);
        txtDescription.DataBindings.Add("EditValue", _invoiceBindingSource, nameof(InvoiceDetailsViewModel.Description), true, DataSourceUpdateMode.OnPropertyChanged);

        slueCustomer.DataBindings.Add("EditValue", _invoiceBindingSource, nameof(InvoiceDetailsViewModel.SelectedCustomer) + ".Id", true, DataSourceUpdateMode.OnPropertyChanged);

        btnSave.Click -= OnSaveClick;
        btnSave.Click += OnSaveClick;

        btnCancel.Click -= OnCancelClick;
        btnCancel.Click += OnCancelClick;

        btnSave.DataBindings.Add("Enabled", _invoiceBindingSource, nameof(InvoiceDetailsViewModel.CanSave), true, DataSourceUpdateMode.OnPropertyChanged);

        slueCustomer.EditValueChanged -= OnCustomerSearchEditValueChanged;
        slueCustomer.EditValueChanged += OnCustomerSearchEditValueChanged;

        slueCustomer.Properties.DataSource = _viewModel.AvailableCustomers;
    }

    private void ConfigureSearchLookUpEdit()
    {
        slueCustomer.Properties.DisplayMember = nameof(Customer.DisplayName);
        slueCustomer.Properties.ValueMember = nameof(Customer.Id);

        slueCustomer.Properties.PopulateViewColumns();

        if (slueCustomer.Properties.PopupView != null)
        {
            slueCustomer.Properties.PopupView.Columns.Clear();
            slueCustomer.Properties.PopupView.Columns.Add(new GridColumn() { FieldName = nameof(Customer.Name), Caption = "Nazwa Klienta", Visible = true, VisibleIndex = 0 });
            slueCustomer.Properties.PopupView.Columns.Add(new GridColumn() { FieldName = nameof(Customer.TaxId), Caption = "NIP", Visible = true, VisibleIndex = 1 });
            slueCustomer.Properties.PopupView.Columns.Add(new GridColumn() { FieldName = nameof(Customer.DisplayName), Caption = "Wyświetlana Nazwa", Visible = false });
        }

        slueCustomer.Properties.PopupFilterMode = PopupFilterMode.Contains;
        slueCustomer.Properties.NullText = "Wybierz lub wyszukaj klienta...";
    }

    private async void OnSaveClick(object sender, EventArgs e)
    {
        _viewModel?.SaveCommand.Execute(null);
    }

    private async void OnCancelClick(object sender, EventArgs e)
    {
        _viewModel?.CancelCommand.Execute(null);
    }

    private void OnCustomerSearchEditValueChanged(object sender, EventArgs e)
    {
        if (_viewModel == null) return;

        if (slueCustomer.EditValue is int id)
        {
            var customer = _viewModel.AvailableCustomers.FirstOrDefault(c => c.Id == id);
            _viewModel.SelectedCustomer = customer;
        }
        else
        {
            _viewModel.SelectedCustomer = null;
        }

        _searchTimer.Stop();
        _searchTimer.Start();
    }

    private void ViewModel_RequestClose(object? sender, EventArgs e)
    {
        DialogResult = _viewModel?.DialogResult == true ? DialogResult.OK : DialogResult.Cancel;
        Close();
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        if (_viewModel != null)
        {
            _viewModel.RequestClose -= ViewModel_RequestClose;

            txtInvoiceNumber.DataBindings.Clear();
            txtNetAmount.DataBindings.Clear();
            txtCurrency.DataBindings.Clear();
            txtVatRate.DataBindings.Clear();
            txtSaleDate.DataBindings.Clear();
            txtDescription.DataBindings.Clear();
            btnSave.DataBindings.Clear();
            btnCancel.DataBindings.Clear();
            slueCustomer.DataBindings.Clear();

            btnSave.Click -= OnSaveClick;
            btnCancel.Click -= OnCancelClick;
            slueCustomer.EditValueChanged -= OnCustomerSearchEditValueChanged;
        }
        _searchTimer.Stop();
        _searchTimer.Dispose();
        base.OnFormClosed(e);
    }
}