namespace InvoiceManager.Views.Details;

partial class CustomerDetailsView
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
        labelControl1 = new DevExpress.XtraEditors.LabelControl();
        labelControl2 = new DevExpress.XtraEditors.LabelControl();
        txtName = new DevExpress.XtraEditors.TextEdit();
        txtCountry = new DevExpress.XtraEditors.TextEdit();
        btnSave = new DevExpress.XtraEditors.SimpleButton();
        btnCancel = new DevExpress.XtraEditors.SimpleButton();
        labelControl3 = new DevExpress.XtraEditors.LabelControl();
        labelControl4 = new DevExpress.XtraEditors.LabelControl();
        txtAbbreviation = new DevExpress.XtraEditors.TextEdit();
        txtTaxId = new DevExpress.XtraEditors.TextEdit();
        labelControl5 = new DevExpress.XtraEditors.LabelControl();
        labelControl6 = new DevExpress.XtraEditors.LabelControl();
        checkIsActive = new DevExpress.XtraEditors.CheckEdit();
        txtAddress = new DevExpress.XtraEditors.TextEdit();
        labelControl7 = new DevExpress.XtraEditors.LabelControl();
        dropDownTypeKind = new DevExpress.XtraEditors.ComboBoxEdit();
        ((System.ComponentModel.ISupportInitialize)txtName.Properties).BeginInit();
        ((System.ComponentModel.ISupportInitialize)txtCountry.Properties).BeginInit();
        ((System.ComponentModel.ISupportInitialize)txtAbbreviation.Properties).BeginInit();
        ((System.ComponentModel.ISupportInitialize)txtTaxId.Properties).BeginInit();
        ((System.ComponentModel.ISupportInitialize)checkIsActive.Properties).BeginInit();
        ((System.ComponentModel.ISupportInitialize)txtAddress.Properties).BeginInit();
        SuspendLayout();
        // 
        // labelControl1
        // 
        labelControl1.Location = new System.Drawing.Point(12, 15);
        labelControl1.Name = "labelControl1";
        labelControl1.Size = new System.Drawing.Size(31, 13);
        labelControl1.Text = "Name:";
        // 
        // labelControl2
        // 
        labelControl2.Location = new System.Drawing.Point(12, 93);
        labelControl2.Name = "labelControl2";
        labelControl2.Size = new System.Drawing.Size(36, 13);
        labelControl2.Text = "Tax ID:";
        // 
        // txtName
        // 
        txtName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        txtName.Location = new System.Drawing.Point(93, 12);
        txtName.Name = "txtName";
        txtName.Size = new System.Drawing.Size(215, 20);
        txtName.TabIndex = 0;
        // 
        // txtCountry
        // 
        txtCountry.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        txtCountry.Location = new System.Drawing.Point(93, 116);
        txtCountry.Name = "txtCountry";
        txtCountry.Size = new System.Drawing.Size(215, 20);
        txtCountry.TabIndex = 4;
        // 
        // btnSave
        // 
        btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        btnSave.Location = new System.Drawing.Point(12, 197);
        btnSave.Name = "btnSave";
        btnSave.Size = new System.Drawing.Size(296, 23);
        btnSave.TabIndex = 7;
        btnSave.Text = "Save";
        // 
        // btnCancel
        // 
        btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        btnCancel.Location = new System.Drawing.Point(12, 226);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new System.Drawing.Size(296, 23);
        btnCancel.TabIndex = 8;
        btnCancel.Text = "Cancel";
        // 
        // labelControl3
        // 
        labelControl3.Location = new System.Drawing.Point(12, 41);
        labelControl3.Name = "labelControl3";
        labelControl3.Size = new System.Drawing.Size(65, 13);
        labelControl3.Text = "Abbreviation:";
        // 
        // labelControl4
        // 
        labelControl4.Location = new System.Drawing.Point(12, 119);
        labelControl4.Name = "labelControl4";
        labelControl4.Size = new System.Drawing.Size(43, 13);
        labelControl4.Text = "Country:";
        // 
        // txtAbbreviation
        // 
        txtAbbreviation.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        txtAbbreviation.Location = new System.Drawing.Point(93, 38);
        txtAbbreviation.Name = "txtAbbreviation";
        txtAbbreviation.Size = new System.Drawing.Size(215, 20);
        txtAbbreviation.TabIndex = 1;
        // 
        // txtTaxId
        // 
        txtTaxId.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        txtTaxId.Location = new System.Drawing.Point(93, 90);
        txtTaxId.Name = "txtTaxId";
        txtTaxId.Size = new System.Drawing.Size(215, 20);
        txtTaxId.TabIndex = 3;
        // 
        // labelControl5
        // 
        labelControl5.Location = new System.Drawing.Point(12, 145);
        labelControl5.Name = "labelControl5";
        labelControl5.Size = new System.Drawing.Size(43, 13);
        labelControl5.Text = "Address:";
        // 
        // labelControl6
        // 
        labelControl6.Location = new System.Drawing.Point(12, 171);
        labelControl6.Name = "labelControl6";
        labelControl6.Size = new System.Drawing.Size(46, 13);
        labelControl6.Text = "Is Active:";
        // 
        // checkIsActive
        // 
        checkIsActive.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        checkIsActive.Location = new System.Drawing.Point(93, 168);
        checkIsActive.Name = "checkIsActive";
        checkIsActive.Properties.Caption = "";
        checkIsActive.Size = new System.Drawing.Size(215, 20);
        checkIsActive.TabIndex = 6;
        // 
        // txtAddress
        // 
        txtAddress.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        txtAddress.Location = new System.Drawing.Point(93, 142);
        txtAddress.Name = "txtAddress";
        txtAddress.Size = new System.Drawing.Size(215, 20);
        txtAddress.TabIndex = 5;
        // 
        // labelControl7
        // 
        labelControl7.Location = new System.Drawing.Point(12, 67);
        labelControl7.Name = "labelControl7";
        labelControl7.Size = new System.Drawing.Size(28, 13);
        labelControl7.Text = "Type:";
        // 
        // dropDownTypeKind
        // 
        dropDownTypeKind.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        dropDownTypeKind.Location = new System.Drawing.Point(93, 62);
        dropDownTypeKind.Name = "dropDownTypeKind";
        dropDownTypeKind.Size = new System.Drawing.Size(215, 23);
        dropDownTypeKind.TabIndex = 2;
        dropDownTypeKind.Text = "dropDownButton1";
        // 
        // CustomerDetailsView
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(323, 264);
        Controls.Add(dropDownTypeKind);
        Controls.Add(labelControl7);
        Controls.Add(txtAddress);
        Controls.Add(checkIsActive);
        Controls.Add(labelControl6);
        Controls.Add(labelControl5);
        Controls.Add(txtTaxId);
        Controls.Add(txtAbbreviation);
        Controls.Add(labelControl4);
        Controls.Add(labelControl3);
        Controls.Add(btnCancel);
        Controls.Add(btnSave);
        Controls.Add(txtCountry);
        Controls.Add(txtName);
        Controls.Add(labelControl2);
        Controls.Add(labelControl1);
        Name = "CustomerDetailsView";
        Text = "CustomerDetailsView";
        ((System.ComponentModel.ISupportInitialize)txtName.Properties).EndInit();
        ((System.ComponentModel.ISupportInitialize)txtCountry.Properties).EndInit();
        ((System.ComponentModel.ISupportInitialize)txtAbbreviation.Properties).EndInit();
        ((System.ComponentModel.ISupportInitialize)txtTaxId.Properties).EndInit();
        ((System.ComponentModel.ISupportInitialize)checkIsActive.Properties).EndInit();
        ((System.ComponentModel.ISupportInitialize)txtAddress.Properties).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraEditors.LabelControl labelControl2;
    private DevExpress.XtraEditors.TextEdit txtName;
    private DevExpress.XtraEditors.TextEdit txtCountry;
    private DevExpress.XtraEditors.SimpleButton btnSave;
    private DevExpress.XtraEditors.SimpleButton btnCancel;
    private DevExpress.XtraEditors.LabelControl labelControl3;
    private DevExpress.XtraEditors.LabelControl labelControl4;
    private DevExpress.XtraEditors.TextEdit txtAbbreviation;
    private DevExpress.XtraEditors.TextEdit txtTaxId;
    private DevExpress.XtraEditors.LabelControl labelControl5;
    private DevExpress.XtraEditors.LabelControl labelControl6;
    private DevExpress.XtraEditors.CheckEdit checkIsActive;
    private DevExpress.XtraEditors.TextEdit txtAddress;
    private DevExpress.XtraEditors.LabelControl labelControl7;
    private DevExpress.XtraEditors.ComboBoxEdit dropDownTypeKind;
}