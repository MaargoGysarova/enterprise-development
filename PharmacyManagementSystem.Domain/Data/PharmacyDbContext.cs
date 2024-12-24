using Microsoft.EntityFrameworkCore;
using PharmacyManagementSystem.Domain;

namespace PharmacyManagementSystem.Domain.Data;

/// <summary>
/// Контекст базы данных для работы с сущностями аптек, препаратов и прайс-листов.
/// </summary>
public class PharmacyDbContext : DbContext
{
    /// <summary>
    /// Коллекция аптек в базе данных.
    /// </summary>
    public DbSet<Pharmacy> Pharmacies { get; set; } = null!;

    /// <summary>
    /// Коллекция препаратов в базе данных.
    /// </summary>
    public DbSet<Medicine> Medicines { get; set; } = null!;

    /// <summary>
    /// Коллекция прайс-листов в базе данных.
    /// </summary>
    public DbSet<PriceList> PriceLists { get; set; } = null!;

    /// <summary>
    /// Инициализирует новый экземпляр контекста базы данных.
    /// </summary>
    public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Pharmacy>()
            .HasKey(p => p.PharmacyId);

        modelBuilder.Entity<Medicine>()
            .HasKey(m => m.MedicineId);

        modelBuilder.Entity<PriceList>()
            .HasKey(pl => pl.PriceListId);

        // Связи между сущностями
        modelBuilder.Entity<PriceList>()
            .HasOne(pl => pl.Pharmacy)
            .WithMany(p => p.PriceLists)
            .HasForeignKey(pl => pl.PharmacyId);

        modelBuilder.Entity<PriceList>()
            .HasOne(pl => pl.Medicine)
            .WithOne()
            .HasForeignKey<PriceList>(pl => pl.MedicineId);
    }
}

