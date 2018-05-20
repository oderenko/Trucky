using Microsoft.EntityFrameworkCore;

namespace Trucky.Models.DB {
  public partial class TruckyContext : DbContext {

    public virtual DbSet<Cargo> Cargos { get; set; }
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<Good> Goods { get; set; }
    public virtual DbSet<Invoice> Invoices { get; set; }
    public virtual DbSet<LkupCustomerType> LkupCustomerTypes { get; set; }
    public virtual DbSet<LkupPosition> LkupPositions { get; set; }
    public virtual DbSet<Transportation> Transportations { get; set; }
    public virtual DbSet<Truck> Trucks { get; set; }

    public TruckyContext(DbContextOptions<TruckyContext> options) 
      : base(options) {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      if (!optionsBuilder.IsConfigured) {
        optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Trucky;Trusted_Connection=True;");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      Cargo.SetupKeys(modelBuilder);
      Customer.SetupKeys(modelBuilder);
      Employee.SetupKeys(modelBuilder);
      Good.SetupKeys(modelBuilder);
      Invoice.SetupKeys(modelBuilder);
      LkupCustomerType.SetupKeys(modelBuilder);
      LkupPosition.SetupKeys(modelBuilder);
      Transportation.SetupKeys(modelBuilder);
      Truck.SetupKeys(modelBuilder);

      Customer.SetupRelations(modelBuilder);
      Employee.SetupRelations(modelBuilder);
      Good.SetupRelations(modelBuilder);
      Invoice.SetupRelations(modelBuilder);
      Transportation.SetupRelations(modelBuilder);
    }
  }
}
