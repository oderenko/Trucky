using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trucky.Models.DB {
  [Table("Transportation", Schema = "dbo")]
  public partial class Transportation {

    [Column("Transportation_UID")]
    public int TransportationId { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public DateTime StartDate { get; set; }

    [Column("Truck_FID")]
    public int TruckFid { get; set; }

    public Truck TruckF { get; set; }

    #region Keys

    /// <summary>
    /// Wires up the keys for this object.
    /// </summary>
    /// <param name="modelBuilder">The model builder object that helps you identify how the model looks.</param>
    public static void SetupKeys(ModelBuilder modelBuilder) {
      modelBuilder.Entity<Transportation>(entity => {
        entity.HasKey(e => e.TransportationId)
        .ForSqlServerIsClustered(true);

        entity.Property(e => e.StartDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getutcdate())");
      });
    }

    /// <summary>
    /// Wires up any foreign key relations that this object depends on.
    /// </summary>
    /// <param name="modelBuilder">The model builder object that helps you identify how the model looks.</param>
    public static void SetupRelations(ModelBuilder modelBuilder) {
      modelBuilder.Entity<Transportation>()
            .HasOne(d => d.TruckF)
            .WithMany(p => p.Transportation)
            .HasForeignKey(d => d.TruckFid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Transportation_Truck");
    }

    #endregion
  }
}
