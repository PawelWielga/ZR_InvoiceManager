namespace InvoiceManager.Views;

partial class MainView
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
        btnAddCustomer = new DevExpress.XtraBars.BarButtonItem();
        btnEditCustomer = new DevExpress.XtraBars.BarButtonItem();
        btnDeleteCustomer = new DevExpress.XtraBars.BarButtonItem();
        btnAddInvoice = new DevExpress.XtraBars.BarButtonItem();
        btnEditInvoice = new DevExpress.XtraBars.BarButtonItem();
        btnDeleteInvoice = new DevExpress.XtraBars.BarButtonItem();
        btnShowReports = new DevExpress.XtraBars.BarButtonItem();
        ribbonPageCRUD = new DevExpress.XtraBars.Ribbon.RibbonPage();
        ribbonPageCustomerActions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
        ribbonPageInvoiceActions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
        ribbonPageReports = new DevExpress.XtraBars.Ribbon.RibbonPage();
        ribbonPageReportsGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
        ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
        tabPaneMain = new DevExpress.XtraBars.Navigation.TabPane();
        tabPageCustomers = new DevExpress.XtraBars.Navigation.TabNavigationPage();
        gridControlCustomers = new DevExpress.XtraGrid.GridControl();
        gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
        panelGenerateCustomers = new System.Windows.Forms.Panel();
        lblCustomerGenerateCount = new DevExpress.XtraEditors.LabelControl();
        txtCustomerGenerateCount = new DevExpress.XtraEditors.TextEdit();
        btnGenerateCustomers = new DevExpress.XtraEditors.SimpleButton();
        tabPageInvoices = new DevExpress.XtraBars.Navigation.TabNavigationPage();
        gridControlInvoices = new DevExpress.XtraGrid.GridControl();
        gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
        panelGenerateInvoices = new System.Windows.Forms.Panel();
        lblInvoiceGenerateCount = new DevExpress.XtraEditors.LabelControl();
        txtInvoiceGenerateCount = new DevExpress.XtraEditors.TextEdit();
        btnGenerateInvoices = new DevExpress.XtraEditors.SimpleButton();
        ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
        ((System.ComponentModel.ISupportInitialize)tabPaneMain).BeginInit();
        tabPaneMain.SuspendLayout();
        tabPageCustomers.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridControlCustomers).BeginInit();
        ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
        panelGenerateCustomers.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)txtCustomerGenerateCount.Properties).BeginInit();
        tabPageInvoices.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridControlInvoices).BeginInit();
        ((System.ComponentModel.ISupportInitialize)gridView2).BeginInit();
        panelGenerateInvoices.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)txtInvoiceGenerateCount.Properties).BeginInit();
        SuspendLayout();
        // 
        // ribbon
        // 
        ribbon.ExpandCollapseItem.Id = 0;
        ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbon.ExpandCollapseItem, btnAddCustomer, btnEditCustomer, btnDeleteCustomer, btnAddInvoice, btnEditInvoice, btnDeleteInvoice, btnShowReports });
        ribbon.Location = new System.Drawing.Point(0, 0);
        ribbon.MaxItemId = 8;
        ribbon.Name = "ribbon";
        ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPageCRUD, ribbonPageReports });
        ribbon.Size = new System.Drawing.Size(1043, 158);
        ribbon.StatusBar = ribbonStatusBar;
        // 
        // btnAddCustomer
        // 
        btnAddCustomer.Caption = "Add Customer";
        btnAddCustomer.Id = 1;
        btnAddCustomer.ItemAppearance.Normal.Options.UseBackColor = true;
        btnAddCustomer.Name = "btnAddCustomer";
        // 
        // btnEditCustomer
        // 
        btnEditCustomer.Caption = "Edit Customer";
        btnEditCustomer.Id = 2;
        btnEditCustomer.ItemAppearance.Normal.Options.UseBackColor = true;
        btnEditCustomer.Name = "btnEditCustomer";
        // 
        // btnDeleteCustomer
        // 
        btnDeleteCustomer.Caption = "Delete Customer";
        btnDeleteCustomer.Id = 3;
        btnDeleteCustomer.ItemAppearance.Normal.Options.UseBackColor = true;
        btnDeleteCustomer.Name = "btnDeleteCustomer";
        // 
        // btnAddInvoice
        // 
        btnAddInvoice.Caption = "Add Invoice";
        btnAddInvoice.Id = 4;
        btnAddInvoice.ItemAppearance.Normal.Options.UseBackColor = true;
        btnAddInvoice.Name = "btnAddInvoice";
        // 
        // btnEditInvoice
        // 
        btnEditInvoice.Caption = "Edit Invoice";
        btnEditInvoice.Id = 5;
        btnEditInvoice.ItemAppearance.Normal.Options.UseBackColor = true;
        btnEditInvoice.Name = "btnEditInvoice";
        // 
        // btnDeleteInvoice
        // 
        btnDeleteInvoice.Caption = "Delete Invoice";
        btnDeleteInvoice.Id = 6;
        btnDeleteInvoice.ItemAppearance.Normal.Options.UseBackColor = true;
        btnDeleteInvoice.Name = "btnDeleteInvoice";
        //
        // btnShowReports
        //
        btnShowReports.Caption = "Reports";
        btnShowReports.Id = 7;
        btnShowReports.ItemAppearance.Normal.Options.UseBackColor = true;
        btnShowReports.Name = "btnShowReports";
        //
        // ribbonPageCRUD
        //
        ribbonPageCRUD.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageCustomerActions, ribbonPageInvoiceActions });
        ribbonPageCRUD.Name = "ribbonPageCRUD";
        ribbonPageCRUD.Text = "CRUD";
        // 
        // ribbonPageCustomerActions
        // 
        ribbonPageCustomerActions.ItemLinks.Add(btnAddCustomer);
        ribbonPageCustomerActions.ItemLinks.Add(btnEditCustomer);
        ribbonPageCustomerActions.ItemLinks.Add(btnDeleteCustomer);
        ribbonPageCustomerActions.Name = "ribbonPageCustomerActions";
        ribbonPageCustomerActions.Text = "Customer";
        // 
        // ribbonPageInvoiceActions
        // 
        ribbonPageInvoiceActions.ItemLinks.Add(btnAddInvoice);
        ribbonPageInvoiceActions.ItemLinks.Add(btnEditInvoice);
        ribbonPageInvoiceActions.ItemLinks.Add(btnDeleteInvoice);
        ribbonPageInvoiceActions.Name = "ribbonPageInvoiceActions";
        ribbonPageInvoiceActions.Text = "Invoice";
        //
        // ribbonPageReports
        //
        ribbonPageReports.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageReportsGroup });
        ribbonPageReports.Name = "ribbonPageReports";
        ribbonPageReports.Text = "Reports";
        //
        // ribbonPageReportsGroup
        //
        ribbonPageReportsGroup.ItemLinks.Add(btnShowReports);
        ribbonPageReportsGroup.Name = "ribbonPageReportsGroup";
        // 
        // ribbonStatusBar
        // 
        ribbonStatusBar.Location = new System.Drawing.Point(0, 483);
        ribbonStatusBar.Name = "ribbonStatusBar";
        ribbonStatusBar.Ribbon = ribbon;
        ribbonStatusBar.Size = new System.Drawing.Size(1043, 24);
        // 
        // tabPaneMain
        // 
        tabPaneMain.AllowHtmlDraw = false;
        tabPaneMain.Controls.Add(tabPageCustomers);
        tabPaneMain.Controls.Add(tabPageInvoices);
        tabPaneMain.Dock = System.Windows.Forms.DockStyle.Fill;
        tabPaneMain.Location = new System.Drawing.Point(0, 158);
        tabPaneMain.Name = "tabPaneMain";
        tabPaneMain.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] { tabPageCustomers, tabPageInvoices });
        tabPaneMain.RegularSize = new System.Drawing.Size(1043, 325);
        tabPaneMain.SelectedPage = tabPageCustomers;
        tabPaneMain.Size = new System.Drawing.Size(1043, 325);
        tabPaneMain.TabIndex = 2;
        tabPaneMain.Text = "tabPane1";
        // 
        // tabPageCustomers
        // 
        tabPageCustomers.Caption = "Customers";
        tabPageCustomers.Controls.Add(gridControlCustomers);
        tabPageCustomers.Controls.Add(panelGenerateCustomers);
        tabPageCustomers.Name = "tabPageCustomers";
        tabPageCustomers.Size = new System.Drawing.Size(1043, 292);
        // 
        // gridControlCustomers
        // 
        gridControlCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
        gridControlCustomers.Location = new System.Drawing.Point(0, 32);
        gridControlCustomers.MainView = gridView1;
        gridControlCustomers.MenuManager = ribbon;
        gridControlCustomers.Name = "gridControlCustomers";
        gridControlCustomers.Size = new System.Drawing.Size(1043, 260);
        gridControlCustomers.TabIndex = 0;
        gridControlCustomers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
        // 
        // gridView1
        // 
        gridView1.GridControl = gridControlCustomers;
        gridView1.Name = "gridView1";
        // 
        // panelGenerateCustomers
        // 
        panelGenerateCustomers.Controls.Add(lblCustomerGenerateCount);
        panelGenerateCustomers.Controls.Add(txtCustomerGenerateCount);
        panelGenerateCustomers.Controls.Add(btnGenerateCustomers);
        panelGenerateCustomers.Dock = System.Windows.Forms.DockStyle.Top;
        panelGenerateCustomers.Location = new System.Drawing.Point(0, 0);
        panelGenerateCustomers.Name = "panelGenerateCustomers";
        panelGenerateCustomers.Size = new System.Drawing.Size(1043, 32);
        panelGenerateCustomers.TabIndex = 1;
        // 
        // lblCustomerGenerateCount
        // 
        lblCustomerGenerateCount.Location = new System.Drawing.Point(3, 9);
        lblCustomerGenerateCount.Name = "lblCustomerGenerateCount";
        lblCustomerGenerateCount.Size = new System.Drawing.Size(115, 13);
        lblCustomerGenerateCount.TabIndex = 0;
        lblCustomerGenerateCount.Text = "Customers to generate:";
        // 
        // txtCustomerGenerateCount
        // 
        txtCustomerGenerateCount.Location = new System.Drawing.Point(135, 6);
        txtCustomerGenerateCount.Name = "txtCustomerGenerateCount";
        txtCustomerGenerateCount.Size = new System.Drawing.Size(100, 20);
        txtCustomerGenerateCount.TabIndex = 1;
        // 
        // btnGenerateCustomers
        // 
        btnGenerateCustomers.Location = new System.Drawing.Point(241, 4);
        btnGenerateCustomers.Name = "btnGenerateCustomers";
        btnGenerateCustomers.Size = new System.Drawing.Size(147, 23);
        btnGenerateCustomers.TabIndex = 2;
        btnGenerateCustomers.Text = "Generate Customers";
        // 
        // tabPageInvoices
        // 
        tabPageInvoices.Caption = "Invoices";
        tabPageInvoices.Controls.Add(gridControlInvoices);
        tabPageInvoices.Controls.Add(panelGenerateInvoices);
        tabPageInvoices.Name = "tabPageInvoices";
        tabPageInvoices.Size = new System.Drawing.Size(1043, 292);
        // 
        // gridControlInvoices
        // 
        gridControlInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
        gridControlInvoices.Location = new System.Drawing.Point(0, 32);
        gridControlInvoices.MainView = gridView2;
        gridControlInvoices.MenuManager = ribbon;
        gridControlInvoices.Name = "gridControlInvoices";
        gridControlInvoices.Size = new System.Drawing.Size(1043, 260);
        gridControlInvoices.TabIndex = 0;
        gridControlInvoices.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView2 });
        // 
        // gridView2
        // 
        gridView2.GridControl = gridControlInvoices;
        gridView2.Name = "gridView2";
        // 
        // panelGenerateInvoices
        // 
        panelGenerateInvoices.Controls.Add(lblInvoiceGenerateCount);
        panelGenerateInvoices.Controls.Add(txtInvoiceGenerateCount);
        panelGenerateInvoices.Controls.Add(btnGenerateInvoices);
        panelGenerateInvoices.Dock = System.Windows.Forms.DockStyle.Top;
        panelGenerateInvoices.Location = new System.Drawing.Point(0, 0);
        panelGenerateInvoices.Name = "panelGenerateInvoices";
        panelGenerateInvoices.Size = new System.Drawing.Size(1043, 32);
        panelGenerateInvoices.TabIndex = 1;
        // 
        // lblInvoiceGenerateCount
        // 
        lblInvoiceGenerateCount.Location = new System.Drawing.Point(3, 9);
        lblInvoiceGenerateCount.Name = "lblInvoiceGenerateCount";
        lblInvoiceGenerateCount.Size = new System.Drawing.Size(110, 13);
        lblInvoiceGenerateCount.TabIndex = 0;
        lblInvoiceGenerateCount.Text = "Invoices per customer:";
        // 
        // txtInvoiceGenerateCount
        // 
        txtInvoiceGenerateCount.Location = new System.Drawing.Point(135, 6);
        txtInvoiceGenerateCount.Name = "txtInvoiceGenerateCount";
        txtInvoiceGenerateCount.Size = new System.Drawing.Size(100, 20);
        txtInvoiceGenerateCount.TabIndex = 1;
        // 
        // btnGenerateInvoices
        // 
        btnGenerateInvoices.Location = new System.Drawing.Point(241, 4);
        btnGenerateInvoices.Name = "btnGenerateInvoices";
        btnGenerateInvoices.Size = new System.Drawing.Size(147, 23);
        btnGenerateInvoices.TabIndex = 2;
        btnGenerateInvoices.Text = "Generate Invoices";
        // 
        // MainView
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1043, 507);
        Controls.Add(tabPaneMain);
        Controls.Add(ribbonStatusBar);
        Controls.Add(ribbon);
        Name = "MainView";
        Ribbon = ribbon;
        StatusBar = ribbonStatusBar;
        Text = "MainView";
        ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
        ((System.ComponentModel.ISupportInitialize)tabPaneMain).EndInit();
        tabPaneMain.ResumeLayout(false);
        tabPageCustomers.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridControlCustomers).EndInit();
        ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
        panelGenerateCustomers.ResumeLayout(false);
        panelGenerateCustomers.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)txtCustomerGenerateCount.Properties).EndInit();
        tabPageInvoices.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridControlInvoices).EndInit();
        ((System.ComponentModel.ISupportInitialize)gridView2).EndInit();
        panelGenerateInvoices.ResumeLayout(false);
        panelGenerateInvoices.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)txtInvoiceGenerateCount.Properties).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
    private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageCRUD;
    private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageCustomerActions;
    private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
    private DevExpress.XtraBars.Navigation.TabPane tabPaneMain;
    private DevExpress.XtraBars.Navigation.TabNavigationPage tabPageCustomers;
    private DevExpress.XtraBars.Navigation.TabNavigationPage tabPageInvoices;
    private DevExpress.XtraGrid.GridControl gridControlCustomers;
    private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    private DevExpress.XtraGrid.GridControl gridControlInvoices;
    private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
    private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageInvoiceActions;
    private DevExpress.XtraBars.BarButtonItem btnAddCustomer;
    private DevExpress.XtraBars.BarButtonItem btnEditCustomer;
    private DevExpress.XtraBars.BarButtonItem btnDeleteCustomer;
    private DevExpress.XtraBars.BarButtonItem btnAddInvoice;
    private DevExpress.XtraBars.BarButtonItem btnEditInvoice;
    private DevExpress.XtraBars.BarButtonItem btnDeleteInvoice;
    private System.Windows.Forms.Panel panelGenerateCustomers;
    private DevExpress.XtraEditors.LabelControl lblCustomerGenerateCount;
    private DevExpress.XtraEditors.TextEdit txtCustomerGenerateCount;
    private DevExpress.XtraEditors.SimpleButton btnGenerateCustomers;
    private System.Windows.Forms.Panel panelGenerateInvoices;
    private DevExpress.XtraEditors.LabelControl lblInvoiceGenerateCount;
    private DevExpress.XtraEditors.TextEdit txtInvoiceGenerateCount;
    private DevExpress.XtraEditors.SimpleButton btnGenerateInvoices;
    private DevExpress.XtraBars.BarButtonItem btnShowReports;
    private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageReports;
    private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageReportsGroup;
}