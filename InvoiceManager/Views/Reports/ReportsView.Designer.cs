namespace InvoiceManager.Views.Reports;

partial class ReportsView
{
    private System.ComponentModel.IContainer components = null;
    private DevExpress.XtraTab.XtraTabControl tabControl;
    private DevExpress.XtraTab.XtraTabPage tabInvoicesByCustomer;
    private DevExpress.XtraTab.XtraTabPage tabMonthlySummary;
    private DevExpress.XtraTab.XtraTabPage tabCustomersByCountry;
    private DevExpress.XtraGrid.GridControl gridInvoicesByCustomer;
    private DevExpress.XtraGrid.Views.Grid.GridView gridInvoicesByCustomerView;
    private DevExpress.XtraGrid.GridControl gridMonthlySummary;
    private DevExpress.XtraGrid.Views.Grid.GridView gridMonthlySummaryView;
    private DevExpress.XtraGrid.GridControl gridCustomersByCountry;
    private DevExpress.XtraGrid.Views.Grid.GridView gridCustomersByCountryView;
    private System.Windows.Forms.Panel panelExport;
    private DevExpress.XtraEditors.SimpleButton btnExportCsv;
    private DevExpress.XtraEditors.SimpleButton btnExportXml;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        tabControl = new DevExpress.XtraTab.XtraTabControl();
        tabInvoicesByCustomer = new DevExpress.XtraTab.XtraTabPage();
        gridInvoicesByCustomer = new DevExpress.XtraGrid.GridControl();
        gridInvoicesByCustomerView = new DevExpress.XtraGrid.Views.Grid.GridView();
        tabMonthlySummary = new DevExpress.XtraTab.XtraTabPage();
        gridMonthlySummary = new DevExpress.XtraGrid.GridControl();
        gridMonthlySummaryView = new DevExpress.XtraGrid.Views.Grid.GridView();
        tabCustomersByCountry = new DevExpress.XtraTab.XtraTabPage();
        gridCustomersByCountry = new DevExpress.XtraGrid.GridControl();
        gridCustomersByCountryView = new DevExpress.XtraGrid.Views.Grid.GridView();
        panelExport = new System.Windows.Forms.Panel();
        btnExportXml = new DevExpress.XtraEditors.SimpleButton();
        btnExportCsv = new DevExpress.XtraEditors.SimpleButton();
        ((System.ComponentModel.ISupportInitialize)tabControl).BeginInit();
        tabControl.SuspendLayout();
        tabInvoicesByCustomer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridInvoicesByCustomer).BeginInit();
        ((System.ComponentModel.ISupportInitialize)gridInvoicesByCustomerView).BeginInit();
        tabMonthlySummary.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridMonthlySummary).BeginInit();
        ((System.ComponentModel.ISupportInitialize)gridMonthlySummaryView).BeginInit();
        tabCustomersByCountry.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridCustomersByCountry).BeginInit();
        ((System.ComponentModel.ISupportInitialize)gridCustomersByCountryView).BeginInit();
        panelExport.SuspendLayout();
        SuspendLayout();
        // 
        // tabControl
        // 
        tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
        tabControl.Location = new System.Drawing.Point(0, 0);
        tabControl.Name = "tabControl";
        tabControl.SelectedTabPage = tabInvoicesByCustomer;
        tabControl.Size = new System.Drawing.Size(800, 415);
        tabControl.TabIndex = 0;
        tabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { tabInvoicesByCustomer, tabMonthlySummary, tabCustomersByCountry });
        // 
        // tabInvoicesByCustomer
        // 
        tabInvoicesByCustomer.Controls.Add(gridInvoicesByCustomer);
        tabInvoicesByCustomer.Name = "tabInvoicesByCustomer";
        tabInvoicesByCustomer.Size = new System.Drawing.Size(798, 390);
        tabInvoicesByCustomer.Text = "Invoices by Customer";
        // 
        // gridInvoicesByCustomer
        // 
        gridInvoicesByCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
        gridInvoicesByCustomer.Location = new System.Drawing.Point(0, 0);
        gridInvoicesByCustomer.MainView = gridInvoicesByCustomerView;
        gridInvoicesByCustomer.Name = "gridInvoicesByCustomer";
        gridInvoicesByCustomer.Size = new System.Drawing.Size(798, 390);
        gridInvoicesByCustomer.TabIndex = 0;
        gridInvoicesByCustomer.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridInvoicesByCustomerView });
        // 
        // gridInvoicesByCustomerView
        // 
        gridInvoicesByCustomerView.GridControl = gridInvoicesByCustomer;
        gridInvoicesByCustomerView.Name = "gridInvoicesByCustomerView";
        // 
        // tabMonthlySummary
        // 
        tabMonthlySummary.Controls.Add(gridMonthlySummary);
        tabMonthlySummary.Name = "tabMonthlySummary";
        tabMonthlySummary.Size = new System.Drawing.Size(798, 390);
        tabMonthlySummary.Text = "Monthly Summary";
        // 
        // gridMonthlySummary
        // 
        gridMonthlySummary.Dock = System.Windows.Forms.DockStyle.Fill;
        gridMonthlySummary.Location = new System.Drawing.Point(0, 0);
        gridMonthlySummary.MainView = gridMonthlySummaryView;
        gridMonthlySummary.Name = "gridMonthlySummary";
        gridMonthlySummary.Size = new System.Drawing.Size(798, 390);
        gridMonthlySummary.TabIndex = 0;
        gridMonthlySummary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridMonthlySummaryView });
        // 
        // gridMonthlySummaryView
        // 
        gridMonthlySummaryView.GridControl = gridMonthlySummary;
        gridMonthlySummaryView.Name = "gridMonthlySummaryView";
        // 
        // tabCustomersByCountry
        // 
        tabCustomersByCountry.Controls.Add(gridCustomersByCountry);
        tabCustomersByCountry.Name = "tabCustomersByCountry";
        tabCustomersByCountry.Size = new System.Drawing.Size(798, 390);
        tabCustomersByCountry.Text = "Customers by Country";
        // 
        // gridCustomersByCountry
        // 
        gridCustomersByCountry.Dock = System.Windows.Forms.DockStyle.Fill;
        gridCustomersByCountry.Location = new System.Drawing.Point(0, 0);
        gridCustomersByCountry.MainView = gridCustomersByCountryView;
        gridCustomersByCountry.Name = "gridCustomersByCountry";
        gridCustomersByCountry.Size = new System.Drawing.Size(798, 390);
        gridCustomersByCountry.TabIndex = 0;
        gridCustomersByCountry.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridCustomersByCountryView });
        // 
        // gridCustomersByCountryView
        // 
        gridCustomersByCountryView.GridControl = gridCustomersByCountry;
        gridCustomersByCountryView.Name = "gridCustomersByCountryView";
        // 
        // panelExport
        // 
        panelExport.Controls.Add(btnExportXml);
        panelExport.Controls.Add(btnExportCsv);
        panelExport.Dock = System.Windows.Forms.DockStyle.Bottom;
        panelExport.Location = new System.Drawing.Point(0, 415);
        panelExport.Name = "panelExport";
        panelExport.Size = new System.Drawing.Size(800, 35);
        panelExport.TabIndex = 1;
        // 
        // btnExportXml
        // 
        btnExportXml.Location = new System.Drawing.Point(138, 6);
        btnExportXml.Name = "btnExportXml";
        btnExportXml.Size = new System.Drawing.Size(120, 23);
        btnExportXml.TabIndex = 1;
        btnExportXml.Text = "Export XML";
        btnExportXml.Click += btnExportXml_Click;
        // 
        // btnExportCsv
        // 
        btnExportCsv.Location = new System.Drawing.Point(12, 6);
        btnExportCsv.Name = "btnExportCsv";
        btnExportCsv.Size = new System.Drawing.Size(120, 23);
        btnExportCsv.TabIndex = 0;
        btnExportCsv.Text = "Export CSV";
        btnExportCsv.Click += btnExportCsv_Click;
        // 
        // ReportsView
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(tabControl);
        Controls.Add(panelExport);
        Name = "ReportsView";
        Text = "Reports";
        ((System.ComponentModel.ISupportInitialize)tabControl).EndInit();
        tabControl.ResumeLayout(false);
        tabInvoicesByCustomer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridInvoicesByCustomer).EndInit();
        ((System.ComponentModel.ISupportInitialize)gridInvoicesByCustomerView).EndInit();
        tabMonthlySummary.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridMonthlySummary).EndInit();
        ((System.ComponentModel.ISupportInitialize)gridMonthlySummaryView).EndInit();
        tabCustomersByCountry.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridCustomersByCountry).EndInit();
        ((System.ComponentModel.ISupportInitialize)gridCustomersByCountryView).EndInit();
        panelExport.ResumeLayout(false);
        ResumeLayout(false);
    }
}
