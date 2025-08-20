using System;
using System.Threading.Tasks;
using NUnit.Framework;
using InvoiceManager.Infrastructure;

namespace InvoiceManager.Tests;

[TestFixture]
public class RelayCommandTests
{
    [Test]
    public void Execute_CallsExecuteWithParameter()
    {
        bool executed = false;
        object receivedParameter = null;
        var testParameter = "someParam";

        var command = new RelayCommand(p =>
        {
            executed = true;
            receivedParameter = p;
        });

        command.Execute(testParameter);

        Assert.IsTrue(executed, "Execute delegate should be called.");
        Assert.AreEqual(testParameter, receivedParameter, "Parameter should be passed correctly.");
    }

    [Test]
    public void Execute_CallsExecuteWithoutParameter()
    {
        bool executed = false;
        var command = new RelayCommand(() => executed = true);

        command.Execute(null);

        Assert.IsTrue(executed, "Execute delegate without parameter should be called.");
    }

    [Test]
    public void CanExecute_UsesProvidedFuncWithParameter()
    {
        bool canExecuteCalled = false;
        var command = new RelayCommand(
            _ => { /* do nothing */ },
            p => { canExecuteCalled = true; return (int)p > 0; });


        var result1 = command.CanExecute(5);
        Assert.IsTrue(canExecuteCalled, "CanExecuteWithParameter func should be called.");
        Assert.IsTrue(result1, "CanExecute should return true for valid parameter.");

        canExecuteCalled = false;
        var result2 = command.CanExecute(-1);
        Assert.IsTrue(canExecuteCalled, "CanExecuteWithParameter func should be called again.");
        Assert.IsFalse(result2, "CanExecute should return false for invalid parameter.");
    }

    [Test]
    public void CanExecute_UsesProvidedFuncWithoutParameter()
    {
        bool canExecuteCalled = false;
        var command = new RelayCommand(
            () => { /* do nothing */ },
            () => { canExecuteCalled = true; return false; });

        var result = command.CanExecute(null);

        Assert.IsTrue(canExecuteCalled, "CanExecute func should be called.");
        Assert.IsFalse(result, "CanExecute should return false.");
    }

    [Test]
    public async Task Execute_TriggersAsyncExecution_FuncTask()
    {
        bool executed = false;
        var command = new RelayCommand(async () =>
        {
            await Task.Delay(10);
            executed = true;
        });

        command.Execute(null);
        await Task.Delay(50);

        Assert.IsTrue(executed, "Async delegate should be called and completed.");
    }

    [Test]
    public async Task Execute_TriggersAsyncExecution_FuncObjectTask()
    {
        bool executed = false;
        object receivedParameter = null;
        var testParameter = "asyncParam";

        var command = new RelayCommand(async p =>
        {
            await Task.Delay(10);
            executed = true;
            receivedParameter = p;
        });

        command.Execute(testParameter);
        await Task.Delay(50);

        Assert.IsTrue(executed, "Async delegate with parameter should be called and completed.");
        Assert.AreEqual(testParameter, receivedParameter, "Parameter should be passed correctly to async delegate.");
    }

    [Test]
    public async Task CanExecute_ReturnsFalseWhenExecuting()
    {
        var command = new RelayCommand(async () =>
        {
            await Task.Delay(100);
        });

        Assert.IsTrue(command.CanExecute(null), "CanExecute should be true before execution starts.");

        command.Execute(null);

        await Task.Delay(10);

        Assert.IsFalse(command.CanExecute(null), "CanExecute should be false while command is executing.");

        await Task.Delay(100);

        Assert.IsTrue(command.CanExecute(null), "CanExecute should be true after execution completes.");
    }

    [Test]
    public async Task CanExecute_StaysFalseIfCanExecuteFuncReturnsFalse()
    {
        var command = new RelayCommand(
            async () => { await Task.Delay(10); },
            () => false
        );

        Assert.IsFalse(command.CanExecute(null), "CanExecute should be false because canExecute func returns false.");

        command.Execute(null);

        await Task.Delay(50);

        Assert.IsFalse(command.CanExecute(null), "CanExecute should remain false if canExecute func is always false.");
    }

    [Test]
    public void Constructor_ThrowsArgumentNullException_ForNullExecuteAction()
    {
        Assert.Throws<ArgumentNullException>(() => new RelayCommand((Action<object>)null));
        Assert.Throws<ArgumentNullException>(() => new RelayCommand((Action)null));
        Assert.Throws<ArgumentNullException>(() => new RelayCommand((Func<Task>)null));
        Assert.Throws<ArgumentNullException>(() => new RelayCommand((Func<object, Task>)null));
    }

}