using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System.Windows.Forms;
using InvoiceManager.Enums;
using InvoiceManager.ViewModels.Reports;
using InvoiceManager.Infrastructure;
using InvoiceManager.Services.Interfaces;

namespace InvoiceManager.Views.Reports;

public partial class ReportsView : XtraForm
{
    private ReportsViewModel? _viewModel;
    private readonly IViewService _viewService;

    public ReportsViewModel? ViewModel
    {
        get => _viewModel;
        set
        {
            _viewModel = value;
            if (_viewModel != null)
            {
                InitializeBindings();
            }
        }
    }

    public ReportsView()
    {
        _viewService = ServiceLocator.GetService<IViewService>();
        InitializeComponent();
    }

    private async void InitializeBindings()
    {
        if (_viewModel == null)
            return;

        gridInvoicesByCustomer.DataSource = _viewModel.InvoicesByCustomer;
        gridMonthlySummary.DataSource = _viewModel.MonthlySummaries;
        gridCustomersByCountry.DataSource = _viewModel.CustomersByCountry;

        ConfigureGrid(gridInvoicesByCustomerView);
        ConfigureGrid(gridMonthlySummaryView);
        ConfigureGrid(gridCustomersByCountryView);

        await _viewModel.LoadDataAsync();
    }

    private static void ConfigureGrid(GridView view)
    {
        view.OptionsBehavior.Editable = false;
        view.OptionsBehavior.ReadOnly = true;
        view.BestFitColumns();
    }

    private void btnExportCsv_Click(object? sender, System.EventArgs e)
    {
        if (_viewModel == null)
            return;

        using var dialog = new SaveFileDialog
        {
            Filter = "CSV files (*.csv)|*.csv",
            AddExtension = true,
            DefaultExt = "csv"
        };

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            if (tabControl.SelectedTabPage == tabInvoicesByCustomer)
                _viewModel.ExportInvoicesByCustomer(dialog.FileName, ReportFormat.Csv);
            else if (tabControl.SelectedTabPage == tabMonthlySummary)
                _viewModel.ExportMonthlySummaries(dialog.FileName, ReportFormat.Csv);
            else
                _viewModel.ExportCustomersByCountry(dialog.FileName, ReportFormat.Csv);

            _viewService.ShowMessage("Export completed", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void btnExportXml_Click(object? sender, System.EventArgs e)
    {
        if (_viewModel == null)
            return;

        using var dialog = new SaveFileDialog
        {
            Filter = "XML files (*.xml)|*.xml",
            AddExtension = true,
            DefaultExt = "xml"
        };

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            if (tabControl.SelectedTabPage == tabInvoicesByCustomer)
                _viewModel.ExportInvoicesByCustomer(dialog.FileName, ReportFormat.Xml);
            else if (tabControl.SelectedTabPage == tabMonthlySummary)
                _viewModel.ExportMonthlySummaries(dialog.FileName, ReportFormat.Xml);
            else
                _viewModel.ExportCustomersByCountry(dialog.FileName, ReportFormat.Xml);

            _viewService.ShowMessage("Export completed", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}