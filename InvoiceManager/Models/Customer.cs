using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InvoiceManager.Enums;

namespace InvoiceManager.Models;

[Index(nameof(TaxId), IsUnique = true)]
public class Customer
{
    public Customer()
    {
        Name = string.Empty;
        TaxId = string.Empty;
        Abbreviation = string.Empty;
        Country = string.Empty;
        Address = string.Empty;
        TypeKind = CustomerType.Individual; 

        Invoices = new HashSet<Invoice>();
    }

    public Customer(Customer source)
    {
        if (source == null)
        {
            return;
        }

        Id = source.Id;
        TypeKind = source.TypeKind;
        Name = source.Name;
        Abbreviation = source.Abbreviation;
        Country = source.Country;
        Address = source.Address;
        TaxId = source.TaxId;
        IsActive = source.IsActive;
        Invoices = new HashSet<Invoice>(source.Invoices ?? []);
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Type/Kind is required.")]
    public CustomerType TypeKind { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [MaxLength(250)]
    public string Name { get; set; }

    [MaxLength(50)]
    public string Abbreviation { get; set; }

    [MaxLength(100)]
    public string Country { get; set; }

    [MaxLength(500)]
    public string Address { get; set; }

    [Required(ErrorMessage = "TaxId is required.")]
    [MaxLength(20)]
    public string TaxId { get; set; }

    public bool IsActive { get; set; } = true;

    public virtual ICollection<Invoice> Invoices { get; set; }

    [NotMapped] 
    public string DisplayName => $"{Name} ({TaxId})";
    public override string ToString()
    {
        return DisplayName;
    }
    public Customer Clone()
    {
        var clonedCustomer = new Customer(this);
        return clonedCustomer;
    }
}