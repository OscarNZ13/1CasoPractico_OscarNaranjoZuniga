using _1CasoPractico_OscarNaranjoZuniga.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Servicio> Servicios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Servicio>()
            .Property(s => s.Costo)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Servicio>()
            .Property(s => s.FechaCreacion)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<Servicio>()
            .Property(s => s.FechaModificacion)
            .HasDefaultValueSql("GETDATE()");

        base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries<Servicio>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.FechaCreacion = DateTime.Now;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.FechaModificacion = DateTime.Now;
                // No cambiar la FechaCreacion en la edición
                entry.Property(s => s.FechaCreacion).IsModified = false;
            }
        }

        return base.SaveChanges();
    }
}
