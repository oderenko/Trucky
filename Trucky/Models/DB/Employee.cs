using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trucky.Models.DB {
  [Table("Employee", Schema = "dbo")]
  public partial class Employee {
    public Employee() {
      Invoice = new HashSet<Invoice>();
    }

    [Column("Employee_UID")]
    public int EmployeeId { get; set; }

    [MaxLength(20)]
    public string FirstName { get; set; }

    [MaxLength(20)]
    public string LastName { get; set; }

    public DateTime? BirthdayDate { get; set; }

    public DateTime HireDate { get; set; }

    public int Salary { get; set; }

    [MaxLength(30)]
    public string City { get; set; }

    [Column("Position_FID")]
    public int PositionFid { get; set; }

    public LkupPosition PositionF { get; set; }
    public ICollection<Invoice> Invoice { get; set; }

    #region Keys

    /// <summary>
    /// Wires up the keys for this object.
    /// </summary>
    /// <param name="modelBuilder">The model builder object that helps you identify how the model looks.</param>
    public static void SetupKeys(ModelBuilder modelBuilder) {
      modelBuilder.Entity<Employee>(entity => {
        entity.HasKey(e => e.EmployeeId)
        .ForSqlServerIsClustered(true);
      });
    }

    /// <summary>
    /// Wires up any foreign key relations that this object depends on.
    /// </summary>
    /// <param name="modelBuilder">The model builder object that helps you identify how the model looks.</param>
    public static void SetupRelations(ModelBuilder modelBuilder) {
      // add foreign key references
      modelBuilder.Entity<Employee>()
             .HasOne(d => d.PositionF)
             .WithMany(p => p.Employee)
             .HasForeignKey(d => d.PositionFid)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("FK_Employee_Position");
    }

    #endregion
  }
}
