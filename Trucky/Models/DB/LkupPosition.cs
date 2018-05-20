using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trucky.Models.DB {
  [Table("lkup_Position", Schema = "dbo")]
  public partial class LkupPosition {
    public LkupPosition() {
      Employee = new HashSet<Employee>();
    }

    [Column("lkup_Position_UID")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LkupPositionUid { get; set; }

    [MaxLength(20)]
    public string PositionName { get; set; }

    public ICollection<Employee> Employee { get; set; }

    #region Keys

    /// <summary>
    /// Wires up the keys for this object.
    /// </summary>
    /// <param name="modelBuilder">The model builder object that helps you identify how the model looks.</param>
    public static void SetupKeys(ModelBuilder modelBuilder) {
      modelBuilder.Entity<LkupPosition>(entity => {
        entity.HasKey(e => e.LkupPositionUid)
        .ForSqlServerIsClustered(true);
      });
    }

    #endregion
  }
}
