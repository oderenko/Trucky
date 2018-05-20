using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trucky.Models.DB {
  [Table("Goods", Schema = "dbo")]
  public partial class Good {
    public Good() {
      Invoice = new HashSet<Invoice>();
    }

    [Column("Goods_UID")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int GoodsId { get; set; }

    public int Quantity { get; set; }

    [Column("Cargo_FID")]
    public int CargoFid { get; set; }

    public Cargo CargoF { get; set; }
    public ICollection<Invoice> Invoice { get; set; }

    #region Keys

    /// <summary>
    /// Wires up the keys for this object.
    /// </summary>
    /// <param name="modelBuilder">The model builder object that helps you identify how the model looks.</param>
    public static void SetupKeys(ModelBuilder modelBuilder) {
      modelBuilder.Entity<Good>(entity => {
        entity.HasKey(e => e.GoodsId);
      });
    }

    /// <summary>
    /// Wires up any foreign key relations that this object depends on.
    /// </summary>
    /// <param name="modelBuilder">The model builder object that helps you identify how the model looks.</param>
    public static void SetupRelations(ModelBuilder modelBuilder) {
      // add foreign key references
      modelBuilder.Entity<Good>()
            .HasOne(d => d.CargoF)
            .WithMany(p => p.Goods)
            .HasForeignKey(d => d.CargoFid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_GoodsCargo_Cargo");
    }

    #endregion
  }
}
