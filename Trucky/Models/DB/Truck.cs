using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trucky.Models.DB {
  [Table("Truck", Schema = "dbo")]
  public partial class Truck {
    public Truck() {
      Transportation = new HashSet<Transportation>();
    }

    [Column("Truck_UID")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TruckId { get; set; }

    [MaxLength(80)]
    public string TruckName { get; set; }

    public int Fuel { get; set; }

    public double Capacity { get; set; }

    public double Volume { get; set; }

    public int Speed { get; set; }

    public DateTime? LastInspection { get; set; }

    public ICollection<Transportation> Transportation { get; set; }

    #region Keys

    /// <summary>
    /// Wires up the keys for this object.
    /// </summary>
    /// <param name="modelBuilder">The model builder object that helps you identify how the model looks.</param>
    public static void SetupKeys(ModelBuilder modelBuilder) {
      modelBuilder.Entity<Truck>(entity => {
        entity.HasKey(e => e.TruckId)
          .ForSqlServerIsClustered(true);
      });
    }
  }

  #endregion
}
