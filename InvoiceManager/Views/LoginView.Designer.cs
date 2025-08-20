namespace InvoiceManager.Views;

partial class LoginView
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
        txtServerName = new DevExpress.XtraEditors.TextEdit();
        txtDatabaseName = new DevExpress.XtraEditors.TextEdit();
        btnConnect = new DevExpress.XtraEditors.SimpleButton();
        lblErrorMessage = new DevExpress.XtraEditors.LabelControl();
        labelServerName = new DevExpress.XtraEditors.LabelControl();
        labelDatabaseName = new DevExpress.XtraEditors.LabelControl();
        ((System.ComponentModel.ISupportInitialize)txtServerName.Properties).BeginInit();
        ((System.ComponentModel.ISupportInitialize)txtDatabaseName.Properties).BeginInit();
        SuspendLayout();
        // 
        // txtServerName
        // 
        txtServerName.Location = new System.Drawing.Point(68, 35);
        txtServerName.Name = "txtServerName";
        txtServerName.Size = new System.Drawing.Size(318, 20);
        txtServerName.TabIndex = 0;
        // 
        // txtDatabaseName
        // 
        txtDatabaseName.Location = new System.Drawing.Point(68, 61);
        txtDatabaseName.Name = "txtDatabaseName";
        txtDatabaseName.Size = new System.Drawing.Size(318, 20);
        txtDatabaseName.TabIndex = 1;
        // 
        // btnConnect
        // 
        btnConnect.Location = new System.Drawing.Point(12, 106);
        btnConnect.Name = "btnConnect";
        btnConnect.Size = new System.Drawing.Size(374, 23);
        btnConnect.TabIndex = 2;
        btnConnect.Text = "Connect";
        // 
        // lblErrorMessage
        // 
        lblErrorMessage.Appearance.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
        lblErrorMessage.Appearance.Options.UseForeColor = true;
        lblErrorMessage.Location = new System.Drawing.Point(68, 87);
        lblErrorMessage.Name = "lblErrorMessage";
        lblErrorMessage.Size = new System.Drawing.Size(24, 13);
        lblErrorMessage.TabIndex = 3;
        lblErrorMessage.Text = "error";
        // 
        // labelServerName
        // 
        labelServerName.Location = new System.Drawing.Point(26, 38);
        labelServerName.Name = "labelServerName";
        labelServerName.Size = new System.Drawing.Size(36, 13);
        labelServerName.TabIndex = 4;
        labelServerName.Text = "Server:";
        // 
        // labelDatabaseName
        // 
        labelDatabaseName.Location = new System.Drawing.Point(12, 64);
        labelDatabaseName.Name = "labelDatabaseName";
        labelDatabaseName.Size = new System.Drawing.Size(50, 13);
        labelDatabaseName.TabIndex = 5;
        labelDatabaseName.Text = "Database:";
        // 
        // LoginView
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(398, 168);
        Controls.Add(labelDatabaseName);
        Controls.Add(labelServerName);
        Controls.Add(lblErrorMessage);
        Controls.Add(btnConnect);
        Controls.Add(txtDatabaseName);
        Controls.Add(txtServerName);
        MaximizeBox = false;
        Name = "LoginView";
        SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "LoginView";
        ((System.ComponentModel.ISupportInitialize)txtServerName.Properties).EndInit();
        ((System.ComponentModel.ISupportInitialize)txtDatabaseName.Properties).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private DevExpress.XtraEditors.TextEdit txtServerName;
    private DevExpress.XtraEditors.TextEdit txtDatabaseName;
    private DevExpress.XtraEditors.SimpleButton btnConnect;
    private DevExpress.XtraEditors.LabelControl lblErrorMessage;
    private DevExpress.XtraEditors.LabelControl labelServerName;
    private DevExpress.XtraEditors.LabelControl labelDatabaseName;
}