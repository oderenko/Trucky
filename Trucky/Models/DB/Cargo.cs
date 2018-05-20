using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trucky.Models.DB {
  [Table("Cargos", Schema = "dbo")]
  public partial class Cargo {

    public Cargo() {
      Goods = new HashSet<Good>();
    }

    [Column("Cargo_UID")]
    public int CargoId { get; set; }

    [MaxLength(80)]
    public string Name { get; set; }

    public int Volume { get; set; }

    public int Price { get; set; }

    [DefaultValue(true)]
    public bool? IsComodity { get; set; }

    public bool IsFragile { get; set; }

    public ICollection<Good> Goods { get; set; }

    #region Keys

    /// <summary>
    /// Wires up any foreign key relations that this object depends on.
    /// </summary>
    /// <param name="modelBuilder">The model builder object that helps you identify how the model looks.</param>
    public static void SetupKeys(ModelBuilder modelBuilder) {
      modelBuilder.Entity<Cargo>(entity => {
        entity.HasKey(e => e.CargoId)
         .ForSqlServerIsClustered(true);
      });
    }

    #endregion
  }
}
