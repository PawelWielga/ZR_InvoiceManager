using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace InvoiceManager.Infrastructure;

public class RelayCommand : ICommand
{
    private readonly Action<object>? _executeWithParameter;
    private readonly Func<object, bool>? _canExecuteWithParameter;
    private readonly Func<Task>? _executeAsync;
    private readonly Func<object?, Task>? _executeAsyncWithParameter;
    private readonly Func<bool>? _canExecute;

    private bool _isExecuting;

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public RelayCommand(Action<object> execute, Func<object, bool>? canExecute = null)
    {
        _executeWithParameter = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecuteWithParameter = canExecute;
    }

    public RelayCommand(Action execute, Func<bool>? canExecute = null)
    {
        if (execute == null) throw new ArgumentNullException(nameof(execute));
        _executeWithParameter = _ => execute.Invoke();
        _canExecute = canExecute;
    }

    public RelayCommand(Func<Task> executeAsync, Func<bool>? canExecute = null)
    {
        _executeAsync = executeAsync ?? throw new ArgumentNullException(nameof(executeAsync));
        _canExecute = canExecute;
    }

    public RelayCommand(Func<object?, Task> executeAsyncWithParameter, Func<object?, bool>? canExecute = null)
    {
        _executeAsyncWithParameter = executeAsyncWithParameter ?? throw new ArgumentNullException(nameof(executeAsyncWithParameter));
        _canExecuteWithParameter = canExecute;
    }

    public bool CanExecute(object? parameter)
    {
        if (_isExecuting)
        {
            return false;
        }

        if (_canExecuteWithParameter != null)
        {
            return _canExecuteWithParameter(parameter);
        }

        if (_canExecute != null)
        {
            return _canExecute();
        }

        return true;
    }

    public async void Execute(object? parameter)
    {
        await InternalExecuteAsync(parameter);
    }

    private async Task InternalExecuteAsync(object? parameter = null)
    {
        if (!CanExecute(parameter))
        {
            return;
        }

        _isExecuting = true;
        RaiseCanExecuteChangedInternal();

        try
        {
            if (_executeWithParameter != null)
            {
                _executeWithParameter(parameter);
            }
            else if (_executeAsync != null)
            {
                await _executeAsync();
            }
            else if (_executeAsyncWithParameter != null)
            {
                await _executeAsyncWithParameter(parameter);
            }
        }
        finally
        {
            _isExecuting = false;
            RaiseCanExecuteChangedInternal();
        }
    }

    private void RaiseCanExecuteChangedInternal()
    {
        if (System.Windows.Application.Current != null && System.Windows.Application.Current.Dispatcher != null)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(
                DispatcherPriority.Normal,
                (Action)delegate { CommandManager.InvalidateRequerySuggested(); });
        }
        else
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}