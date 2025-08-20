using System.Drawing;
using System.Windows.Forms;

namespace InvoiceManager.Views;

public partial class LoginView
{
    private void ApplyCustomStyles()
    {
        // Text Fields
        txtServerName.Properties.Appearance.Font = new Font("Segoe UI", 10F);
        txtServerName.Properties.NullValuePrompt = "np. localhost";
        txtServerName.Properties.NullValuePromptShowForEmptyValue = true;

        txtDatabaseName.Properties.Appearance.Font = new Font("Segoe UI", 10F);
        txtDatabaseName.Properties.NullValuePrompt = "np. PlatigeDb";
        txtDatabaseName.Properties.NullValuePromptShowForEmptyValue = true;

        // Buttons
        btnConnect.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnConnect.Appearance.BackColor = Color.SteelBlue;
        btnConnect.Appearance.ForeColor = Color.White;
        btnConnect.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
        btnConnect.LookAndFeel.UseDefaultLookAndFeel = false;

        // Error Message Label
        lblErrorMessage.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
        lblErrorMessage.Appearance.ForeColor = Color.DarkRed;

        // Window Style
        this.Text = "Logowanie do bazy danych";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Font = new Font("Segoe UI", 10F);
    }
}
