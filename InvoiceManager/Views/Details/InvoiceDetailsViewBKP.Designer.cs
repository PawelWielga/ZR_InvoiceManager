namespace InvoiceManager.Views.Details
{
    partial class InvoiceDetailsViewBKP
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            labelControl5 = new DevExpress.XtraEditors.LabelControl();
            labelControl6 = new DevExpress.XtraEditors.LabelControl();
            txtNumber = new DevExpress.XtraEditors.TextEdit();
            txtNetAmount = new DevExpress.XtraEditors.TextEdit();
            txtCurrency = new DevExpress.XtraEditors.TextEdit();
            txtVatRate = new DevExpress.XtraEditors.TextEdit();
            dateSale = new DevExpress.XtraEditors.DateEdit();
            txtDescription = new DevExpress.XtraEditors.MemoEdit();
            comboCustomer = new DevExpress.XtraEditors.ComboBoxEdit();
            btnClearCustomer = new DevExpress.XtraEditors.SimpleButton();
            btnSave = new DevExpress.XtraEditors.SimpleButton();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)txtNumber.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNetAmount.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCurrency.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtVatRate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateSale.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateSale.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDescription.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)comboCustomer.Properties).BeginInit();
            SuspendLayout();
            // labelControl1
            labelControl1.Location = new System.Drawing.Point(12, 15);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(76, 13);
            labelControl1.TabIndex = 0;
            labelControl1.Text = "Invoice number:";
            // labelControl2
            labelControl2.Location = new System.Drawing.Point(12, 41);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new System.Drawing.Size(63, 13);
            labelControl2.TabIndex = 1;
            labelControl2.Text = "Net amount:";
            // labelControl3
            labelControl3.Location = new System.Drawing.Point(12, 67);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new System.Drawing.Size(46, 13);
            labelControl3.TabIndex = 2;
            labelControl3.Text = "Currency:";
            // labelControl4
            labelControl4.Location = new System.Drawing.Point(12, 93);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new System.Drawing.Size(46, 13);
            labelControl4.TabIndex = 3;
            labelControl4.Text = "VAT rate:";
            // labelControl5
            labelControl5.Location = new System.Drawing.Point(12, 119);
            labelControl5.Name = "labelControl5";
            labelControl5.Size = new System.Drawing.Size(55, 13);
            labelControl5.TabIndex = 4;
            labelControl5.Text = "Sale date:";
            // labelControl6
            labelControl6.Location = new System.Drawing.Point(12, 171);
            labelControl6.Name = "labelControl6";
            labelControl6.Size = new System.Drawing.Size(50, 13);
            labelControl6.TabIndex = 5;
            labelControl6.Text = "Customer:";
            // txtNumber
            txtNumber.Location = new System.Drawing.Point(94, 12);
            txtNumber.Name = "txtNumber";
            txtNumber.Size = new System.Drawing.Size(215, 20);
            txtNumber.TabIndex = 6;
            // txtNetAmount
            txtNetAmount.Location = new System.Drawing.Point(94, 38);
            txtNetAmount.Name = "txtNetAmount";
            txtNetAmount.Size = new System.Drawing.Size(215, 20);
            txtNetAmount.TabIndex = 7;
            // txtCurrency
            txtCurrency.Location = new System.Drawing.Point(94, 64);
            txtCurrency.Name = "txtCurrency";
            txtCurrency.Size = new System.Drawing.Size(215, 20);
            txtCurrency.TabIndex = 8;
            // txtVatRate
            txtVatRate.Location = new System.Drawing.Point(94, 90);
            txtVatRate.Name = "txtVatRate";
            txtVatRate.Size = new System.Drawing.Size(215, 20);
            txtVatRate.TabIndex = 9;
            // dateSale
            dateSale.EditValue = null;
            dateSale.Location = new System.Drawing.Point(94, 116);
            dateSale.Name = "dateSale";
            dateSale.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateSale.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateSale.Size = new System.Drawing.Size(215, 20);
            dateSale.TabIndex = 10;
            // txtDescription
            txtDescription.Location = new System.Drawing.Point(12, 209);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new System.Drawing.Size(297, 96);
            txtDescription.TabIndex = 12;
            // comboCustomer
            comboCustomer.Location = new System.Drawing.Point(94, 168);
            comboCustomer.Name = "comboCustomer";
            comboCustomer.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            comboCustomer.Size = new System.Drawing.Size(215, 20);
            comboCustomer.TabIndex = 11;
            // btnClearCustomer
            btnClearCustomer.Location = new System.Drawing.Point(315, 168);
            btnClearCustomer.Name = "btnClearCustomer";
            btnClearCustomer.Size = new System.Drawing.Size(50, 20);
            btnClearCustomer.TabIndex = 12;
            btnClearCustomer.Text = "Clear";
            // btnSave
            btnSave.Location = new System.Drawing.Point(12, 311);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(297, 23);
            btnSave.TabIndex = 13;
            btnSave.Text = "Save";
            // btnCancel
            btnCancel.Location = new System.Drawing.Point(12, 340);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(297, 23);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Cancel";
            // InvoiceDetailsView
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(321, 373);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtDescription);
            Controls.Add(btnClearCustomer);
            Controls.Add(comboCustomer);
            Controls.Add(dateSale);
            Controls.Add(txtVatRate);
            Controls.Add(txtCurrency);
            Controls.Add(txtNetAmount);
            Controls.Add(txtNumber);
            Controls.Add(labelControl6);
            Controls.Add(labelControl5);
            Controls.Add(labelControl4);
            Controls.Add(labelControl3);
            Controls.Add(labelControl2);
            Controls.Add(labelControl1);
            Name = "InvoiceDetailsView";
            Text = "InvoiceDetailsView";
            ((System.ComponentModel.ISupportInitialize)txtNumber.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNetAmount.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCurrency.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtVatRate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateSale.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateSale.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDescription.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)comboCustomer.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtNumber;
        private DevExpress.XtraEditors.TextEdit txtNetAmount;
        private DevExpress.XtraEditors.TextEdit txtCurrency;
        private DevExpress.XtraEditors.TextEdit txtVatRate;
        private DevExpress.XtraEditors.DateEdit dateSale;
        private DevExpress.XtraEditors.MemoEdit txtDescription;
        private DevExpress.XtraEditors.ComboBoxEdit comboCustomer;
        private DevExpress.XtraEditors.SimpleButton btnClearCustomer;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}
