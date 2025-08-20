using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using InvoiceManager.ViewModels;
using InvoiceManager.Services.Interfaces;
using InvoiceManager.ViewModels.Reports;
using InvoiceManager.Views.Reports;

namespace InvoiceManager.Views;

public partial class MainView : RibbonForm
{
    private readonly MainViewModel _viewModel;
    private readonly IServiceScope _scope;
    private readonly IViewService _viewService;

    public MainView(MainViewModel viewModel, IServiceScope scope)
    {
        _viewModel = viewModel;
        _scope = scope;
        _viewService = _scope.ServiceProvider.GetRequiredService<IViewService>();

        InitializeComponent();
        InitializeAndLoadData();
        InitializeGridDefaults();
    }

    private async void InitializeAndLoadData()
    {
        try
        {
            if (gridControlCustomers != null)
            {
                gridControlCustomers.DataSource = _viewModel.Customers;
            }

            if (gridControlInvoices != null)
            {
                gridControlInvoices.DataSource = _viewModel.Invoices;
            }

            await _viewModel.LoadDataAsync();

            if (btnAddCustomer != null) btnAddCustomer.ItemClick += (s, e) => _viewModel.AddCustomerCommand.Execute(null);
            if (btnEditCustomer != null) btnEditCustomer.ItemClick += (s, e) => _viewModel.EditCustomerCommand.Execute(null);
            if (btnDeleteCustomer != null) btnDeleteCustomer.ItemClick += (s, e) => _viewModel.DeleteCustomerCommand.Execute(null);

            if (btnAddInvoice != null) btnAddInvoice.ItemClick += (s, e) => _viewModel.AddInvoiceCommand.Execute(null);
            if (btnEditInvoice != null) btnEditInvoice.ItemClick += (s, e) => _viewModel.EditInvoiceCommand.Execute(null);
            if (btnDeleteInvoice != null) btnDeleteInvoice.ItemClick += (s, e) => _viewModel.DeleteInvoiceCommand.Execute(null);

            if (btnGenerateCustomers != null)
            {
                btnGenerateCustomers.Click += async (s, e) => await GenerateCustomersAsync();
            }

            if (btnGenerateInvoices != null)
            {
                btnGenerateInvoices.Click += async (s, e) => await GenerateInvoicesAsync();
            }

            if (btnShowReports != null)
            {
                btnShowReports.ItemClick += (s, e) => ShowReports();
            }

        }
        catch (Exception ex)
        {
            _viewService.ShowMessage(
                $"Error initializing MainView: {ex.Message}\n\n{ex.InnerException?.Message}",
                "Initialization Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
            Application.Exit();
        }
    }


    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        _scope?.Dispose();
        base.OnFormClosed(e);
    }

    private void InitializeGridDefaults()
    {
        if (gridControlCustomers.MainView is GridView customersGridView)
        {
            customersGridView.OptionsView.ShowAutoFilterRow = true;
            customersGridView.OptionsBehavior.Editable = false;
            customersGridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            customersGridView.OptionsBehavior.ReadOnly = true;
            if (customersGridView.Columns["Invoices"] != null)
            {
                customersGridView.Columns["Invoices"].Visible = false;
                customersGridView.Columns["Invoices"].OptionsColumn.ShowInCustomizationForm = false;
            }
            customersGridView.BestFitColumns();

            customersGridView.FocusedRowChanged += (s, e) =>
            {
                if (s is GridView view)
                {
                    _viewModel.SelectedCustomer = view.GetFocusedRow() as Models.Customer;
                }
            };
        }

        if (gridControlInvoices.MainView is GridView invoicesGridView)
        {
            invoicesGridView.OptionsView.ShowAutoFilterRow = true;
            invoicesGridView.OptionsBehavior.Editable = false;
            invoicesGridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            invoicesGridView.OptionsBehavior.ReadOnly = true;
            if (invoicesGridView.Columns["Customer"] != null)
            {
                invoicesGridView.Columns["Customer"].Visible = false;
                invoicesGridView.Columns["Customer"].OptionsColumn.ShowInCustomizationForm = false;
            }
            invoicesGridView.BestFitColumns();

            invoicesGridView.FocusedRowChanged += (s, e) =>
            {
                if (s is GridView view)
                {
                    Models.Invoice? invoice = view.GetFocusedRow() as Models.Invoice;
                    _viewModel.SelectedInvoice = invoice;
                }
            };
        }
    }

    private async Task GenerateCustomersAsync()
    {
        if (!int.TryParse(txtCustomerGenerateCount.Text, out int count) || count <= 0)
        {
            _viewService.ShowMessage(
                "Invalid number of customers.",
                "Generation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        try
        {
            var customerService = _scope.ServiceProvider.GetRequiredService<ICustomerService>();
            var customers = Utils.DataSeeder.GenerateCustomers(count);

            foreach (var customer in customers)
            {
                await customerService.AddCustomerAsync(customer);
                _viewModel.Customers.Add(customer);
            }
        }
        catch (Exception ex)
        {
            _viewService.ShowMessage(
                $"Failed to generate customers: {ex.Message}",
                "Generation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async Task GenerateInvoicesAsync()
    {
        if (!int.TryParse(txtInvoiceGenerateCount.Text, out int count) || count <= 0)
        {
            _viewService.ShowMessage(
                "Invalid number of invoices.",
                "Generation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        try
        {
            var invoiceService = _scope.ServiceProvider.GetRequiredService<IInvoiceService>();
            var customers = _viewModel.Customers;

            var invoices = Utils.DataSeeder.GenerateInvoicesForCustomers(customers, count);

            foreach (var invoice in invoices)
            {
                await invoiceService.AddInvoiceAsync(invoice);
                _viewModel.Invoices.Add(invoice);
            }
        }
        catch (Exception ex)
        {
            _viewService.ShowMessage(
                $"Failed to generate invoices: {ex.Message}",
                "Generation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void ShowReports()
    {
        using var scope = _scope.ServiceProvider.CreateScope();
        var viewModel = scope.ServiceProvider.GetRequiredService<ReportsViewModel>();
        var view = scope.ServiceProvider.GetRequiredService<ReportsView>();
        view.ViewModel = viewModel;
        view.ShowDialog();
    }
}