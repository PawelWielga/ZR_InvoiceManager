using System.ComponentModel;

namespace InvoiceManager.Enums;

public enum CustomerType
{
    [Description("Individual")] 
    Individual = 0,
    [Description("Company")]
    Company = 1,
    [Description("Organization")]
    Organization = 2
}