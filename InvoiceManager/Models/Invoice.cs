using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceManager.Models;

public class Invoice
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Invoice number is required.")]
    [MaxLength(50)]
    public string InvoiceNumber { get; set; } = string.Empty;
    [Required(ErrorMessage = "Net amount is required.")]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal NetAmount { get; set; }

    [Required(ErrorMessage = "Currency is required.")]
    [MaxLength(5)]
    public string Currency { get; set; } = string.Empty;

    [Required(ErrorMessage = "VAT Rate is required.")]
    [Column(TypeName = "decimal(5, 2)")]
    public decimal VatRate { get; set; }

    [Required(ErrorMessage = "Sale Date is required.")]
    public DateTime SaleDate { get; set; } = DateTime.Today;

    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;

    public int CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    public virtual Customer? Customer { get; set; }
}