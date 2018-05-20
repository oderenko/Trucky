using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trucky.Models.DB {
  [Table("Invoice", Schema = "dbo")]
  public partial class Invoice {

    [Column("Invoice_UID")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int InvoiceId { get; set; }

    [Column("DateOFPay")]
    public DateTime? DateOfPay { get; set; }

    [Column("Goods_FID")]
    public int GoodsFid { get; set; }

    [Column("Employee_FID")]
    public int EmployeeFid { get; set; }

    [Column("Buyer_FID")]
    public int BuyerFid { get; set; }

    [Column("Seller_FID")]
    public int SellerFid { get; set; }

    public Customer Buyer { get; set; }
    public Employee Employee { get; set; }
    public Good Goods { get; set; }
    public Customer Seller { get; set; }

    #region Keys

    /// <summary>
    /// Wires up the keys for this object.
    /// </summary>
    /// <param name="modelBuilder">The model builder object that helps you identify how the model looks.</param>
    public static void SetupKeys(ModelBuilder modelBuilder) {
      modelBuilder.Entity<Invoice>(entity => {
        entity.HasKey(e => e.InvoiceId)
        .ForSqlServerIsClustered(true);
      });
    }

    /// <summary>
    /// Wires up any foreign key relations that this object depends on.
    /// </summary>
    /// <param name="modelBuilder">The model builder object that helps you identify how the model looks.</param>
    public static void SetupRelations(ModelBuilder modelBuilder) {
      modelBuilder.Entity<Invoice>(entity => {
        entity.HasOne(d => d.Buyer)
            .WithMany(p => p.InvoiceBuyer)
            .HasForeignKey(d => d.BuyerFid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_InvoiceBuyer_Customer");

        entity.HasOne(d => d.Employee)
            .WithMany(p => p.Invoice)
            .HasForeignKey(d => d.EmployeeFid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Invoice_Employee");

        entity.HasOne(d => d.Goods)
            .WithMany(p => p.Invoice)
            .HasForeignKey(d => d.GoodsFid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Bill_Goods");

        entity.HasOne(d => d.Seller)
            .WithMany(p => p.InvoiceSeller)
            .HasForeignKey(d => d.SellerFid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_InvoiceSeller_Customer");
      });
    }

    #endregion
  }
}
