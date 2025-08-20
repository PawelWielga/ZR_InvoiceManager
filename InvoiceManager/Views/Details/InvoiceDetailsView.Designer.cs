namespace InvoiceManager.Views.Details;

partial class InvoiceDetailsView
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
        this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
        this.slueCustomer = new DevExpress.XtraEditors.SearchLookUpEdit(); 
        this.slueCustomer_PopupView = new DevExpress.XtraGrid.Views.Grid.GridView();
        this.stackPanel1 = new DevExpress.Utils.Layout.StackPanel();
        this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
        this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
        this.btnSave = new DevExpress.XtraEditors.SimpleButton();
        this.tablePanel2 = new DevExpress.Utils.Layout.TablePanel();
        this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
        this.txtDescription = new DevExpress.XtraEditors.TextEdit();
        this.txtSaleDate = new DevExpress.XtraEditors.DateEdit();
        this.txtVatRate = new DevExpress.XtraEditors.TextEdit();
        this.txtCurrency = new DevExpress.XtraEditors.TextEdit();
        this.txtNetAmount = new DevExpress.XtraEditors.TextEdit();
        this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
        this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
        this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
        this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
        this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
        this.txtInvoiceNumber = new DevExpress.XtraEditors.TextEdit();
        ((System.ComponentModel.ISupportInitialize)(this.slueCustomer.Properties)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.slueCustomer_PopupView)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.stackPanel1)).BeginInit();
        this.stackPanel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
        this.tablePanel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).BeginInit();
        this.tablePanel2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtSaleDate.Properties.CalendarTimeProperties)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtSaleDate.Properties)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtVatRate.Properties)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtCurrency.Properties)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtNetAmount.Properties)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceNumber.Properties)).BeginInit();
        this.SuspendLayout();
        //
        // labelControl6
        //
        this.labelControl6.Location = new System.Drawing.Point(140, 12);
        this.labelControl6.Name = "labelControl6";
        this.labelControl6.Size = new System.Drawing.Size(82, 13);
        this.labelControl6.TabIndex = 5;
        this.labelControl6.Text = "Select Customer";
        //
        // slueCustomer
        //
        this.slueCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.slueCustomer.Location = new System.Drawing.Point(16, 29);
        this.slueCustomer.Name = "slueCustomer";
        this.slueCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
        this.slueCustomer.Properties.PopupView = this.slueCustomer_PopupView;
        this.slueCustomer.Size = new System.Drawing.Size(330, 20);
        this.slueCustomer.TabIndex = 6;
        //
        // slueCustomer_PopupView
        //
        this.slueCustomer_PopupView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
        this.slueCustomer_PopupView.Name = "slueCustomer_PopupView";
        this.slueCustomer_PopupView.OptionsSelection.EnableAppearanceFocusedCell = false;
        this.slueCustomer_PopupView.OptionsView.ShowGroupPanel = false;
        //
        // stackPanel1
        //
        this.tablePanel1.SetColumn(this.stackPanel1, 1);
        this.stackPanel1.Controls.Add(this.labelControl6);
        this.stackPanel1.Controls.Add(this.slueCustomer);
        this.stackPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.stackPanel1.LayoutDirection = DevExpress.Utils.Layout.StackPanelLayoutDirection.TopDown;
        this.stackPanel1.Location = new System.Drawing.Point(357, 12);
        this.stackPanel1.Name = "stackPanel1";
        this.tablePanel1.SetRow(this.stackPanel1, 0);
        this.stackPanel1.Size = new System.Drawing.Size(362, 345);
        this.stackPanel1.TabIndex = 14;
        this.stackPanel1.UseSkinIndents = true;
        //
        // tablePanel1
        //
        this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
        new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 5F),
        new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 55F)});
        this.tablePanel1.Controls.Add(this.btnCancel);
        this.tablePanel1.Controls.Add(this.btnSave);
        this.tablePanel1.Controls.Add(this.tablePanel2);
        this.tablePanel1.Controls.Add(this.stackPanel1);
        this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tablePanel1.Location = new System.Drawing.Point(0, 0);
        this.tablePanel1.Name = "tablePanel1";
        this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
        new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 26F),
        new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F)});
        this.tablePanel1.Size = new System.Drawing.Size(732, 397);
        this.tablePanel1.TabIndex = 15;
        this.tablePanel1.UseSkinIndents = true;
        //
        // btnCancel
        //
        this.tablePanel1.SetColumn(this.btnCancel, 1);
        this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnCancel.Location = new System.Drawing.Point(357, 361);
        this.btnCancel.Name = "btnCancel";
        this.tablePanel1.SetRow(this.btnCancel, 1);
        this.btnCancel.Size = new System.Drawing.Size(362, 23);
        this.btnCancel.TabIndex = 17;
        this.btnCancel.Text = "Cancel";
        //
        // btnSave
        //
        this.tablePanel1.SetColumn(this.btnSave, 0);
        this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnSave.Location = new System.Drawing.Point(13, 361);
        this.btnSave.Name = "btnSave";
        this.tablePanel1.SetRow(this.btnSave, 1);
        this.btnSave.Size = new System.Drawing.Size(340, 23);
        this.btnSave.TabIndex = 16;
        this.btnSave.Text = "Save";
        //
        // tablePanel2
        //
        this.tablePanel1.SetColumn(this.tablePanel2, 0);
        this.tablePanel2.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
        new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 5F),
        new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 55F)});
        this.tablePanel2.Controls.Add(this.labelControl7);
        this.tablePanel2.Controls.Add(this.txtDescription);
        this.tablePanel2.Controls.Add(this.txtSaleDate);
        this.tablePanel2.Controls.Add(this.txtVatRate);
        this.tablePanel2.Controls.Add(this.txtCurrency);
        this.tablePanel2.Controls.Add(this.txtNetAmount);
        this.tablePanel2.Controls.Add(this.labelControl5);
        this.tablePanel2.Controls.Add(this.labelControl4);
        this.tablePanel2.Controls.Add(this.labelControl3);
        this.tablePanel2.Controls.Add(this.labelControl2);
        this.tablePanel2.Controls.Add(this.labelControl1);
        this.tablePanel2.Controls.Add(this.txtInvoiceNumber);
        this.tablePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tablePanel2.Location = new System.Drawing.Point(13, 12);
        this.tablePanel2.Name = "tablePanel2";
        this.tablePanel1.SetRow(this.tablePanel2, 0);
        this.tablePanel2.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
        new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
        new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
        new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
        new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
        new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
        new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
        new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
        this.tablePanel2.Size = new System.Drawing.Size(340, 345);
        this.tablePanel2.TabIndex = 15;
        this.tablePanel2.UseSkinIndents = true;
        //
        // labelControl7
        //
        this.tablePanel2.SetColumn(this.labelControl7, 0);
        this.labelControl7.Location = new System.Drawing.Point(13, 135);
        this.labelControl7.Name = "labelControl7";
        this.tablePanel2.SetRow(this.labelControl7, 5);
        this.labelControl7.Size = new System.Drawing.Size(57, 13);
        this.labelControl7.TabIndex = 11;
        this.labelControl7.Text = "Description:";
        //
        // txtDescription
        //
        this.tablePanel2.SetColumn(this.txtDescription, 1);
        this.txtDescription.Location = new System.Drawing.Point(96, 132);
        this.txtDescription.Name = "txtDescription";
        this.tablePanel2.SetRow(this.txtDescription, 5);
        this.txtDescription.Size = new System.Drawing.Size(231, 20);
        this.txtDescription.TabIndex = 10;
        //
        // txtSaleDate
        //
        this.tablePanel2.SetColumn(this.txtSaleDate, 1);
        this.txtSaleDate.Location = new System.Drawing.Point(96, 108);
        this.txtSaleDate.Name = "txtSaleDate";
        this.txtSaleDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
        this.txtSaleDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
        this.tablePanel2.SetRow(this.txtSaleDate, 4);
        this.txtSaleDate.Size = new System.Drawing.Size(231, 20);
        this.txtSaleDate.TabIndex = 9;
        //
        // txtVatRate
        //
        this.tablePanel2.SetColumn(this.txtVatRate, 1);
        this.txtVatRate.Location = new System.Drawing.Point(96, 84);
        this.txtVatRate.Name = "txtVatRate";
        this.tablePanel2.SetRow(this.txtVatRate, 3);
        this.txtVatRate.Size = new System.Drawing.Size(231, 20);
        this.txtVatRate.TabIndex = 8;
        //
        // txtCurrency
        //
        this.tablePanel2.SetColumn(this.txtCurrency, 1);
        this.txtCurrency.Location = new System.Drawing.Point(96, 60);
        this.txtCurrency.Name = "txtCurrency";
        this.tablePanel2.SetRow(this.txtCurrency, 2);
        this.txtCurrency.Size = new System.Drawing.Size(231, 20);
        this.txtCurrency.TabIndex = 7;
        //
        // txtNetAmount
        //
        this.tablePanel2.SetColumn(this.txtNetAmount, 1);
        this.txtNetAmount.Location = new System.Drawing.Point(96, 36);
        this.txtNetAmount.Name = "txtNetAmount";
        this.tablePanel2.SetRow(this.txtNetAmount, 1);
        this.txtNetAmount.Size = new System.Drawing.Size(231, 20);
        this.txtNetAmount.TabIndex = 6;
        //
        // labelControl5
        //
        this.tablePanel2.SetColumn(this.labelControl5, 0);
        this.labelControl5.Location = new System.Drawing.Point(13, 111);
        this.labelControl5.Name = "labelControl5";
        this.tablePanel2.SetRow(this.labelControl5, 4);
        this.labelControl5.Size = new System.Drawing.Size(50, 13);
        this.labelControl5.TabIndex = 5;
        this.labelControl5.Text = "Sale Date:";
        //
        // labelControl4
        //
        this.tablePanel2.SetColumn(this.labelControl4, 0);
        this.labelControl4.Location = new System.Drawing.Point(13, 87);
        this.labelControl4.Name = "labelControl4";
        this.tablePanel2.SetRow(this.labelControl4, 3);
        this.labelControl4.Size = new System.Drawing.Size(46, 13);
        this.labelControl4.TabIndex = 4;
        this.labelControl4.Text = "Vat Rate:";
        //
        // labelControl3
        //
        this.tablePanel2.SetColumn(this.labelControl3, 0);
        this.labelControl3.Location = new System.Drawing.Point(13, 63);
        this.labelControl3.Name = "labelControl3";
        this.tablePanel2.SetRow(this.labelControl3, 2);
        this.labelControl3.Size = new System.Drawing.Size(48, 13);
        this.labelControl3.TabIndex = 3;
        this.labelControl3.Text = "Currency:";
        //
        // labelControl2
        //
        this.tablePanel2.SetColumn(this.labelControl2, 0);
        this.labelControl2.Location = new System.Drawing.Point(13, 39);
        this.labelControl2.Name = "labelControl2";
        this.tablePanel2.SetRow(this.labelControl2, 1);
        this.labelControl2.Size = new System.Drawing.Size(61, 13);
        this.labelControl2.TabIndex = 2;
        this.labelControl2.Text = "Net Amount:";
        //
        // labelControl1
        //
        this.tablePanel2.SetColumn(this.labelControl1, 0);
        this.labelControl1.Location = new System.Drawing.Point(13, 15);
        this.labelControl1.Name = "labelControl1";
        this.tablePanel2.SetRow(this.labelControl1, 0);
        this.labelControl1.Size = new System.Drawing.Size(79, 13);
        this.labelControl1.TabIndex = 1;
        this.labelControl1.Text = "Invoice Number:";
        //
        // txtInvoiceNumber
        //
        this.tablePanel2.SetColumn(this.txtInvoiceNumber, 1);
        this.txtInvoiceNumber.Location = new System.Drawing.Point(96, 12);
        this.txtInvoiceNumber.Name = "txtInvoiceNumber";
        this.tablePanel2.SetRow(this.txtInvoiceNumber, 0);
        this.txtInvoiceNumber.Size = new System.Drawing.Size(231, 20);
        this.txtInvoiceNumber.TabIndex = 0;
        //
        // InvoiceDetailsView
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(732, 397);
        this.Controls.Add(this.tablePanel1);
        this.Name = "InvoiceDetailsView";
        this.Text = "InvoiceDetailsView";
        ((System.ComponentModel.ISupportInitialize)(this.slueCustomer.Properties)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.slueCustomer_PopupView)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.stackPanel1)).EndInit();
        this.stackPanel1.ResumeLayout(false);
        this.stackPanel1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
        this.tablePanel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).EndInit();
        this.tablePanel2.ResumeLayout(false);
        this.tablePanel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtSaleDate.Properties.CalendarTimeProperties)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtSaleDate.Properties)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtVatRate.Properties)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtCurrency.Properties)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtNetAmount.Properties)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceNumber.Properties)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion
    private DevExpress.XtraEditors.LabelControl labelControl6;
    private DevExpress.Utils.Layout.StackPanel stackPanel1;
    private DevExpress.Utils.Layout.TablePanel tablePanel1;
    private DevExpress.Utils.Layout.TablePanel tablePanel2;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraEditors.TextEdit txtInvoiceNumber;
    private DevExpress.XtraEditors.LabelControl labelControl5;
    private DevExpress.XtraEditors.LabelControl labelControl4;
    private DevExpress.XtraEditors.LabelControl labelControl3;
    private DevExpress.XtraEditors.LabelControl labelControl2;
    private DevExpress.XtraEditors.LabelControl labelControl7;
    private DevExpress.XtraEditors.TextEdit txtDescription;
    private DevExpress.XtraEditors.DateEdit txtSaleDate;
    private DevExpress.XtraEditors.TextEdit txtVatRate;
    private DevExpress.XtraEditors.TextEdit txtCurrency;
    private DevExpress.XtraEditors.TextEdit txtNetAmount;
    private DevExpress.XtraEditors.SimpleButton btnCancel;
    private DevExpress.XtraEditors.SimpleButton btnSave;
    private DevExpress.XtraEditors.SearchLookUpEdit slueCustomer;
    private DevExpress.XtraGrid.Views.Grid.GridView slueCustomer_PopupView;
}