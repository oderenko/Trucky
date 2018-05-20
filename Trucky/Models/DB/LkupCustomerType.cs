using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trucky.Models.DB {
  [Table("lkup_CustomerType", Schema = "dbo")]
  public partial class LkupCustomerType {
    public LkupCustomerType() {
      Customer = new HashSet<Customer>();
    }

    [Column("lkup_CustomerType_UID")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LkupCustomerTypeId { get; set; }

    [MaxLength(20)]
    public string Type { get; set; }

    public ICollection<Customer> Customer { get; set; }

    #region Keys

    /// <summary>
    /// Wires up the keys for this object.
    /// </summary>
    /// <param name="modelBuilder">The model builder object that helps you identify how the model looks.</param>
    public static void SetupKeys(ModelBuilder modelBuilder) {
      modelBuilder.Entity<LkupCustomerType>(entity => {
        entity.HasKey(e => e.LkupCustomerTypeId)
        .ForSqlServerIsClustered();
      });
    }

    #endregion
  }
}