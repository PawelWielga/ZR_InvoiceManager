using DevExpress.XtraEditors;
using InvoiceManager.ViewModels;
using System.Windows.Forms;

namespace InvoiceManager.Views;

public partial class LoginView : XtraForm
{
    private LoginViewModel _viewModel;

    public LoginView()
    {
        InitializeComponent();
        _viewModel = new LoginViewModel();
        InitializeBindings();
        ApplyCustomStyles();
    }

    private void InitializeBindings()
    {
        txtServerName.DataBindings.Add("Text", _viewModel, nameof(_viewModel.ServerName), true, DataSourceUpdateMode.OnPropertyChanged);
        txtDatabaseName.DataBindings.Add("Text", _viewModel, nameof(_viewModel.DatabaseName), true, DataSourceUpdateMode.OnPropertyChanged);

        lblErrorMessage.DataBindings.Add("Text", _viewModel, nameof(_viewModel.ErrorMessage), true, DataSourceUpdateMode.OnPropertyChanged);

        btnConnect.Click += async (s, e) => _viewModel.ConnectCommand.Execute(null);

        _viewModel.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName == nameof(_viewModel.IsConnecting))
            {
                btnConnect.Enabled = !_viewModel.IsConnecting;
            }
        };

        btnConnect.Enabled = !_viewModel.IsConnecting;

        _viewModel.LoginSuccessful += OnLoginSuccessful;

        txtServerName.Text = _viewModel.ServerName;
        txtDatabaseName.Text = _viewModel.DatabaseName;
    }

    private void OnLoginSuccessful()
    {
        DialogResult = DialogResult.OK;
        Close();
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        base.OnFormClosed(e);
        if (_viewModel != null)
        {
            _viewModel.LoginSuccessful -= OnLoginSuccessful;
            _viewModel.Dispose();
            _viewModel = null;
        }
    }
}