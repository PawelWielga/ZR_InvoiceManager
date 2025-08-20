using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using InvoiceManager.ViewModels.Details;

namespace InvoiceManager.Views.Details;

public partial class CustomerDetailsView : XtraForm
{
    private CustomerDetailsViewModel _viewModel;
    private BindingSource customerBindingSource;
    private DXErrorProvider dxErrorProvider;

    public CustomerDetailsViewModel ViewModel
    {
        get => _viewModel;
        set
        {
            if (_viewModel != null)
            {
                _viewModel.PropertyChanged -= ViewModel_PropertyChanged;
                _viewModel.RequestClose -= ViewModel_RequestClose;
            }
            _viewModel = value;
            if (_viewModel != null)
            {
                customerBindingSource.DataSource = _viewModel;
                _viewModel.PropertyChanged += ViewModel_PropertyChanged;
                _viewModel.RequestClose += ViewModel_RequestClose;
                ConfigureControls();
            }
        }
    }

    public CustomerDetailsView()
    {
        InitializeComponent();
        InitializeCommonComponents();
    }

    private void InitializeCommonComponents()
    {
        customerBindingSource = new BindingSource();
        dxErrorProvider = new DXErrorProvider()
        {
            ContainerControl = this
        };
    }

    private void ConfigureControls()
    {
        txtName.DataBindings.Clear();
        txtAbbreviation.DataBindings.Clear();
        dropDownTypeKind.DataBindings.Clear();
        txtTaxId.DataBindings.Clear();
        txtCountry.DataBindings.Clear();
        txtAddress.DataBindings.Clear();
        checkIsActive.DataBindings.Clear();
        btnSave.DataBindings.Clear();
        btnCancel.DataBindings.Clear();

        txtName.DataBindings.Add("EditValue", customerBindingSource, nameof(CustomerDetailsViewModel.Name), true, DataSourceUpdateMode.OnPropertyChanged);
        txtAbbreviation.DataBindings.Add("EditValue", customerBindingSource, nameof(CustomerDetailsViewModel.Abbreviation), true, DataSourceUpdateMode.OnPropertyChanged);
        txtCountry.DataBindings.Add("EditValue", customerBindingSource, nameof(CustomerDetailsViewModel.Country), true, DataSourceUpdateMode.OnPropertyChanged);
        txtAddress.DataBindings.Add("EditValue", customerBindingSource, nameof(CustomerDetailsViewModel.Address), true, DataSourceUpdateMode.OnPropertyChanged);

        txtTaxId.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
        txtTaxId.Properties.Mask.EditMask = @"\d{10}";
        txtTaxId.Properties.Mask.UseMaskAsDisplayFormat = true;
        txtTaxId.DataBindings.Add("EditValue", customerBindingSource, nameof(CustomerDetailsViewModel.TaxId), true, DataSourceUpdateMode.OnPropertyChanged);

        checkIsActive.DataBindings.Add("EditValue", customerBindingSource, nameof(CustomerDetailsViewModel.IsActive), true, DataSourceUpdateMode.OnPropertyChanged);

        dropDownTypeKind.Properties.Items.Clear();
        foreach (var item in _viewModel.AvailableCustomerTypes)
        {
            dropDownTypeKind.Properties.Items.Add(item.DisplayName);
        }
        dropDownTypeKind.DataBindings.Add("EditValue", customerBindingSource, nameof(CustomerDetailsViewModel.TypeKind), true, DataSourceUpdateMode.OnPropertyChanged);

        btnSave.Click -= OnSaveButtonClick;
        btnSave.Click += OnSaveButtonClick;

        btnCancel.Click -= OnCancelButtonClick;
        btnCancel.Click += OnCancelButtonClick;

        btnSave.DataBindings.Add("Enabled", customerBindingSource, nameof(CustomerDetailsViewModel.CanSave), true, DataSourceUpdateMode.OnPropertyChanged);
    }

    private async void OnSaveButtonClick(object sender, EventArgs e)
    {
        _viewModel.SaveCommand.Execute(null);
    }

    private async void OnCancelButtonClick(object sender, EventArgs e)
    {
        _viewModel.CancelCommand.Execute(null);
    }

    private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(CustomerDetailsViewModel.Error))
        {
            dxErrorProvider.ClearErrors();

            if (!string.IsNullOrEmpty(_viewModel.Error))
            {
                if (_viewModel.Error.Contains("name", StringComparison.OrdinalIgnoreCase))
                {
                    dxErrorProvider.SetError(txtName, _viewModel.Error, ErrorType.Critical);
                }
                else if (_viewModel.Error.Contains("Tax ID", StringComparison.OrdinalIgnoreCase))
                {
                    dxErrorProvider.SetError(txtTaxId, _viewModel.Error, ErrorType.Critical);
                }
                else
                {
                    dxErrorProvider.SetError(btnSave, _viewModel.Error, ErrorType.Critical);
                }
            }
        }
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
            _viewModel.PropertyChanged -= ViewModel_PropertyChanged;
            _viewModel.RequestClose -= ViewModel_RequestClose;

            txtName.DataBindings.Clear();
            txtAbbreviation.DataBindings.Clear();
            dropDownTypeKind.DataBindings.Clear();
            txtTaxId.DataBindings.Clear();
            txtCountry.DataBindings.Clear();
            txtAddress.DataBindings.Clear();
            checkIsActive.DataBindings.Clear();
            btnSave.DataBindings.Clear();
            btnCancel.DataBindings.Clear();

            customerBindingSource.DataSource = null;
        }
        base.OnFormClosed(e);
    }
}