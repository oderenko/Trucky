using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trucky.Models.DB {
  [Table("Customer", Schema = "dbo")]
  public partial class Customer {
    public Customer() {
      InvoiceBuyer = new HashSet<Invoice>();
      InvoiceSeller = new HashSet<Invoice>();
    }

    [Column("Customer_UID")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CustomerId { get; set; }

    [MaxLength(80)]
    public string FullName { get; set; }

    [MaxLength(13)]
    public string PhoneNumber { get; set; }

    [MaxLength(255)]
    public string Email { get; set; }

    [DefaultValue(false)]
    public bool? IsCorporate { get; set; }

    [Column("CustomerType_FID")]
    public int CustomerTypeFid { get; set; }

    public LkupCustomerType CustomerType { get; set; }
    public ICollection<Invoice> InvoiceBuyer { get; set; }
    public ICollection<Invoice> InvoiceSeller { get; set; }

    #region Keys

    /// <summary>
    /// Wires up the keys for this object.
    /// </summary>
    /// <param name="modelBuilder">The model builder object that helps you identify how the model looks.</param>
    public static void SetupKeys(ModelBuilder modelBuilder) {
      modelBuilder.Entity<Customer>(entity => {
        entity.HasKey(e => e.CustomerId)
        .ForSqlServerIsClustered(true);
      });
    }

    /// <summary>
    /// Wires up any foreign key relations that this object depends on.
    /// </summary>
    /// <param name="modelBuilder">The model builder object that helps you identify how the model looks.</param>
    public static void SetupRelations(ModelBuilder modelBuilder) {
      modelBuilder.Entity<Customer>().HasOne(d => d.CustomerType)
             .WithMany(p => p.Customer)
             .HasForeignKey(d => d.CustomerTypeFid)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("FK_Customer_lkup_CustomerType");
    }

    #endregion
  }
}
