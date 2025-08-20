using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using InvoiceManager.ViewModels.Details;

namespace InvoiceManager.Views.Details;

public partial class InvoiceDetailsViewBKP : XtraForm
{
    private InvoiceDetailsViewModel _viewModel;
    private BindingSource invoiceBindingSource;
    private Timer _searchTimer;

    public InvoiceDetailsViewModel ViewModel
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
                invoiceBindingSource.DataSource = _viewModel;
                _viewModel.RequestClose += ViewModel_RequestClose;
                _viewModel.LoadCustomersAsync().ContinueWith(_ => { ConfigureControls(); }, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }
    }

    public InvoiceDetailsViewBKP()
    {
        InitializeComponent();
        invoiceBindingSource = new BindingSource();
        _searchTimer = new Timer { Interval = 3000 };
        _searchTimer.Tick += async (s, e) =>
        {
            _searchTimer.Stop();
            await PerformCustomerSearchAsync();
        };
    }

    private void ConfigureControls()
    {
        if (_viewModel == null) return;

        txtNumber.DataBindings.Clear();
        txtNetAmount.DataBindings.Clear();
        txtCurrency.DataBindings.Clear();
        txtVatRate.DataBindings.Clear();
        dateSale.DataBindings.Clear();
        txtDescription.DataBindings.Clear();
        comboCustomer.DataBindings.Clear();
        btnSave.DataBindings.Clear();

        txtNumber.DataBindings.Add("EditValue", invoiceBindingSource, nameof(InvoiceDetailsViewModel.InvoiceNumber), true, DataSourceUpdateMode.OnPropertyChanged);
        txtNetAmount.DataBindings.Add("EditValue", invoiceBindingSource, nameof(InvoiceDetailsViewModel.NetAmount), true, DataSourceUpdateMode.OnPropertyChanged);
        txtCurrency.DataBindings.Add("EditValue", invoiceBindingSource, nameof(InvoiceDetailsViewModel.Currency), true, DataSourceUpdateMode.OnPropertyChanged);
        txtVatRate.DataBindings.Add("EditValue", invoiceBindingSource, nameof(InvoiceDetailsViewModel.VatRate), true, DataSourceUpdateMode.OnPropertyChanged);
        dateSale.DataBindings.Add("EditValue", invoiceBindingSource, nameof(InvoiceDetailsViewModel.SaleDate), true, DataSourceUpdateMode.OnPropertyChanged);
        txtDescription.DataBindings.Add("EditValue", invoiceBindingSource, nameof(InvoiceDetailsViewModel.Description), true, DataSourceUpdateMode.OnPropertyChanged);

        comboCustomer.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
        comboCustomer.Properties.Items.Clear();
        foreach (var c in _viewModel.AvailableCustomers)
        {
            comboCustomer.Properties.Items.Add(c);
        }
        comboCustomer.DataBindings.Add("SelectedItem", invoiceBindingSource, nameof(InvoiceDetailsViewModel.SelectedCustomer), true, DataSourceUpdateMode.OnPropertyChanged);
        comboCustomer.EditValueChanged -= OnCustomerTextChanged;
        comboCustomer.EditValueChanged += OnCustomerTextChanged;
        btnClearCustomer.Click -= OnClearCustomerClick;
        btnClearCustomer.Click += OnClearCustomerClick;

        btnClearCustomer.Enabled = _viewModel.SelectedCustomer != null;
        comboCustomer.Enabled = _viewModel.SelectedCustomer == null;

        btnSave.Click -= OnSaveClick;
        btnSave.Click += OnSaveClick;
        btnCancel.Click -= OnCancelClick;
        btnCancel.Click += OnCancelClick;
        btnSave.DataBindings.Add("Enabled", invoiceBindingSource, nameof(InvoiceDetailsViewModel.CanSave), true, DataSourceUpdateMode.OnPropertyChanged);
    }

    private async void OnSaveClick(object sender, EventArgs e)
    {
        await _viewModel.SaveCommand.ExecuteAsync();
    }

    private async void OnCancelClick(object sender, EventArgs e)
    {
        await _viewModel.CancelCommand.ExecuteAsync();
    }

    private void OnClearCustomerClick(object sender, EventArgs e)
    {
        if (_viewModel == null) return;

        _viewModel.SelectedCustomer = null;
        comboCustomer.Enabled = true;
        btnClearCustomer.Enabled = false;
        comboCustomer.Focus();
    }

    private void OnCustomerTextChanged(object sender, EventArgs e)
    {
        if (_viewModel == null || !comboCustomer.Enabled) return;

        if (comboCustomer.SelectedItem != null &&
            comboCustomer.Text == comboCustomer.SelectedItem.ToString())
        {
            comboCustomer.Enabled = false;
            btnClearCustomer.Enabled = true;
            return;
        }

        _searchTimer.Stop();
        _searchTimer.Start();
    }

    private async Task PerformCustomerSearchAsync()
    {
        if (_viewModel == null) return;

        await _viewModel.SearchCustomersAsync(comboCustomer.Text);

        comboCustomer.Properties.Items.Clear();
        foreach (var c in _viewModel.AvailableCustomers)
        {
            comboCustomer.Properties.Items.Add(c);
        }

        comboCustomer.SelectedItem = null;
        comboCustomer.ShowPopup();
    }

    private void ViewModel_RequestClose(object sender, EventArgs e)
    {
        DialogResult = _viewModel.DialogResult ? DialogResult.OK : DialogResult.Cancel;
        Close();
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        if (_viewModel != null)
        {
            _viewModel.RequestClose -= ViewModel_RequestClose;
            txtNumber.DataBindings.Clear();
            txtNetAmount.DataBindings.Clear();
            txtCurrency.DataBindings.Clear();
            txtVatRate.DataBindings.Clear();
            dateSale.DataBindings.Clear();
            txtDescription.DataBindings.Clear();
            comboCustomer.DataBindings.Clear();
            btnSave.DataBindings.Clear();
            comboCustomer.EditValueChanged -= OnCustomerTextChanged;
            btnClearCustomer.Click -= OnClearCustomerClick;
        }
        _searchTimer?.Stop();
        _searchTimer?.Dispose();
        base.OnFormClosed(e);
    }
}
