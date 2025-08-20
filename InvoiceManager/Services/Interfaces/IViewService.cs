using System.Windows.Forms;

namespace InvoiceManager.Services.Interfaces; 

public interface IViewService
{
    DialogResult ShowMessage(string message, string caption, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information);

    DialogResult ShowDialog<TViewModel>(TViewModel viewModel);
}