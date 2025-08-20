using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using InvoiceManager.Infrastructure;

namespace InvoiceManager.ViewModels;

public class LoginViewModel : BaseViewModel, IDisposable
{
    private string _serverName = "KOMPUTER\\SQLEXPRESS";
    private string _databaseName = "PlatigeTestDB";
    private string _errorMessage = string.Empty;
    private bool _isConnecting;

    public string ServerName
    {
        get => _serverName;
        set => SetProperty(ref _serverName, value);
    }

    public string DatabaseName
    {
        get => _databaseName;
        set => SetProperty(ref _databaseName, value);
    }

    public string ErrorMessage
    {
        get => _errorMessage;
        set => SetProperty(ref _errorMessage, value);
    }

    public bool IsConnecting
    {
        get => _isConnecting;
        set
        {
            SetProperty(ref _isConnecting, value);
        }
    }

    public RelayCommand ConnectCommand { get; }

    public event Action? LoginSuccessful;
    public event Action? LoginFailed;

    public LoginViewModel()
    {
        ConnectCommand = new RelayCommand(ConnectToDatabaseAsync, () => !IsConnecting);
    }

    private async Task ConnectToDatabaseAsync()
    {
        ErrorMessage = string.Empty;
        IsConnecting = true;

        try
        {
            string connectionString = $"Server={ServerName};Database={DatabaseName};Integrated Security=True;TrustServerCertificate=True;";

            using var context = DbContextFactory.Create(connectionString);
            await context.Database.OpenConnectionAsync();
            await context.Database.CloseConnectionAsync();

            GlobalConfig.ConnectionString = connectionString;
            LoginSuccessful?.Invoke();
        }
        catch (SqlException ex)
        {
            ErrorMessage = $"Database connection error: {ex.Message}";
            LoginFailed?.Invoke();
        }
        catch (Exception ex)
        {
            ErrorMessage = $"An unexpected error occurred: {ex.Message}";
            LoginFailed?.Invoke();
        }
        finally
        {
            IsConnecting = false;
        }
    }

    private bool disposedValue;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                LoginSuccessful = null;
                LoginFailed = null;
            }

            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}